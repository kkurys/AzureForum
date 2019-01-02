import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import { MaterialModule } from './material.module';

import { AppComponent } from "./app.component";
import { NavMenuComponent } from "./components/nav-menu/nav-menu.component";
import { HomeComponent } from "./components/home/home.component";
import { NavLoginRegisterComponent } from "./components/nav-login-register/nav-login-register.component";
import { LoginComponent } from './components/login/login.component'

import { AuthService } from "./services/auth.service";
import { JwtUtil } from "./utils/jwt.util";

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    NavLoginRegisterComponent,
    HomeComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: "ng-cli-universal" }),
    RouterModule.forRoot([
      { path: "", component: HomeComponent, pathMatch: "full" },
      { path: "login", component: LoginComponent}
    ]),
    HttpClientModule,
    HttpModule,
    FormsModule,
    ReactiveFormsModule,
    MaterialModule
  ],
  providers: [
    AuthService,
    JwtUtil,
    ],
  bootstrap: [AppComponent]
})
export class AppModule {
}
