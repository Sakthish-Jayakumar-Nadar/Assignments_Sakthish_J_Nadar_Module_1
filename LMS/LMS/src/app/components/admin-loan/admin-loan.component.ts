import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { BooksService } from '../../services/books.service';
import { AddBook } from '../../models/add-book';
import { Book } from '../../models/book';

@Component({
  selector: 'app-admin-loan',
  standalone: true,
  imports: [CommonModule,FormsModule,ReactiveFormsModule],
  templateUrl: './admin-loan.component.html',
  styleUrl: './admin-loan.component.css'
})
export class AdminLoanComponent {
  errorMsg = '';
  updateForm: FormGroup;

  constructor(private fb: FormBuilder, private bookService:BooksService) {
    this.updateForm = fb.group({});
  }

  ngOnInit(): void {
    this.updateForm = this.fb.group({
      email:['',Validators.required],
      id: ['', [Validators.required, Validators.min(1)]]
    });
  }

  onSubmit(): void {
    if (this.updateForm.valid) {
        this.bookService.loanBook(this.updateForm.get('id')?.value, this.updateForm.get('email')?.value).subscribe({
          next:(response:boolean)=> {
            if(response){
              alert("Loaned Successfully");
            }
            else{
              alert("Book already loaned");
            }
            this.updateForm.reset();
          }, error: (error)=> {
            this.errorMsg = JSON.stringify(error.error.message);
            alert(this.errorMsg);
          }
        });
      //console.log('Form Data:', this.updateForm.value);
    } else {
      console.log('Form is invalid');
    }
  }

}
