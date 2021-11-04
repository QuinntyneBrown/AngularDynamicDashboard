import { AfterViewInit, Component, ComponentFactoryResolver, Input, ViewChild, ViewContainerRef } from '@angular/core';
import { DashboardCard } from '@api';
import { DashboardCardComponent, DashboardMetricCardComponent } from '@shared';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements AfterViewInit {

  @Input() public dashboardCards: DashboardCard[] = [];

  @ViewChild("target", { static: false, read: ViewContainerRef })
  target: ViewContainerRef;

  constructor(
    private readonly _componentFactoryResolver: ComponentFactoryResolver
  ) {

  }
  ngAfterViewInit() {
    let componentFactory: any = null;

    for(let i = 0; i < this.dashboardCards.length; i++) {
      switch(this.dashboardCards[i].cardType) {
        case 'Metric':
          componentFactory = this._componentFactoryResolver.resolveComponentFactory(DashboardMetricCardComponent);
          break;

        default:
          componentFactory = this._componentFactoryResolver.resolveComponentFactory(DashboardCardComponent);
          break;
      }

      const componentRef: any = this.target.createComponent(<any>componentFactory);

      componentRef.instance.dashboardCard = this.dashboardCards[i];
    }
  }

}
