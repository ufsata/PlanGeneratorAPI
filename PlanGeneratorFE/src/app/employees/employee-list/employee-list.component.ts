import { EmployeeService } from "../employee.service";
import { Component, OnInit } from "@angular/core";
import { IEmployee } from "../employee";

@Component({
  templateUrl: "./employee-list.component.html",
  styleUrls: ["./employee-list.component.css"]
})
export class EmployeeListComponent implements OnInit {
  pageTitle: string = "List of Employees";
  imageWidth: number = 50;
  imageMargin: number = 2;
  showImage: boolean = false;
  filterdEmployees: IEmployee[];
  employees: IEmployee[] = [];
  _listFilter: string;
  errorMessage: string;

  get listFilter(): string {
    return this._listFilter;
  }
  set listFilter(v: string) {
    this._listFilter = v;
    this.filterdEmployees = this.listFilter
      ? this.performFIlter(this.listFilter)
      : this.employees;
  }

  performFIlter(filterBy: string): IEmployee[] {
    filterBy = filterBy.toLocaleLowerCase();
    return this.employees.filter(
      employee => employee.name.toLocaleLowerCase().indexOf(filterBy) !== -1
    );
  }
  toggleImage(): void {
    this.showImage = !this.showImage;
  }
  constructor(private employeeService: EmployeeService) {}

  ngOnInit() {
    this.employeeService.getEmployees().subscribe({
      next: employees => {
        this.employees = employees;
        this.filterdEmployees = this.employees;
      },
      error: err => (this.errorMessage = err)
    });
  }
}
