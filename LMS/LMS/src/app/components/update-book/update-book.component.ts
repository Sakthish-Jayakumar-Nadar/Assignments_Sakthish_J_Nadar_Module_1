import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, NgForm, ReactiveFormsModule, Validators } from '@angular/forms';
import { AddBook } from '../../models/add-book';
import { BooksService } from '../../services/books.service';
import { Book } from '../../models/book';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-update-book',
  standalone: true,
  imports: [CommonModule,FormsModule,ReactiveFormsModule],
  templateUrl: './update-book.component.html',
  styleUrl: './update-book.component.css'
})
export class UpdateBookComponent {
  id:string | null = null;
  updateModel?:AddBook;
  errorMsg = '';
  updateForm: FormGroup;

  constructor(private fb: FormBuilder, private bookService:BooksService, private route:ActivatedRoute) {
    this.updateForm = fb.group({});
  }

  ngOnInit(): void {
    this.updateForm = this.fb.group({
      id:['',Validators.required],
      title: ['', Validators.required],
      bookCount: ['', [Validators.required, Validators.min(1)]],
      author: ['',Validators.required],
      publishedYear:['',Validators.required],
      categoryId: ['',[Validators.required, Validators.min(1)]]
    });
    this.route.paramMap.subscribe((params => {
      this.id = params.get('id');
    }));
    this.loadFormData();
  }

  loadFormData(): void {
    this.bookService.getBook(this.id).subscribe((data: Book)=>{
      this.updateForm.patchValue(data);
    })
  }

  onSubmit(): void {
    if (this.updateForm.valid) {
      this.updateModel = this.updateForm.value;
      if(this.updateModel){
        this.bookService.updateBook(this.updateModel).subscribe({
          next:(response:Book)=> {
            if(response){
              alert("Updated Successfully");
            }
          }, error: (error)=> {
            this.errorMsg = JSON.stringify(error.error.message);
            alert(this.errorMsg);
          }
        });
      }
      //console.log('Form Data:', this.updateForm.value);
    } else {
      console.log('Form is invalid');
    }
  }
}
