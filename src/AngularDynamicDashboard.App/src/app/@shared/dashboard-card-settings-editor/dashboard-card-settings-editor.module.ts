import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DashboardCardSettingsEditorComponent } from './dashboard-card-settings-editor.component';
import { ReactiveFormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';



@NgModule({
  declarations: [
    DashboardCardSettingsEditorComponent
  ],
  exports: [
    DashboardCardSettingsEditorComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatInputModule,
    MatFormFieldModule
  ]
})
export class DashboardCardSettingsEditorModule { }
