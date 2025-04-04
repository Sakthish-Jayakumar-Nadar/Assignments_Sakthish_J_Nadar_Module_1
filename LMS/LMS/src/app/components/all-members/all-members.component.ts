import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Member } from '../../models/member';
import { MembersService } from '../../services/members.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-all-members',
  standalone: true,
  imports: [CommonModule,FormsModule],
  templateUrl: './all-members.component.html',
  styleUrl: './all-members.component.css'
})
export class AllMembersComponent {
  members:Member[]=[];
    errorMsg?:string;
    constructor(private membersService:MembersService, private route:Router){}
    ngOnInit(){
    this.getRequests();
    }
    getRequests() {
        this.membersService.getMembers().subscribe({
          next:(response:Member[])=> {
            this.members=response;
            console.log(response);
          }, error: (error)=> {
            this.errorMsg = JSON.stringify(error.error.message);
            alert(this.errorMsg);
        }});
      }
      goto(mid:string){
        this.route.navigate(['/loaned/'+mid]);
      }
}
