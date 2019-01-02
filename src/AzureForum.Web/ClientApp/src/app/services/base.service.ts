import { Inject, Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import 'rxjs/add/operator/map'


@Injectable()
export class BaseService {
  protected headers: HttpHeaders;
  protected http: HttpClient;
  protected baseUrl: string;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.headers = new HttpHeaders({
      'Authorization': 'Bearer ' + localStorage.getItem('token')
    });

    this.http = http;
    this.baseUrl = baseUrl + 'api/';
  }
}
