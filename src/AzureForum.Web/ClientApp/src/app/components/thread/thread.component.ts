import { Component, ViewChild } from '@angular/core';
import { MatDialog, MatPaginator } from '@angular/material';
import { ActivatedRoute } from '@angular/router';

import { AuthService } from './../../services/auth.service';
import { PostsService } from './../../services/posts.service';

import { Post } from '../../models/post.model';
import { PostListing } from '../../models/post-listing.model';

import { CreatePostModalComponent } from './create-post-modal/create-post-modal.component';


@Component({
  selector: 'app-thread',
  templateUrl: './thread.component.html',
  styleUrls: ["./thread.component.css"]
})


export class ThreadComponent {
  @ViewChild(MatPaginator) paginator: MatPaginator;
  message: string;
  isLoggedIn: boolean;
  displayNewPostButton: boolean;
  pageSize = 10;
  postListing: PostListing = new PostListing("", 0, []);
  threadId: string;
  constructor(
    private authService: AuthService,
    private postService: PostsService,
    private dialog: MatDialog,
    private route: ActivatedRoute
  ) { }

  ngOnInit() {
    this.isLoggedIn = this.authService.isLoggedIn();
    this.threadId = this.route.snapshot.paramMap.get('id');
    this.getPosts();
  }

  getPosts(pageNumber = 0, postsPerPage = 10) {
    this.postService.getPosts(this.threadId, pageNumber, postsPerPage)
      .subscribe(result => {
        this.postListing = result;
        if (pageNumber === this.calculateLastPageIndex(this.postListing.totalCount)) {
          this.displayNewPostButton = true;
        } else {
          this.displayNewPostButton = false;
        }
        this.paginator.pageIndex = pageNumber;
      });
  }

  pageChanged(pageEvent) {
    this.getPosts(pageEvent.pageIndex, this.pageSize);
  }
  openCreatePostModal() {
    const dialogRef =
      this.dialog
        .open(CreatePostModalComponent, {
          height: 'auto',
          width: '400px',
          data: {
            threadId: this.threadId
          }
        })
        .afterClosed()
        .subscribe(result => {
            if (result === "ok") {
              this.getPosts(this.calculateLastPageIndex(this.postListing.totalCount + 1), this.pageSize);
            }
          }
        );
  }
  calculateLastPageIndex(count) {
    let result = Math.floor((count + this.pageSize - 1) / (this.pageSize)) - 1;
    return result;
  }
}
