export class AddBook {
    title:string;
    bookCount:number;
    author:string;
    publishedYear:string;
    categoryId:number;
    constructor(title:string,bookCount:number,author:string,publishedYear:string,categoryId:number){
        this.title = title;
        this.bookCount = bookCount;
        this.author = author;
        this.publishedYear = publishedYear;
        this.categoryId = categoryId;
    }
}
