import { Routes } from '@angular/router';
import { DashbordComponent } from './components/dashbord/dashbord.component';
import { LoginComponent } from './components/login/login.component';
import { BookDetailComponent } from './components/book-detail/book-detail.component';
import { LoanBooksComponent } from './components/loan-books/loan-books.component';
import { ReturnBooksComponent } from './components/return-books/return-books.component';
import { RequestsComponent } from './components/requests/requests.component';
import { AddBookComponent } from './components/add-book/add-book.component';
import { UpdateBookComponent } from './components/update-book/update-book.component';
import { AdminRequestComponent } from './components/admin-request/admin-request.component';
import { AdminLoanComponent } from './components/admin-loan/admin-loan.component';
import { AllMembersComponent } from './components/all-members/all-members.component';
import { MemberLoansComponent } from './components/member-loans/member-loans.component';
import { AdminBookDetailComponent } from './components/admin-book-detail/admin-book-detail.component';
import { RegisterComponent } from './components/register/register.component';

export const routes: Routes = [
    {path:"",component:LoginComponent},
    {path:"register",component:RegisterComponent},
    {path:"dashboard",component:DashbordComponent},
    {path:"book/detail/:id",component:BookDetailComponent},
    {path:"book/adminDetail/:id",component:AdminBookDetailComponent},
    {path:"book/loaned",component:LoanBooksComponent},
    {path:"book/returned",component:ReturnBooksComponent},
    {path:"book/requests",component:RequestsComponent},
    {path:"book/add",component:AddBookComponent},
    {path:"book/update/:id",component:UpdateBookComponent},
    {path:"book/adminRequest",component:AdminRequestComponent},
    {path:"book/adminLoan",component:AdminLoanComponent},
    {path:"members",component:AllMembersComponent},
    {path:"loaned/:id",component:MemberLoansComponent}
];
