import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { Book } from '../../models/book';
import { BooksService } from '../../services/books.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-dashbord',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './dashbord.component.html',
  styleUrl: './dashbord.component.css'
})
export class DashbordComponent {
  books:Book[]=[]
constructor(private bookService:BooksService, private route:Router){}
ngOnInit(){
this.getBooks();
}
  getBooks() {
    this.bookService.getBooks().subscribe((data: Book[])=>{
      this.books=data;
    })
  }
  goTo(id?:number):void{
    if(localStorage.getItem("role") == "librarian"){
      this.route.navigate([`/book/adminDetail/${id}`]);
    }
    else{
      this.route.navigate([`/book/detail/${id}`]);
    }
  }
}
