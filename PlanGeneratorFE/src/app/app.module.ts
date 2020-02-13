import { EmployeeDetailGuard } from "./employees/employee-detail/employee-detail.guard";
import { RouterModule } from "@angular/router";
import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { HttpClientModule } from "@angular/common/http";
import { NgbModule } from "@ng-bootstrap/ng-bootstrap";

import { AppRoutingModule } from "./app-routing.module";
import { AppComponent } from "./app.component";
import { EmployeeListComponent } from "./employees/employee-list/employee-list.component";
import { from } from "rxjs";
import { EmployeeDetailComponent } from "./employees/employee-detail/employee-detail.component";
import { LoginComponent } from "./home/login/login.component";
import { EmployeeShiftRequiremtnsComponent } from "./employees/employee-detail/employee-shift-requiremtns/employee-shift-requiremtns.component";
import { EmployeeAbsenceDatesComponent } from "./employees/employee-detail/employee-absence-dates/employee-absence-dates.component";
import { DatePickerComponent } from "./shared/date-picker/date-picker.component";

@NgModule({
  declarations: [
    AppComponent,
    EmployeeListComponent,
    EmployeeDetailComponent,
    LoginComponent,
    EmployeeShiftRequiremtnsComponent,
    EmployeeAbsenceDatesComponent,
    DatePickerComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgbModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {}
