import { Component } from '@angular/core';
import { MatDialog } from '@angular/material';
import { ActivatedRoute } from '@angular/router';

import { AuthService } from './../../services/auth.service';
import { PostsService } from './../../services/posts.service';

import { Post } from '../../models/post.model';
import { PostListing } from '../../models/post-listing.model';

@Component({
  selector: 'app-thread',
  templateUrl: './thread.component.html',
  styleUrls: ["./thread.component.css"]
})


export class ThreadComponent {
  message: string;
  isLoggedIn: boolean;
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
        console.log(result);
      });
  }

  pageChanged(pageEvent) {
    this.getPosts(pageEvent.pageIndex, this.pageSize);
  }
}
