import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DashboardCardSettingsEditorComponent } from './dashboard-card-settings-editor.component';

describe('DashboardCardSettingsEditorComponent', () => {
  let component: DashboardCardSettingsEditorComponent;
  let fixture: ComponentFixture<DashboardCardSettingsEditorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DashboardCardSettingsEditorComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DashboardCardSettingsEditorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
