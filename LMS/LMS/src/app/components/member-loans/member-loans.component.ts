import { Component } from '@angular/core';
import { Loan } from '../../models/loan';
import { ActivatedRoute } from '@angular/router';
import { BooksService } from '../../services/books.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-member-loans',
  standalone: true,
  imports: [CommonModule,FormsModule],
  templateUrl: './member-loans.component.html',
  styleUrl: './member-loans.component.css'
})
export class MemberLoansComponent {
  status = [["default","blue"],["Loaned","green"],["Returned","green"],["Requested","yellow"],["Accepted","green"],["Expired","red"],["Rejected","maroon"]];
  id?:string|null = null;
  loans:Loan[]=[];
    errorMsg?:string;
    constructor(private bookService:BooksService, private route:ActivatedRoute){}
    ngOnInit(){
      this.route.paramMap.subscribe((params => {
        this.id = params.get('id');
      }));
    this.getMemberLoans();
    }
    getMemberLoans() {
        this.bookService.getMemberLoans(this.id).subscribe({
          next:(response:Loan[])=> {
            this.loans=response;
          }, error: (error)=> {
            this.errorMsg = JSON.stringify(error.error.message);
            alert(this.errorMsg);
        }});
      }
      returnBook(bid?:number,lid?:number,mid?:string){
        this.bookService.returnBook(bid,lid,mid).subscribe({
          next:(response:boolean)=> {
            if(response){
              alert("Book returned");
            }
            else{
              alert("Book unable to return");
            }
          }, error: (error)=> {
            this.errorMsg = JSON.stringify(error.error.message);
            alert(this.errorMsg);
        }});
      }
}
