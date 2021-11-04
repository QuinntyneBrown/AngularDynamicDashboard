import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DashboardCardSettingsEditorComponent } from './dashboard-card-settings-editor.component';
import { ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    DashboardCardSettingsEditorComponent
  ],
  exports: [
    DashboardCardSettingsEditorComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule
  ]
})
export class DashboardCardSettingsEditorModule { }
