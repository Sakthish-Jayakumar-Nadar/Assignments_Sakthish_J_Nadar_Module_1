import { Component } from '@angular/core';
import { AddBook } from '../../models/add-book';
import { Router } from '@angular/router';
import { BooksService } from '../../services/books.service';
import { CommonModule } from '@angular/common';
import { FormsModule, NgForm } from '@angular/forms';

@Component({
  selector: 'app-add-book',
  standalone: true,
  imports: [CommonModule,FormsModule],
  templateUrl: './add-book.component.html',
  styleUrl: './add-book.component.css'
})
export class AddBookComponent {
  addModel:AddBook = new AddBook('',1,'','',0);
    errorMsg = '';
    constructor(private bookService:BooksService, private route:Router){}
    // ngOnInIt() {}
    addBook(addBookForm:NgForm) {
      this.addModel = addBookForm.value;
      if(this.addModel.title.trim() !== "" && this.addModel.author.trim() !== "" && this.addModel.bookCount > 0 && this.addModel.categoryId > 0 && this.addModel.publishedYear.trim() !== ""){
        this.bookService.addBook(this.addModel).subscribe({
          next:(response:boolean)=> {
            if(response){
              alert("Added Successfully");
            }
            addBookForm.reset();
          }, error: (error)=> {
            this.errorMsg = JSON.stringify(error.error);
            alert(this.errorMsg);
          }
        });
      }
      
    }
}
