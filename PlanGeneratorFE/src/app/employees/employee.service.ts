import { IEmployeeAbsenceDate } from "./employeeAbsenceDate";
import { IEmployee } from "./employee";
import { Injectable } from "@angular/core";
import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import { Observable, throwError } from "rxjs";
import { catchError, tap, map } from "rxjs/operators";

@Injectable({
  providedIn: "root"
})
export class EmployeeService {
  private employeeUrl = "http://localhost:51828/api/employees";
  private employeeDetailsUrl =
    "http://localhost:51828/api/EmployeesAbsenceDates";

  constructor(private http: HttpClient) {}

  getEmployees(): Observable<IEmployee[]> {
    return this.http.get<IEmployee[]>(this.employeeUrl).pipe(
      tap(data => console.log("All: " + JSON.stringify(data))),
      catchError(this.handleError)
    );
  }

  getEmployee(id: number): Observable<IEmployee> {
    return this.getEmployees().pipe(
      map((employees: IEmployee[]) => employees.find(e => e.id === id))
    );
  }

  getAbsenceDatesById(id: number): Observable<IEmployeeAbsenceDate[]> {
      console.log(id);
    return this.http
      .get<IEmployeeAbsenceDate[]>(this.employeeDetailsUrl + "/" + id)
      .pipe(
        tap(data => console.log("All: " + JSON.stringify(data))),
        catchError(this.handleError)
      );
  }
  private handleError(err: HttpErrorResponse) {
    // Currently just logging it to the console
    let errorMessage = "";
    if (err.error instanceof ErrorEvent) {
      // A client-side or network error occurred. Handle it accordingly.
      errorMessage = `An error occurred: ${err.error.message}`;
    } else {
      // The backend returned an unsuccessful response code.
      // The response body may contain clues as to what went wrong,
      errorMessage = `Server returned code: ${err.status}, error message is: ${err.message}`;
    }
    console.error(errorMessage);
    return throwError(errorMessage);
  }
}
