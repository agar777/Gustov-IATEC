import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {User} from "../models/user.model";
import { ApiBase } from '../base-api/api-base';
import { Employee } from '../models/employee.model';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService extends ApiBase<Employee>{

  constructor(httpClient: HttpClient) {
    super(httpClient);
    this.baseUrl = '/Employee'
  }
}
