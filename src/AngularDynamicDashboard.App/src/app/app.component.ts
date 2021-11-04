import { Component, ViewChild } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatDrawer } from '@angular/material/sidenav';
import { DashboardCard, DashboardCardService } from '@api';
import { CachedQueryService } from '@core';
import { map, tap } from 'rxjs/operators';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {

  @ViewChild(MatDrawer, { static: false }) public drawer: MatDrawer | undefined;

  public vm$ = this._cachedQueryService
  .getDashboardCards()
  .pipe(
    map(dashboardCards => {

      let  form = new FormGroup({
        dashboardCardId: new FormControl(null,[]),
        cardType: new FormControl(null,[]),
        settings: new FormControl({},[])
      });

      return {
        dashboardCards,
        form
      };
    })
  );

  constructor(
    private readonly _cachedQueryService: CachedQueryService,
    private readonly _dashboardCardService: DashboardCardService
  ) {

  }

  public openDrawer() {
    this.drawer.open();
  }

  public save(dashboardCard: DashboardCard) {

    let obs$ = dashboardCard.dashboardCardId
    ? this._dashboardCardService.update({ dashboardCard })
    : this._dashboardCardService.create({ dashboardCard });

    obs$
    .pipe(
      tap(_ => {
        this._cachedQueryService.refresh();
        this.drawer.close();
      })
    ).subscribe();

  }
}
