--creating DataBase
CREATE DATABASE BookStoreDB

--drop database
DROP DATABASE BookStoreDB

--using BookStoreDB
USE BookStoreDB


--creating author table
CREATE TABLE Authors 
(
	AuthorId INT IDENTITY PRIMARY KEY,
	Name VARCHAR(20) NOT NULL,
	Country VARCHAR(20) NOT NULL
)

--creating book table
CREATE TABLE Books
(
	BookId INT IDENTITY PRIMARY KEY,
	Title VARCHAR(30) NOT NULL,
	AuthorId INT NOT NULL,
	Price INT NOT NULL,
	PublishedYear INT NOT NULL
)

--creating customer table
CREATE TABLE Customers
(
	CustomerId INT IDENTITY PRIMARY KEY,
	Name VARCHAR(20) NOT NULL,
	Email VARCHAR(100),
	PhoneNumber	BIGINT,
)

--creating order table
CREATE TABLE Orders 
(
	OrderId INT IDENTITY PRIMARY KEY,
	CustomerId INT NOT NULL,
	OrderDate DATE NOT NULL,
	TotalAmount DECIMAL(10,2) NOT NULL,
)

--creating orderitem table
CREATE TABLE OrderItems
(
	OrderItemId INT IDENTITY PRIMARY KEY,
	OrderId INT NOT NULL,
	BookId INT NOT NULL,
	Quantity INT NOT NULL,
	SubTotal DECIMAL(10,2) NOT NULL
)

--reference between book and author
ALTER TABLE Books ADD CONSTRAINT FK_Books_AuthorId FOREIGN KEY (AuthorId) REFERENCES Authors(AuthorId)

--reference order book and customer
ALTER TABLE Orders ADD CONSTRAINT FK_Orders_CustomerId FOREIGN KEY (CustomerId) REFERENCES Customers(CustomerId)

--reference between orderitem and order
ALTER TABLE OrderItems ADD CONSTRAINT FK_OrderItems_OrderId FOREIGN KEY (OrderId) REFERENCES Orders(OrderId)

--reference between orderitem and book
ALTER TABLE OrderItems ADD CONSTRAINT FK_OrderItems_BookId FOREIGN KEY (BookId) REFERENCES Books(BookId)

--to truncate the customers orders and orderItems table
ALTER TABLE Books DROP CONSTRAINT FK_Books_AuthorId;
ALTER TABLE Orders DROP CONSTRAINT FK_Orders_CustomerId;
ALTER TABLE OrderItems DROP CONSTRAINT FK_OrderItems_OrderId;
ALTER TABLE OrderItems DROP CONSTRAINT FK_OrderItems_BookId;
TRUNCATE TABLE Customers
TRUNCATE TABLE Orders
TRUNCATE TABLE OrderItems

--inserting 5 data into authors table
INSERT INTO Authors VALUES
('Alex', 'USA'),
('John', 'British'),
('Mikel', 'USA'),
('Andrus', 'Germany'),
('Lilly', 'Russia')

--inserting 5 data into books table
INSERT INTO Books VALUES
('Hello World',1,100,'2020'),
('Progamming',2,300,'2019'),
('SQL Mastery',3, 200, '2023'),
('Why me',4,150,'2021'),
('U Turn',5,250,'2017'),
('GO CORONA',1,2500,'2020')


--inserting 5 data into customer table
INSERT INTO Customers VALUES
('Om','om@gmail.com',9876543210),
('Auti','auti@gmail.com',8765432109),
('Rahul','rahul@gamil.com',null),
('Sartak',null,7654321098),
('Sreekant',null,null),
('Demo',null,null)

--inserting 5 data into order table
INSERT INTO Orders VALUES
(1,'3/6/2020',100),
(2,'6/3/2019',300),
(3,'9/6/2023',200),
(4,'6/9/2021',2500),
(5,'12/12/2017',450),
(5,'12/12/2017',450)

--inserting 5 data into orderItems table
INSERT INTO OrderItems VALUES
(1,1,1,100),
(2,2,1,300),
(3,3,1,200),
(4,4,1,150),
(5,5,1,250),
(6,5,1,200)


-- Update the price of a book titled "SQL Mastery" by increasing it by 10%.
UPDATE Books SET Price = Price * 1.1 WHERE Title = 'SQL Mastery'
UPDATE Books SET Price = 2500 WHERE BookId = 4
UPDATE Books SET PublishedYear = 2012 WHERE BookId = 5

--display all tables
SELECT * FROM Books
SELECT * FROM Customers
SELECT * FROM Authors
SELECT * FROM Orders
SELECT * FROM OrderItems

-- Delete a customer who has not placed any orders. 
DELETE Customers FROM Customers Left join Orders on Customers.CustomerId = Orders.CustomerId WHERE OrderId IS NULL

INSERT INTO Customers VALUES ('Demo',null,null)

--Retrieve all books with a price greater than 2000.
SELECT * FROM Books WHERE Price > 2000

--Find the total number of books available. 
SELECT COUNT(BookId) FROM Books

--Find books published between 2015 and 2023. 
SELECT * FROM Books WHERE PublishedYear BETWEEN 2015 AND 2023

--Find all customers who have placed at least one order. 
SELECT distinct(Name) FROM Customers JOIN Orders ON Customers.CustomerId = Orders.CustomerId

--Retrieve books where the title contains the word "SQL".
SELECT * FROM Books WHERE Title LIKE '%SQL%'

--Find the most expensive book in the store. 
DECLARE @MAXPRICE INT
SELECT @MAXPRICE = MAX(Price) FROM Books
SELECT * FROM Books WHERE Price = @MAXPRICE

--Retrieve customers whose name starts with "A" or "J". 
SELECT * FROM Customers WHERE Name LIKE '[A J]%'

--Calculate the total revenue from all orders. 
SELECT SUM(TotalAmount) AS TotalRevenue FROM Orders

--Retrieve all book titles along with their respective author names.
SELECT Title, Authors.Name AS Author FROM Books JOIN Authors ON Books.AuthorId = Authors.AuthorId

--List all customers and their orders (if any). 
SELECT * FROM Customers LEFT JOIN Orders ON Customers.CustomerId = Orders.CustomerId

--Find all books that have never been ordered.
SELECT Books.BookId, Books.Title FROM Books LEFT JOIN OrderItems ON OrderItems.BookId = Books.BookId WHERE OrderItemId IS NULL

--Retrieve the total number of orders placed by each customer. 
SELECT CustomerId, COUNT(OrderId) AS TotalOrdersPlace FROM Orders GROUP BY CustomerId

--Find the books ordered along with the quantity for each order. 
SELECT * FROM OrderItems JOIN Books ON OrderItems.BookId = Books.BookId 

--Display all customers, even those who haven’t placed any orders.
SELECT * FROM Customers LEFT JOIN Orders ON Customers.CustomerId = Orders.CustomerId

--Find authors who have not written any books 
SELECT * FROM Authors LEFT JOIN Books ON Authors.AuthorId = Books.AuthorId WHERE BookId IS NULL

--Find the customer(s) who placed the first order (earliest OrderDate).  
SELECT NAME, (SELECT MIN(OrderDate) FROM Orders ) AS [DATE] FROM Customers WHERE CustomerId IN (SELECT CustomerId FROM Orders WHERE OrderDate = (SELECT MIN(OrderDate) FROM Orders ))

--Find the customer(s) who placed the most orders.
DECLARE @MaxOrderCount int
SELECT @MaxOrderCount = MAX(MAXORDER) FROM (SELECT COUNT(OrderId) AS [MAXORDER] FROM Orders GROUP BY CustomerId)INNERTABLE
SELECT * FROM Customers WHERE CustomerId IN (SELECT CustomerId FROM Orders GROUP BY CustomerId HAVING COUNT(OrderId) = @MaxOrderCount)

--Find customers who have not placed any orders.
SELECT * FROM Customers WHERE CustomerId NOT IN (SELECT CustomerId FROM Orders)

--Retrieve all books cheaper than the most expensive book written by(any author based on your data) 
SELECT * FROM Books WHERE Price < (SELECT MAX(Price) FROM Books)

--List all customers whose total spending is greater than the average spending of all customers
SELECT Customers.CustomerId, Name, TotalAmount FROM Customers JOIN Orders ON Customers.CustomerId = Orders.CustomerId WHERE Customers.CustomerId IN (SELECT CustomerId FROM Orders WHERE TotalAmount >(SELECT AVG(TotalAmount) FROM Orders))

--Write a stored procedure that accepts a CustomerID and returns all orders placed by that customer 
CREATE PROC OrderDetailByCustomerId 
@Id int
AS
BEGIN
	SELECT * FROM Orders WHERE CustomerId = @Id
END

EXEC OrderDetailByCustomerId 3

--Create a procedure that accepts MinPrice and MaxPrice as parameters and returns all books within that range
CREATE PROC GetBookByMinAndMaxPrice
@MinPrice int,
@MaxPrice int
AS
BEGIN 
	SELECT * FROM Books WHERE Price BETWEEN @MinPrice AND @MaxPrice
END

EXEC GetBookByMinAndMaxPrice 100, 250


--Create a view named that shows only books that are publicded after 2015, including BookID, Title, AuthorID, Price, and PublishedYear 
CREATE VIEW BookPublishedBefore2015
AS
	SELECT * FROM Books WHERE PublishedYear > 2015

SELECT * FROM BookPublishedBefore2015
