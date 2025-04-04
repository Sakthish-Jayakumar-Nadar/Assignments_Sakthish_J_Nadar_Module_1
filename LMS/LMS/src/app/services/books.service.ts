import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Book } from '../models/book';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Loan } from '../models/loan';
import { AddBook } from '../models/add-book';

@Injectable({
  providedIn: 'root'
})
export class BooksService {
  private apiUrl = "https://localhost:7277/api/Book"
  constructor(private http:HttpClient) { }
  getBooks():Observable<Book[]>{
    return this.http.get<Book[]>(this.apiUrl);
  }
  getBook(id:string|null):Observable<Book>{
    return this.http.get<Book>(`${this.apiUrl}/${id}`);
  }
  getLoanBook():Observable<Loan[]>{
    return this.http.get<Loan[]>(`${this.apiUrl}/loan`);
  }
  getReturnBook():Observable<Loan[]>{
    return this.http.get<Loan[]>(`${this.apiUrl}/return`);
  }
  getRequests():Observable<Loan[]>{
    return this.http.get<Loan[]>(`${this.apiUrl}/request`);
  }
  getAdminRequests():Observable<Loan[]>{
    return this.http.get<Loan[]>(`${this.apiUrl}/requests`);
  }
  borrowRequest(id?:number):Observable<boolean>{
    return this.http.post<boolean>(`${this.apiUrl}/${id}/borrow`,{});
  }
  borrowRequestAccept(id?:number,lid?:number,mid?:string):Observable<boolean>{
    return this.http.post<boolean>(`${this.apiUrl}/${id}/member/${mid}/accept/${lid}`,{});
  }
  borrowRequestReject(id?:number,lid?:number,mid?:string):Observable<boolean>{
    return this.http.post<boolean>(`${this.apiUrl}/${id}/member/${mid}/reject/${lid}`,{});
  }
  addBook(bookData:AddBook):Observable<boolean> {
    return this.http.post<boolean>(`${this.apiUrl}`,bookData);
  }
  updateBook(bookData:AddBook):Observable<Book> {
    return this.http.put<Book>(`${this.apiUrl}`,bookData);
  }
  loanBook(id?:number,email?:string):Observable<boolean>{
    return this.http.post<boolean>(`${this.apiUrl}/${id}/loan/${email}`,{});
  }
  returnBook(id?:number,lid?:number,mid?:string):Observable<boolean>{
    return this.http.post<boolean>(`${this.apiUrl}/${id}/member/${mid}/return/${lid}`,{});
  }
  getMemberLoans(id?:string|null):Observable<Loan[]>{
    return this.http.get<Loan[]>(`${this.apiUrl}/member/${id}/loans`);
  }
}
