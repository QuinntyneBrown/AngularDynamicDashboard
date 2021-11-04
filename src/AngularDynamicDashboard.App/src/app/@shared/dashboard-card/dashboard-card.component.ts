import { Component, OnInit } from '@angular/core';
import { DashboardCard } from '@api';

@Component({
  selector: 'app-dashboard-card',
  templateUrl: './dashboard-card.component.html',
  styleUrls: ['./dashboard-card.component.scss']
})
export class DashboardCardComponent {

  public dashboardCard: DashboardCard;

}
