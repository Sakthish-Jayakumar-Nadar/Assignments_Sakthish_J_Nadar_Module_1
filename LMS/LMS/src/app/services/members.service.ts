import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Member } from '../models/member';

@Injectable({
  providedIn: 'root'
})
export class MembersService {
private apiUrl = "https://localhost:7277/api/Member"
  constructor(private http:HttpClient) { }
  getMembers():Observable<Member[]>{
    return this.http.get<Member[]>(this.apiUrl);
  }
}
