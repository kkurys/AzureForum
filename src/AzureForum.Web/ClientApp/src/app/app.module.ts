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
import { LoginComponent } from './components/login/login.component'
import { RegisterComponent } from './components/register/register.component'
import { ThreadListComponent } from './components/thread-list/thread-list.component';
import { CreateThreadModalComponent } from './components/thread-list/create-thread-modal/create-thread-modal.component';
import { ThreadComponent } from './components/thread/thread.component';
import { CreatePostModalComponent } from './components/thread/create-post-modal/create-post-modal.component';

import { AuthService } from "./services/auth.service";
import { PostsService } from "./services/posts.service";
import { JwtUtil } from "./utils/jwt.util";

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    LoginComponent,
    RegisterComponent,
    ThreadListComponent,
    ThreadComponent,
    CreateThreadModalComponent,
    CreatePostModalComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: "ng-cli-universal" }),
    RouterModule.forRoot([
      { path: "", component: HomeComponent, pathMatch: "full" },
      { path: "login", component: LoginComponent },
      { path: "register", component: RegisterComponent },
      { path: "thread/:id", component: ThreadComponent }
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
    PostsService
    ],
  bootstrap: [AppComponent],
  entryComponents: [
    CreateThreadModalComponent,
    CreatePostModalComponent
  ]
})
export class AppModule {
}
