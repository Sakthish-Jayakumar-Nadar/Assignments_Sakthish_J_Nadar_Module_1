export class Login {
    email:string;
    password:string;
    constructor(email:string,password:string){
        this.email = email;
        this.password = password;
    }
}
export class LoginResponseModel {
    id:string;
    email:string;
    username:string;
    token:string;
    role:string;
    constructor(id:string, email:string, username:string, token:string, role:string) {
        this.id = id;
        this.email = email;
        this.username = username;
        this.token = token;
        this.role = role
    }
}
