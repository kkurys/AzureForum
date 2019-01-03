import { Component } from '@angular/core';
import { MatDialog } from '@angular/material';

import { AuthService } from './../../services/auth.service';
import { PostsService } from './../../services/posts.service';

import { Post } from '../../models/post.model';
import { PostListing } from '../../models/post-listing.model';

import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-thread',
  templateUrl: './thread.component.html',
  styleUrls: ["./thread.component.css"]
})


export class ThreadComponent {
  message: string;
  isLoggedIn: boolean;
  displayedColumns: string[] = ['topic', 'createdBy', 'createdOn', 'repliesCount'];
  pageSize = 10;
  dataSource = new MatTableDataSource<Post>();
  postListing: PostListing = new PostListing(0, []);

  constructor(
    private authService: AuthService,
    private postService: PostsService,
    private dialog: MatDialog
  ) { }

  ngOnInit() {
    this.isLoggedIn = this.authService.isLoggedIn();
    this.getPosts();
  }

  getPosts(pageNumber = 0, postsPerPage = 10) {
    this.postService.getPosts(pageNumber, postsPerPage)
      .subscribe(result => {
        this.postListing = result;
        this.dataSource = new MatTableDataSource(<Post[]>result.posts);
      });
  }

  pageChanged(pageEvent) {
    this.getPosts(pageEvent.pageIndex, this.pageSize);
  }
}
