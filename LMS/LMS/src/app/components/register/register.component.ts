import { Component } from '@angular/core';
import { Register, RegisterResponseModel } from '../../models/register';
import { AuthService } from '../../services/auth.service';
import { Router } from '@angular/router';
import { FormsModule, NgForm } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [CommonModule,FormsModule],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {
  
    registerModel:Register = new Register('','','');
    errorMsg = '';
    constructor(private authService:AuthService, private route:Router){}
    // ngOnInIt() {}
    loginUser(loginForm:NgForm) {
      this.registerModel = loginForm.value;
      if(this.registerModel.email.trim() !== "" && this.registerModel.userName.trim() !== "" && this.registerModel.password.trim() !== ""){
        this.authService.register(this.registerModel).subscribe({
          next:(response:RegisterResponseModel)=> {
            if(response != null){
              loginForm.reset();
              alert("Registered")
              this.route.navigate(['/'])
            }
          }, error: (error)=> {
            this.errorMsg = JSON.stringify(error.error.message);
            alert(this.errorMsg);
          }
        });
      }
      
    }
}
