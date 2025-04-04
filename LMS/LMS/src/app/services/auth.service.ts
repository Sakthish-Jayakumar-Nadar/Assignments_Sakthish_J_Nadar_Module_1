import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Login, LoginResponseModel } from '../models/login';
import { Observable } from 'rxjs';
import { RegisterResponseModel } from '../models/register';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private apiUrl = "https://localhost:7277/api/Auth"
  constructor(private http:HttpClient) { }

  login(loginData:Login):Observable<LoginResponseModel> {
    return this.http.post<LoginResponseModel>(`${this.apiUrl}/login`,loginData);
  }
  register(loginData:Login):Observable<RegisterResponseModel> {
    return this.http.post<RegisterResponseModel>(`${this.apiUrl}/register`,loginData);
  }
}
