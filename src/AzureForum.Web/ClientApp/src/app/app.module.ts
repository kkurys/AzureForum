import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { HttpClientModule } from "@angular/common/http";
import { RouterModule } from "@angular/router";

import { AppComponent } from "./app.component";
import { NavMenuComponent } from "./components/nav-menu/nav-menu.component";
import { HomeComponent } from "./components/home/home.component";
import { NavLoginRegisterComponent } from "./components/nav-login-register/nav-login-register.component";
import { AuthService } from "./services/auth.service";
import { JwtUtil } from "./utils/jwt.util";

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    NavLoginRegisterComponent,
    HomeComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: "ng-cli-universal" }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: "", component: HomeComponent, pathMatch: "full" }
    ])
  ],
  providers: [
    AuthService,
    JwtUtil,
    ],
  bootstrap: [AppComponent]
})
export class AppModule {
}
