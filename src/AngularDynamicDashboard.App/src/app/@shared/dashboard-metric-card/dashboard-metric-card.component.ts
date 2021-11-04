import { Component } from '@angular/core';
import { DashboardCard } from '@api';

@Component({
  selector: 'app-dashboard-metric-card',
  templateUrl: './dashboard-metric-card.component.html',
  styleUrls: ['./dashboard-metric-card.component.scss']
})
export class DashboardMetricCardComponent  {

  public dashboardCard: DashboardCard;

}
