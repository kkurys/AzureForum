import { Component } from "@angular/core";
import { AuthService } from "../../services/auth.service";
import { Router } from '@angular/router';


@Component({
  selector: "app-nav-menu",
  templateUrl: "./nav-menu.component.html",
  styleUrls: ["./nav-menu.component.css"]
})
export class NavMenuComponent {
  isExpanded = false;
  isLoggedIn: boolean;
  constructor(
    private authService: AuthService,
    private router: Router) { }

  ngOnInit(): void {
    this.isLoggedIn = this.authService.isLoggedIn();
  }
  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
  logout() {
    localStorage.removeItem('token');
    this.router.navigateByUrl('');
  }
}
