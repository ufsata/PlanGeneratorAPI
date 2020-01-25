import { IEmployeeAbsenceDate } from './../employeeAbsenceDate';
import { IEmployee } from "./../employee";
import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { EmployeeService } from "../employee.service";

@Component({
  templateUrl: "./employee-detail.component.html",
  styleUrls: ["./employee-detail.component.css"]
})
export class EmployeeDetailComponent implements OnInit {
  pageTitle: string = "Employee Details";
  employee: IEmployee;
  employeeAbsenceDates: IEmployeeAbsenceDate[] = [];
  errorMessage: string;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private employeeService: EmployeeService
  ) {}

  ngOnInit() {
    const param = +this.route.snapshot.paramMap.get("id");
    if (param) {
        const id = +param;
        this.getEmployee(id);
        this.getEmployeeAbsenceDates(id);
        
    }    
  }

  getEmployee(id: number) {
    this.employeeService.getEmployee(id).subscribe({
      next: employee => (this.employee = employee),
      error: err => (this.errorMessage = err)
    });
  }

  getEmployeeAbsenceDates(id: number){
      this.employeeService.getAbsenceDatesById(id).subscribe({
          next: absDates => {
            this.employeeAbsenceDates = absDates;
          },
          error: err => (this.errorMessage = err)
      });
      console.log(this.employeeAbsenceDates);
  }

  onBack(): void {
    this.router.navigate(["/employees"]);
  }
}
