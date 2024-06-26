create database NSJProject1
use NSJProject1

create table UserGroup(
	GroupId int primary key identity(1,1) not null,
	GroupName varchar(200) not null,
	GroupDescription varchar(200) not null,
	Status varchar(200)
)

create table Users(
	UserID int primary key identity(1,1) not null,
	FullName varchar(200) not null,
	Gender bit,
	Address varchar(200) not null,
	PhoneNumber varchar(200),
	Status varchar(200),
	GroupId int not null references UserGroup(GroupId)
)