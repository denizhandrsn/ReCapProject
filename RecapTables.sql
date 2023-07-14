create table Cars(
CarId int identity(1,1) primary key,
BrandId int foreign key references Brands(BrandId),
ColorId int foreign key references Colors(COlorId),
ModelYear varchar(32),
DailyPrice smallint,
Description varchar(128)
)

create table Brands(
Id int identity(1,1) primary key,
BrandId int unique,
BrandName varchar(64)
)
create table Colors(
Id int identity(1,1) primary key,
ColorId int unique,
ColorName varchar(64)
)
insert into Cars values (1,2,'2000',0,'Rental car')
insert into Cars values (3,5,'2003',8,'R')
insert into Cars values (5,1,'2006',7,'Rental car')
insert into Cars values (3,1,'2001',4,'Rental car')
insert into Cars values (2,5,'2009',3,'Rental car')
insert into Cars values (6,1,'2012',5,'Rental car')
