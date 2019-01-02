import { Component } from '@angular/core';

import { AuthService } from './../../services/auth.service';
import { PostsService } from './../../services/posts.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';


@Component({
  selector: 'app-thread-list',
  templateUrl: './thread-list.component.html',
  styleUrls: ["./thread-list.component.css"]
})


export class ThreadListComponent {
  loginForm: FormGroup;
  message: string;

  constructor(
    private authService: AuthService,
    private postService: PostsService
  ) { }

  ngOnInit() {
    this.postService.getThreads(0)
      .subscribe(result => {
        console.log(result);
      })
  }
}
