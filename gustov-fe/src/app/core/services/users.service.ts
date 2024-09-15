import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {User} from "../models/user.model";
import { ApiBase } from '../base-api/api-base';

@Injectable({
  providedIn: 'root'
})
export class UsersService extends ApiBase<User>{

  constructor(httpClient: HttpClient) {
    super(httpClient);
    this.baseUrl = '/User'
  }
}
