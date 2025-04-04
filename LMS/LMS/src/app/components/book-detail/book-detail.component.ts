import { Component } from '@angular/core';
import { Book } from '../../models/book';
import { BooksService } from '../../services/books.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-book-detail',
  standalone: true,
  imports: [],
  templateUrl: './book-detail.component.html',
  styleUrl: './book-detail.component.css'
})
export class BookDetailComponent {
  book:Book= new Book()
  id:string | null = null;
  borrowSent?:boolean;
  errorMsg?:string;
  constructor(private bookService:BooksService, private route:ActivatedRoute){}
  ngOnInit(){
    this.route.paramMap.subscribe((params => {
      this.id = params.get('id');
    }));
    this.getBook();
  }
  getBook() {
    this.bookService.getBook(this.id).subscribe((data: Book)=>{
      this.book=data; 
    })
  }
  borrowRequest(id?:number):void{
    this.bookService.borrowRequest(id).subscribe({
      next:(response:boolean)=> {
        if(response){
          alert("Request sent successfully");
        }
        else{
          alert("Book already request Or loaned")
        }
      }, error: (error)=> {
        this.errorMsg = JSON.stringify(error.error.message);
        alert(this.errorMsg);
      }
    })
  }
}
