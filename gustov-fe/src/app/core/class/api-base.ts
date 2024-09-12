import {HttpClient} from "@angular/common/http";
import {Injectable} from "@angular/core";
import {map, Observable} from "rxjs";

const BASEAPI_PATH = {
  ENABLED: `enabled`
};

@Injectable()
export abstract class ApiBase{
  baseUrl!: string;
  models!: any;

  protected constructor(protected httpClient: HttpClient) {
  }

  getAll(filterObject?: any): Observable<any> {
    const queryString = this.buildQueryString(filterObject);
    return this.httpClient.get(`${this.baseUrl}${queryString}`).pipe(map((body: any) => body));
  }

  getById(id: string, filterObject?: any): Observable<any> {
    const queryString = this.buildQueryString(filterObject);
    return this.httpClient.get(`${this.baseUrl}/${id}${queryString}`).pipe(map((body: any) => body));
  }

  create(payload: any): Observable<any> {
    return this.httpClient.post(this.baseUrl, payload).pipe(map((body: any) => body));
  }

  update(id: string, payload: any): Observable<any> {
    return this.httpClient.put(`${this.baseUrl}/${id}`, payload).pipe(map((body: any) => body));
  }

  delete(id: string): Observable<any> {
    return this.httpClient.delete(`${this.baseUrl}/${id}`).pipe(map((body: any) => body));
  }

  enabled(id: string): Observable<any> {
    return this.httpClient.get(`${this.baseUrl}/${BASEAPI_PATH.ENABLED}/${id}`).pipe(map((body: any) => body));
  }

  getEnabledList(filterObject?: any): Observable<any> {
    const queryString = this.buildQueryString(filterObject);
    return this.httpClient.get(`${this.baseUrl}/${BASEAPI_PATH.ENABLED}${queryString}`).pipe(map((body: any) => body));
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
