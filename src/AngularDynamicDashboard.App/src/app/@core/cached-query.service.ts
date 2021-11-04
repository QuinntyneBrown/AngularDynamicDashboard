import { Injectable } from '@angular/core';
import { DashboardCardService } from '@api';
import { BehaviorSubject, Observable } from 'rxjs';
import { shareReplay, switchMap, tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class CachedQueryService {

  private readonly _cache = new Map<string, Observable<any>>();

  private readonly _refreshSubject = new BehaviorSubject<void>(null);

  constructor(
    private readonly _dashboardCardService: DashboardCardService
  ) { }

  protected _fromCacheOrService$(key:string, func: {(): Observable<any>}): Observable<any> {
    if (!this._cache.get(key)) {
      this._cache.set(
        key,
        func().pipe(shareReplay(1))
      );
    }
    return this._cache.get(key);
  }

  protected _fromCacheOrServiceWithRefresh$(key:string, func:any, refresh$: BehaviorSubject<void>) {
    return refresh$
    .pipe(
      tap(_ => this._cache.set(key,null)),
      switchMap(_ => this._fromCacheOrService$(key, func))
    );
  }

  public getDashboardCards() {
    const func = () => this._dashboardCardService.get();
    return this._fromCacheOrServiceWithRefresh$("DASHBOARD_CARDS", func, this._refreshSubject);
  }

  public refresh() {
    this._refreshSubject.next();
  }
}
