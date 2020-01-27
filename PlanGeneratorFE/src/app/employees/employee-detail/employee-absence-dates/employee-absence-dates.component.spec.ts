import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EmployeeAbsenceDatesComponent } from './employee-absence-dates.component';

describe('EmployeeAbsenceDatesComponent', () => {
  let component: EmployeeAbsenceDatesComponent;
  let fixture: ComponentFixture<EmployeeAbsenceDatesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EmployeeAbsenceDatesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EmployeeAbsenceDatesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
