
---------------- methods--------------------------------------
-------------------------Type period-------------------
create procedure insert_Period
@Name_perido varchar(20),
@number int
as 
insert type_period values(@Name_perido,@number)

create procedure modify_Period
@ID_period int,
@Name_period varchar(20),
@number int 

as 
update type_period
set 
Name_perido=@Name_period,number=@number
where ID_periodo=@ID_period

create procedure delete_period
@ID_period int
as
delete from type_period
where ID_periodo=@ID_period

-----------------------------------Role--------------
create procedure Insert_Role
@name_role varchar(20),
@number int
as
insert Roles values(@name_role,@number)

create procedure modify_Role
@Id_Role int,
@name_role varchar(20),
@number int
as
update Roles
set
name_role=@name_role,number=@number
where ID_Role=@Id_Role

create procedure delete_Role
@ID_role int
as
delete from Roles
where ID_Role=@ID_role


------------------------Users--------
create procedure Insert_Users
@email varchar(20),
@password_key varchar(40),
@ID_Role int 
as
Insert Users values(@email,@password_key,@ID_Role)

create procedure Modify_Users
@ID_User int,
@email varchar(20),
@password_key varchar(40),
@ID_Role int 
as
update Users
set
email=@email,password_key=@password_key,ID_Role=@ID_Role
where ID_user=@ID_User

create procedure Delete_Users
@ID_users int
as
delete Users
where ID_user=@ID_users

create procedure all_UsersTables
as
select*from Users

--------------------------------Store-----------------
create procedure insert_store
@Name_url varchar(30),
@codName varchar(20),
@Discount int,
@porcent float,
@description_product varchar(100),
@ID_user int,
@ID_periodo int
as
insert Store values(@Name_url,@codName,@Discount,@porcent,@description_product,@ID_user,@ID_periodo)

create procedure modify_Store
@ID_Store int,
@Name_url varchar(30),
@codName varchar(20),
@Discount int,
@porcent float,
@description_product varchar(100),
@ID_user int,
@ID_periodo int
as
update Store
set Name_url=@Name_url,codName=@codName,Discount=@Discount,porcent=@porcent,description_product=@description_product,ID_user=@ID_user,ID_periodo=@ID_periodo
where ID_store=@ID_Store

create procedure delete_Store
@ID_STORE int
as
delete Store
where ID_store=@ID_STORE

create procedure all_storeTables
as
select * from Store

------------------------------Coupon---------------
create procedure insert_Coupon
 @Descount int,
 @description_discount varchar(50),
 @Activation_status int,
 @Email Char(20),
 @ID_store int,
 @ID_period int
 as
 insert Coupon Values(@Descount,@description_discount,@Activation_status,@Email,@ID_store,@ID_period)

create procedure modify_Coupon
 @ID_Coupon int,
 @Descount int,
 @description_discount varchar(50),
 @Activation_status int,
 @Email Char(20),
 @ID_store int,
 @ID_period int
 as
 update Coupon
 set Descount=@Descount,description_discount=@description_discount,Activation_status=@Activation_status,Email=@Email,ID_store=@ID_store,ID_period=@ID_period
 where ID_Coupon=@ID_Coupon

 create procedure Delete_coupon
 @ID_Copun int
 as
 delete Coupon
 where ID_Coupon=@ID_Copun

 -----------------------------------FEED-Back---------------------
create procedure Insert_FeedBack
@ID_Store int,
@Face int,
@opinion varchar(200),
@creationDate datetime
as
insert [Feed Back] values(@ID_Store,@Face,@opinion,@creationDate)

create procedure Modify_FeedBack
@ID_FeedBack int,
@ID_Store int,
@Face int,
@opinion varchar(200),
@creationDate datetime
as
update [Feed Back]
set ID_Store=@ID_Store,Face=@Face,opinion=@opinion,creationDate=@creationDate
where ID_FeedBack=@ID_FeedBack

create procedure Delete_FeedBack
@ID_FeeedBack int
as
delete [Feed Back]
where ID_FeedBack=@ID_FeeedBack

create procedure all_FeedBackTables
as
select*from [Feed Back]