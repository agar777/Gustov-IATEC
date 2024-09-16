import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ApiBase } from '../base-api/api-base';
import { Requests } from '../models/requests.model';

@Injectable({
  providedIn: 'root'
})
export class RequestService extends ApiBase<Requests>{

  constructor(httpClient: HttpClient) {
    super(httpClient);
    this.baseUrl = '/Request'
  }
}
