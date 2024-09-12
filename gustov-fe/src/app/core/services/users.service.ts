import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {map, Observable} from 'rxjs';
import {ApiBase} from "../class/api-base";
import {User} from "../models/user.model";

@Injectable({
  providedIn: 'root'
})
export class UsersService extends ApiBase{

  constructor(httpClient: HttpClient) {
    super(httpClient);
    this.baseUrl = '/users'
  }

  override getAll(filterObject?: any): Observable<User[]> {
    return super.getAll(filterObject).pipe(map((data: any) => data as User[]));
  }

  override getById(id: string, filterObject?: any): Observable<User> {
    return super.getById(id, filterObject).pipe(map((data: any) => data as User));
  }

  override create(payload: User): Observable<User> {
    return super.create(payload).pipe(map((data: any) => data as User));
  }

  override update(id: string, payload: User): Observable<User> {
    return super.update(id, payload).pipe(map((data: any) => data as User));
  }

  override delete(id: string): Observable<void> {
    return super.delete(id).pipe(map((_data: any) => {}));
  }
}
