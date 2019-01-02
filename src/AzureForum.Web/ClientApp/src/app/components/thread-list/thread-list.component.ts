import { Component, ViewChild } from '@angular/core';
import { MatTable } from '@angular/material';
import { MatDialog } from '@angular/material';

import { AuthService } from './../../services/auth.service';
import { PostsService } from './../../services/posts.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';

import { CreateThreadModalComponent } from './create-thread-modal/create-thread-modal.component';
import { ThreadListing } from '../../models/thread-listing.model';
import { PostThread } from '../../models/post-thread.model';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-thread-list',
  templateUrl: './thread-list.component.html',
  styleUrls: ["./thread-list.component.css"]
})


export class ThreadListComponent {
  loginForm: FormGroup;
  message: string;
  threadListing: ThreadListing = new ThreadListing(0, []);
  isLoggedIn: boolean;
  displayedColumns: string[] = ['topic', 'createdBy', 'createdOn', 'repliesCount'];
  dataSource = new MatTableDataSource<PostThread>();
  constructor(
    private authService: AuthService,
    private postService: PostsService,
    private dialog: MatDialog
  ) { }

  ngOnInit() {
    this.isLoggedIn = this.authService.isLoggedIn();
    this.getThreads();
  }
  createThread() {
    const dialogRef =
      this.dialog
        .open(CreateThreadModalComponent, {
          height: 'auto',
          width: '400px',
        })
        .afterClosed()
        .subscribe(result => this.getThreads());
  }
  getThreads() {
    this.postService.getThreads(0)
      .subscribe(result => {
        this.threadListing = result;
        this.dataSource = new MatTableDataSource(<PostThread[]>result.postThreads);
      });
  }
}
