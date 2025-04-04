import { Component } from '@angular/core';
import { Loan } from '../../models/loan';
import { BooksService } from '../../services/books.service';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-requests',
  standalone: true,
  imports: [CommonModule,FormsModule],
  templateUrl: './requests.component.html',
  styleUrl: './requests.component.css'
})
export class RequestsComponent {
status = [["default","blue"],["Loaned","green"],["Returned","green"],["Requested","yellow"],["Accepted","green"],["Expired","red"],["Rejected","maroon"]];
loans:Loan[]=[];
  errorMsg?:string;
  constructor(private bookService:BooksService, private route:Router){}
  ngOnInit(){
  this.getRequests();
  }
  getRequests() {
      this.bookService.getRequests().subscribe({
        next:(response:Loan[])=> {
          this.loans=response;
          console.log(response);
        }, error: (error)=> {
          this.errorMsg = JSON.stringify(error.error.message);
          alert(this.errorMsg);
      }});
    }
}
