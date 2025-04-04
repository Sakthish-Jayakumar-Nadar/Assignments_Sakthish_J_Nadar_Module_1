import { Component } from '@angular/core';
import { Book } from '../../models/book';
import { BooksService } from '../../services/books.service';
import { ActivatedRoute, Route, Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-admin-book-detail',
  standalone: true,
  imports: [CommonModule,FormsModule],
  templateUrl: './admin-book-detail.component.html',
  styleUrl: './admin-book-detail.component.css'
})
export class AdminBookDetailComponent {
  book:Book= new Book()
    id:string | null = null;
    borrowSent?:boolean;
    errorMsg?:string;
    constructor(private bookService:BooksService, private route:ActivatedRoute, private nrouter:Router){}
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
    goto(id?:number):void{
      this.nrouter.navigate([`book/update/${id}`]);
    }
}
