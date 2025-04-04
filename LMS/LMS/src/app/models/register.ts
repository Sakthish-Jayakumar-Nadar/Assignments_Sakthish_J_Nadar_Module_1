export class Register {
    email:string;
    userName:string;
    password:string;
    constructor(email:string, userName:string, password:string) {
        this.email = email;
        this.userName = userName;
        this.password = password;
    }
}

export class RegisterResponseModel {
    userId:string;
    constructor(userId:string) {
        this.userId = userId;
    }
}
