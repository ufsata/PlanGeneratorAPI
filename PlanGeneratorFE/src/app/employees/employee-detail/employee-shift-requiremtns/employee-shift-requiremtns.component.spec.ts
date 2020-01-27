import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EmployeeShiftRequiremtnsComponent } from './employee-shift-requiremtns.component';

describe('EmployeeShiftRequiremtnsComponent', () => {
  let component: EmployeeShiftRequiremtnsComponent;
  let fixture: ComponentFixture<EmployeeShiftRequiremtnsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EmployeeShiftRequiremtnsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EmployeeShiftRequiremtnsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
