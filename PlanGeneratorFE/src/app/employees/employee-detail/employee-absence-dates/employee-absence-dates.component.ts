import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { EmployeeService } from '../../employee.service';
import { IEmployeeAbsenceDate } from '../../employeeAbsenceDate';

@Component({
  selector: 'app-employee-absence-dates',
  templateUrl: './employee-absence-dates.component.html',
  styleUrls: ['./employee-absence-dates.component.css']
})
export class EmployeeAbsenceDatesComponent implements OnInit {

    employeeAbsenceDates: IEmployeeAbsenceDate[] = [];
    errorMessage: string;
    
  constructor(private route: ActivatedRoute,
    private employeeService: EmployeeService) { }

  ngOnInit() {
    const param = +this.route.snapshot.paramMap.get("id");
    if (param) {
        const id = +param;
        this.getEmployeeAbsenceDates(id);        
    }  
  }
    getEmployeeAbsenceDates(id: number) {
        this.employeeService.getAbsenceDatesById(id).subscribe({
            next: shiftReqirements => {
                this.employeeAbsenceDates = shiftReqirements
            },
            error: err => (this.errorMessage = err)
        });
        console.log(this.employeeAbsenceDates);
    }

}
