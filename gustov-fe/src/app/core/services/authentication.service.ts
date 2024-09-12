import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  constructor(
    private http: HttpClient,
  ) { }

  login(credentials: { username: string, password: string }):Observable<any> {
    return this.http.post<any>('/login', credentials, httpOptions);
  }

  logout() {    
    return this.http.get<any>('/logout')
  }
  
}
