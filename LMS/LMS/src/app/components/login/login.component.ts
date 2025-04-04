import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';
import { Login, LoginResponseModel } from '../../models/login';
import { AuthService } from '../../services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  loginModel:Login = new Login('','');
  errorMsg = '';
  constructor(private authService:AuthService, private route:Router){}
  // ngOnInIt() {}
  loginUser(loginForm:NgForm) {
    this.loginModel = loginForm.value;
    if(this.loginModel.email.trim() !== "" && this.loginModel.password.trim() !== ""){
      this.authService.login(this.loginModel).subscribe({
        next:(response:LoginResponseModel)=> {
          localStorage.setItem('token', response.token);
          localStorage.setItem('memberID', response.id);
          localStorage.setItem('email', response.email);
          localStorage.setItem('role',response.role);
          loginForm.reset();
          //alert("Login Successfully");
            this.route.navigate(['/dashboard']);
        }, error: (error)=> {
          this.errorMsg = JSON.stringify(error.error.message);
          alert(this.errorMsg);
        }
      });
    }
    
  }
}
