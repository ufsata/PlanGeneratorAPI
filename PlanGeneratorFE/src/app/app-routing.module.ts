import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { EmployeeListComponent } from './employees/employee-list/employee-list.component';
import { LoginComponent } from './home/login/login.component';
import { EmployeeDetailGuard } from './employees/employee-detail/employee-detail.guard';
import { EmployeeDetailComponent } from './employees/employee-detail/employee-detail.component';

const routes: Routes = [
    { path: "employees", component: EmployeeListComponent },
      {
        path: "employeeDetails/:id",
        canActivate: [EmployeeDetailGuard],
        component: EmployeeDetailComponent
      },
      { path: "login", component: LoginComponent },
      { path: "", redirectTo: "login", pathMatch: "full" },
      { path: "**", redirectTo: "login", pathMatch: "full" }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
