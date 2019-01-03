import { Inject, Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import 'rxjs/add/operator/map'
import { BaseService } from './base.service';

import { ThreadListing } from '../models/thread-listing.model';
import { PostListing } from '../models/post-listing.model';

import { CreatePostRequest } from '../models/requests/create-post-request.model';
import { CreateThreadRequest } from '../models/requests/create-thread-request.model';


@Injectable()
export class PostsService extends BaseService {
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    super(http, baseUrl);
  }

  getThreads(page, postsPerPage = 10) {
    let url = this.baseUrl + 'Posts/GetThreads';

    let params = new HttpParams()
      .set("page", page)
      .set("postsPerPage", postsPerPage.toString());

    return this.http.get<ThreadListing>(url, { params: params, headers: this.headers });
  }

  getPosts(threadId, page, postsPerPage = 10) {
    let url = this.baseUrl + 'Posts/GetThreadPosts';

    let params = new HttpParams()
      .set("page", page)
      .set("postsPerPage", postsPerPage.toString())
      .set("threadId", threadId);

    return this.http.get<PostListing>(url, { params: params, headers: this.headers });
  }

  createThread(topic: string, content: string) {
    let url = this.baseUrl + "Posts/CreateThread";

    let body = new CreateThreadRequest(topic, content);
    return this.http.post(url, body, { headers: this.headers });
  }

  createPost(threadId: string, content: string) {
    let url = this.baseUrl + "Posts/CreatePost";

    let body = new CreatePostRequest(threadId, content);
    return this.http.post(url, body, { headers: this.headers });
  }
}
