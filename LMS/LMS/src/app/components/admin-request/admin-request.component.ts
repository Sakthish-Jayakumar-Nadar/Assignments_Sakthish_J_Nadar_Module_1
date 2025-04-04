import { Component } from '@angular/core';
import { Loan } from '../../models/loan';
import { BooksService } from '../../services/books.service';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-admin-request',
  standalone: true,
  imports: [CommonModule,FormsModule],
  templateUrl: './admin-request.component.html',
  styleUrl: './admin-request.component.css'
})
export class AdminRequestComponent {
  status = [["default","blue"],["Loaned","green"],["Returned","green"],["Requested","yellow"],["Accepted","green"],["Expired","red"],["Rejected","maroon"]];
  loans:Loan[]=[];
    errorMsg?:string;
    constructor(private bookService:BooksService, private route:Router){}
    ngOnInit(){
    this.getRequests();
    }
    getRequests() {
        this.bookService.getAdminRequests().subscribe({
          next:(response:Loan[])=> {
            this.loans=response;
          }, error: (error)=> {
            this.errorMsg = JSON.stringify(error.error);
            alert(this.errorMsg);
        }});
      }
      accept(id?:number,lid?:number,mid?:string){
        this.bookService.borrowRequestAccept(id,lid,mid).subscribe({
          next:(response:boolean)=> {
          }, error: (error)=> {
            this.errorMsg = JSON.stringify(error.error);
            alert(this.errorMsg);
        }});
      }
      reject(id?:number,lid?:number,mid?:string){
        this.bookService.borrowRequestReject(id,lid,mid).subscribe({
          next:(response:boolean)=> {
          }, error: (error)=> {
            this.errorMsg = JSON.stringify(error.error);
            alert(this.errorMsg);
        }});
      }
}
