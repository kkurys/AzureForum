import { Inject, Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import 'rxjs/add/operator/map'
import { BaseService } from './base.service';

import { ThreadListing } from '../models/thread-listing.model';

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
}
