import { Component } from "@angular/core";

@Component({
  selector: "app-nav-login-register",
  templateUrl: "./nav-login-register.component.html",
  styleUrls: ["./nav-login-register.component.css"]
})
export class NavLoginRegisterComponent {
  isExpanded = false;

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}
