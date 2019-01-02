import { Component } from "@angular/core";
import { AuthService } from "../../services/auth.service";


@Component({
  selector: "app-nav-login-register",
  templateUrl: "./nav-login-register.component.html",
  styleUrls: ["./nav-login-register.component.css"]
})
export class NavLoginRegisterComponent {
  isLoggedIn: boolean;
  constructor(
    private authService: AuthService) {}

  ngOnInit(): void {
    this.isLoggedIn = this.authService.isLoggedIn();
  }
}
