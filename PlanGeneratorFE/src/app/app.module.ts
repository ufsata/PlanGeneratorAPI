import { EmployeeDetailGuard } from "./employees/employee-detail/employee-detail.guard";
import { RouterModule } from "@angular/router";
import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { HttpClientModule } from "@angular/common/http";

import { AppRoutingModule } from "./app-routing.module";
import { AppComponent } from "./app.component";
import { EmployeeListComponent } from "./employees/employee-list/employee-list.component";
import { from } from "rxjs";
import { EmployeeDetailComponent } from "./employees/employee-detail/employee-detail.component";
import { LoginComponent } from "./home/login/login.component";

@NgModule({
  declarations: [
    AppComponent,
    EmployeeListComponent,
    EmployeeDetailComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    RouterModule.forRoot([
      { path: "employees", component: EmployeeListComponent },
      {
        path: "employeeDetails/:id",
        canActivate: [EmployeeDetailGuard],
        component: EmployeeDetailComponent
      },
      { path: "login", component: LoginComponent },
      { path: "", redirectTo: "login", pathMatch: "full" },
      { path: "**", redirectTo: "login", pathMatch: "full" }
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {}
