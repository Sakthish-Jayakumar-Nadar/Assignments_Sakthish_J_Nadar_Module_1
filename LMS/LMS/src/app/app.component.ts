import { Component } from '@angular/core';
import { RouterModule, RouterOutlet } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { NavBarComponent } from './components/nav-bar/nav-bar.component';
import { DashbordComponent } from './components/dashbord/dashbord.component';
import { BookDetailComponent } from './components/book-detail/book-detail.component';
import { ReturnBooksComponent } from './components/return-books/return-books.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet,RouterModule,LoginComponent,NavBarComponent,DashbordComponent,BookDetailComponent,ReturnBooksComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'LMS';
}
