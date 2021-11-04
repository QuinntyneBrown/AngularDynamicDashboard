import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { baseUrl } from '@core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { DashboardCardModule } from '@shared/dashboard-card';
import { DashboardMetricCardModule } from '@shared/dashboard-metric-card';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatDialogModule } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { ReactiveFormsModule } from '@angular/forms';
import { DashboardCardSettingsEditorModule } from '@shared';
import { DashboardModule } from '@shared/dashboard/dashboard.module';



@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    MatButtonModule,
    MatIconModule,
    DashboardCardModule,
    DashboardMetricCardModule,
    MatSidenavModule,
    MatDialogModule,
    MatFormFieldModule,
    MatInputModule,
    ReactiveFormsModule,
    DashboardCardSettingsEditorModule,
    DashboardModule
  ],
  providers: [
    {
      provide: baseUrl,
      useValue: "https://localhost:5001/"
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
