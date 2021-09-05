# VendorAppBackendApi
#database scripts to be run before running the project
CREATE DATABASE VendorDB;
USE VendorDB

CREATE TABLE Products(
ID int Primary key identity(1,1),
Item int,
Description varchar(100),
Cost money
)

Insert into Products values(1,'Coke',0.25)
Insert into Products values(20,'Pepsi',0.35)
Insert into Products values(100,'Sprite',0.45)

Select * from Products

--stored procedure
CREATE Procedure SPSelectProducts
AS
Select * from Products

Exec SPSelectProducts

CREATE TABLE Coins(
ID int Primary key identity,
CoinDescription varchar(100),
Coinvalue money,
)

Insert into Coins values('Nickel',5)
Insert into Coins values('Dime',10)
Insert into Coins values('Quarter',25)

Select * from Coins;

CREATE TABLE OrdersHistory(
ID int Primary key identity,
OrderID int,
ProductID int Foreign Key REFERENCES Products(ID),
OrderDate date,
)


Select * from OrdersHistory;
