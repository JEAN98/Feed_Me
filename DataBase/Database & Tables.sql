create database FeedMe
use FeedMe

-------PeriodType--------
create table PeriodType
(
PeriodId int primary Key Identity(1,1),
PeriodName varchar(20),
Number int
)

-------Rol--------
create table Rol
(
RoleId int primary KEy identity(1,1), 
RoleName varchar(20),
Number int
)

-------User--------
create table [User]
(
UserId int primary Key identity(1,1),
Email varchar(20),
Passwordkey varchar(40),
RoleId int foreign key(RoleId) references Rol
)

-------Store--------
create table Store
(
StoreId int Primary key Identity (1,1),
UrlName varchar(30),
CodName varchar(20),
Discount int,
[Percentage] float,
ProductDescription varchar(100),
UserId int foreign key(UserId) references [User],
PeriodId int foreign key(PeriodId) references PeriodType
)

-------FeedBack--------
create table FeedBack
(
FeedBackId int primary key identity(1,1),
StoreId int foreign key(StoreId) references Store,
Face int,
Opinion varchar(200),
CreationDate datetime
)

-------Coupon--------
create table Coupon
(
 CouponId Int primary key Identity (1,1),
 Discount int,
 DiscountDescription varchar(50),
 ActivationStatus int,
 Email Char(20),
 StoreId int foreign key(StoreId) references Store,
 PeriodId int foreign key(PeriodId) references PeriodType
)