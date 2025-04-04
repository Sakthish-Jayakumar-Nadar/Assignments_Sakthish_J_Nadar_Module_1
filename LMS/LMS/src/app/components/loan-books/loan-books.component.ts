import { Component } from '@angular/core';
import { BooksService } from '../../services/books.service';
import { Router } from '@angular/router';
import { Loan } from '../../models/loan';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-loan-books',
  standalone: true,
  imports: [CommonModule,FormsModule],
  templateUrl: './loan-books.component.html',
  styleUrl: './loan-books.component.css'
})
export class LoanBooksComponent {
  loans:Loan[]=[];
  errorMsg?:string;
  constructor(private bookService:BooksService, private route:Router){}
  ngOnInit(){
  this.getLoanBook();
  }
  getLoanBook() {
      this.bookService.getLoanBook().subscribe({
        next:(response:Loan[])=> {
          this.loans=response;
          console.log(response);
        }, error: (error)=> {
          this.errorMsg = JSON.stringify(error.error.message);
          alert(this.errorMsg);
      }});
    }
}
