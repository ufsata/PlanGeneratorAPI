import { IEmployeeShiftRequirement } from './../../employeeShiftRequirement';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { EmployeeService } from '../../employee.service';

@Component({
  selector: 'app-employee-shift-requiremtns',
  templateUrl: './employee-shift-requiremtns.component.html',
  styleUrls: ['./employee-shift-requiremtns.component.css']
})
export class EmployeeShiftRequiremtnsComponent implements OnInit {
    employeeShiftRequiremtns: IEmployeeShiftRequirement[] = [];
    errorMessage: string;

  constructor(private route: ActivatedRoute,
    private employeeService: EmployeeService) { }

  ngOnInit() {
    const param = +this.route.snapshot.paramMap.get("id");
    if (param) {
        const id = +param;
        this.getEmployeeShiftRequirements(id);        
    }  
  }
    getEmployeeShiftRequirements(id: number) {
        this.employeeService.getShiftRequirementsById(id).subscribe({
            next: shiftReqirements => {
                this.employeeShiftRequiremtns = shiftReqirements
            },
            error: err => (this.errorMessage = err)
        });
        console.log(this.employeeShiftRequiremtns);
    }

}
