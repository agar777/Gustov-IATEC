import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ApiBase } from '../base-api/api-base';
import { Vacation } from '../models/vacation.model';

@Injectable({
  providedIn: 'root'
})
export class VacationService extends ApiBase<any>{

  constructor(httpClient: HttpClient) {
    super(httpClient);
    this.baseUrl = '/Vacation'
  }
}
