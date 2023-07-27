create table Colors(
Id int primary key identity(1,1),
ColorName varchar(30)
)

create table Brands(
Id int primary key identity(1,1),
BrandName varchar(30)
)

create table Cars(
Id int primary key identity(1,1),
BrandId int foreign key references Brands(Id),
ColorId int foreign key references Colors(Id),
ModelYear varchar(10),
DailyPrice smallint,
Description varchar(128)
)

create table CarImages(
Id int primary key identity(1,1),
CarId int foreign key references Cars(Id),
ImagePath varchar(250),
Date Datetime
)

create table Customers(
Id int primary key identity(1,1),
CompanyName varchar(50)
)


create table Rentals(
Id int primary key identity(1,1),
CarId int foreign key references Cars(Id),
UserId int foreign key references Users(Id),
RentDate datetime,
ReturnDate datetime,
)


create table Users(
Id int primary key identity(1,1),
CustomerId int references Customers(Id),
FirstName varchar(30),
LastName varchar(30),
Email varchar(30),
Password varchar(30),
)


insert into Brands values('Dacia')
insert into Brands values('Honda')
insert into Brands values('Peugeto')
insert into Brands values('Hyundai')
insert into Brands values('Toyota')
insert into Brands values('Audi')
insert into Brands values('Mercedes-Benz')
insert into Brands values('Volkswagen')
insert into Brands values('BMW')
insert into Brands values('Fiat')


insert into Colors values('Kırmızı')
insert into Colors values('Sarı')
insert into Colors values('Yeşil')
insert into Colors values('Mor')
insert into Colors values('Mavi')
insert into Colors values('Turuncu')
insert into Colors values('Beyaz')
insert into Colors values('Gri')
insert into Colors values('Füme')
insert into Colors values('Satin Siyah')


insert into Cars values(1,5,'2018',80,'Dacia Duster')
insert into Cars values(1,9,'2020',120,'Dacia Duster')
insert into Cars values(6,3,'2012',90,'Audi A3')
insert into Cars values(9,10,'2022',190,'520D')
insert into Cars values(2,1,'2006',50,'Honda Civic')
insert into Cars values(10,7,'2014',60,'Fiat Linea')
insert into Cars values(7,1,'2018',100,'Volkswagen Golf')
insert into Cars values(5,7,'2000',550,'Toyota Supra')
insert into Cars values(4,7,'2005',50,'Hyundai Accent')
insert into Cars values(3,3,'2018',150,'5008')

insert into Customers values('Kodlamaio')
insert into Customers values('Tarım kredi kooperatif')
insert into Customers values('Bellisima kadın kuaförü')
insert into Customers values('ASC Özbal mobilya')
insert into Customers values('Kalaba Nil Yorgan')
insert into Customers values('Meteksan')
insert into Customers values('Atak Turizm')
insert into Customers values('Çavuş market')
insert into Customers values('DOSA')
insert into Customers values('Hasköy Muhtarlığı')

insert into Users values(1,'Denizhan','Dursun','deniz@gmail.com','2002')
insert into Users values(2,'Fulden','Özsayın','fulden@gmail.com','0413')
insert into Users values(3,'Sadık Onur','Özatak','steamsado@gmail.com','yetgr23')
insert into Users values(4,'Abdulsamet','Balcıoğlu','samo@gmail.com','asd123')
insert into Users values(5,'Taha Turan','Yavuz','tty@gmail.com','93784')
insert into Users values(6,'Mert','Tanrıverdioğlu','mtvo@gmail.com','4576897')
insert into Users values(7,'Mehmet Berkay','Kırten','beko@gmail.com','4326457')
insert into Users values(8,'Doğukan Şükrü','Aksu','sooker@gmail.com','432645')
insert into Users values(9,'Ayşe','Atak','aatak@gmail.com','123455')
insert into Users values(10,'Ahsen Deniz','Dursun','canahsen@gmail.com','1234')

insert into Rentals values(1,1,'2023-07-22 17:18:43','2023-08-22 17:18:43')
insert into Rentals values(2,2,'2023-07-22 17:18:43','2023-08-22 17:18:43')
insert into Rentals values(3,3,'2023-07-22 17:18:43','2023-08-22 17:18:43')
insert into Rentals values(4,4,'2023-07-22 17:18:43','2023-08-22 17:18:43')
insert into Rentals values(5,5,'2023-07-22 17:18:43','2023-08-22 17:18:43')
insert into Rentals values(6,6,'2023-07-22 17:18:43','2023-08-22 17:18:43')
insert into Rentals values(7,7,'2023-07-22 17:18:43','2023-08-22 17:18:43')
insert into Rentals values(8,8,'2023-07-22 17:18:43','2023-08-22 17:18:43')
insert into Rentals values(9,9,'2023-07-22 17:18:43','2023-08-22 17:18:43')
insert into Rentals values(10,10,'2023-07-22 17:18:43','2023-08-22 17:18:43')


