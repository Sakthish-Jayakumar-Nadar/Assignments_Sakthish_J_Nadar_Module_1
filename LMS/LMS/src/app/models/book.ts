import { Category } from "./category";

export class Book {
    id?:number;
    title?:string;
    bookCount?:number;
    author?:string;
    publishedYear?:string;
    categoryId?:number;
    category?:Category;
}
