import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';

const BASEAPI_PATH = {
  ENABLED: `enabled`
};

@Injectable()
export abstract class ApiBase<T> {  
  baseUrl!: string;

  protected constructor(protected httpClient: HttpClient) {}

  getAll(filterObject?: any): Observable<T[]> {  
    const queryString = this.buildQueryString(filterObject);
    return this.httpClient.get<T[]>(`${this.baseUrl}${queryString}`);
  }

  getById(id: string, filterObject?: any): Observable<T> { 
    const queryString = this.buildQueryString(filterObject);
    return this.httpClient.get<T>(`${this.baseUrl}/${id}${queryString}`);
  }

  save(payload: T): Observable<T> { 
    return this.httpClient.post<T>(this.baseUrl, payload);
  }

  update(id: string, payload: T): Observable<T> { 
    return this.httpClient.put<T>(`${this.baseUrl}/${id}`, payload);
  }

  delete(id: string): Observable<void> {  
    return this.httpClient.delete<void>(`${this.baseUrl}/${id}`);
  }

  enabled(id: string): Observable<T> {
    return this.httpClient.get<T>(`${this.baseUrl}/${BASEAPI_PATH.ENABLED}/${id}`);
  }

  getEnabledList(filterObject?: any): Observable<T[]> {
    const queryString = this.buildQueryString(filterObject);
    return this.httpClient.get<T[]>(`${this.baseUrl}/${BASEAPI_PATH.ENABLED}${queryString}`);
  }

  private buildQueryString(filterObject?: any): string {
    let queryString = '';
    if (filterObject) {
      const filterKeys = Object.keys(filterObject);
      if (filterKeys.length > 0) {
        queryString = '?';
        filterKeys.forEach(key => {
          if (filterObject[key] !== undefined && filterObject[key] !== null && filterObject[key].toString().length) {
            queryString += `${key}=${filterObject[key]}&`;
          }
        });
        if (queryString.endsWith('&')) {
          queryString = queryString.slice(0, -1);
        }
      }
    }
    return queryString;
  }
}
