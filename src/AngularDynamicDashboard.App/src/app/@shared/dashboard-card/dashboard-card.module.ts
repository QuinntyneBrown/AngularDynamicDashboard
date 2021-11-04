import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DashboardCardComponent } from './dashboard-card.component';



@NgModule({
  declarations: [
    DashboardCardComponent
  ],
  exports: [
    DashboardCardComponent
  ],
  imports: [
    CommonModule
  ]
})
export class DashboardCardModule { }
