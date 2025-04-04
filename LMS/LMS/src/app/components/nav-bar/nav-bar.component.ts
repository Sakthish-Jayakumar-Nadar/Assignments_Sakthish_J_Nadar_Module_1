import { Component } from '@angular/core';
import { Router, RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-nav-bar',
  standalone: true,
  imports: [RouterModule,CommonModule,FormsModule],
  templateUrl: './nav-bar.component.html',
  styleUrl: './nav-bar.component.css'
})
export class NavBarComponent {
  constructor(private route:Router){

  }
  ngOnInit(){
  }
  isLogIn():boolean {
    if(localStorage.getItem('token') != null)
      return true;
    return false;
  }
  isAdmin():boolean {
    if(localStorage.getItem('role') == 'librarian')
      return true;
    return false;
  }
  logout():void {
    localStorage.clear();
    this.route.navigate(['/']);
  }
}
