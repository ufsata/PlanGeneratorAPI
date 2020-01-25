import { Component } from "@angular/core";

@Component({
  selector: "app-root",
  template: `
    <nav class="navbar navbar-expand navbar-light bg-light">
      <a class="navbar-brand">
        {{ pageTitle }}
      </a>
      <ul class="nav nav-pills">
        <li><a class="nav-link" [routerLink]="['/login']">Home</a></li>
      </ul>
    </nav>
    <div class="container">
      <router-outlet></router-outlet>
    </div>
  `,
  //   templateUrl: './app.component.html',
  styleUrls: ["./app.component.css"]
})
export class AppComponent {
  pageTitle: string = "Plan Generator";
}
