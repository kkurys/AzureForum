import { Component } from '@angular/core';
import { AuthService } from './../../services/auth.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ["./login.component.css"]
})


export class LoginComponent {
  loginForm: FormGroup;
  message: string;

  constructor(private authService: AuthService,
    private formBuilder: FormBuilder,
    private router: Router) {
    this.loginForm = this.formBuilder.group({
      login: [
        '',
        [Validators.required]
      ],
      password: [
        '',
        [Validators.required]
      ]
    });

  }

  submit() {
    this.authService
      .login(this.loginForm.controls.login.value, this.loginForm.controls.password.value)
      .subscribe(result => {
        localStorage.setItem('token', result);
        this.message = "";
        this.router.navigateByUrl('');
      }, error => this.message = "Email lub hasło jest niepoprawne.");
  }
}
