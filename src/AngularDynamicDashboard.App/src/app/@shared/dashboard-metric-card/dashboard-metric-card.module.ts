import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DashboardMetricCardComponent } from './dashboard-metric-card.component';



@NgModule({
  declarations: [
    DashboardMetricCardComponent
  ],
  exports: [
    DashboardMetricCardComponent
  ],
  imports: [
    CommonModule
  ]
})
export class DashboardMetricCardModule { }
