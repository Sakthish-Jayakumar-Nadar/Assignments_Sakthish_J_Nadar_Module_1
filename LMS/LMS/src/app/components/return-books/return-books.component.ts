import { Component } from '@angular/core';
import { Loan } from '../../models/loan';
import { BooksService } from '../../services/books.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-return-books',
  standalone: true,
  imports: [],
  templateUrl: './return-books.component.html',
  styleUrl: './return-books.component.css'
})
export class ReturnBooksComponent {
  loans:Loan[]=[]
  errorMsg?:string;
  constructor(private bookService:BooksService, private route:Router){}
  ngOnInit(){
  this.getReturnBook();
  }
  getReturnBook() {
    this.bookService.getReturnBook().subscribe({
      next:(response:Loan[])=> {
        this.loans=response;
          console.log(response);
      }, error: (error)=> {
        this.errorMsg = JSON.stringify(error.error.message);
        alert(this.errorMsg);
    }});
  }
}
