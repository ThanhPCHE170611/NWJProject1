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

-- Insert sample data into UserGroup table
INSERT INTO UserGroup (GroupName, GroupDescription, Status)
VALUES 
('Admin', 'Administrative group', 'Active'),
('Users', 'General users group', 'Active'),
('Guests', 'Guest users group', 'Inactive');

-- Insert sample data into Users table
INSERT INTO Users (FullName, Gender, Address, PhoneNumber, Status, GroupId)
VALUES 
('John Doe', 1, '123 Main St', '555-1234', 'Active', 1),
('Jane Smith', 0, '456 Elm St', '555-5678', 'Active', 2),
('Alice Johnson', 0, '789 Oak St', '555-9012', 'Inactive', 3),
('Bob Brown', 1, '101 Maple St', '555-3456', 'Active', 1);


/*drop database NSJProject1

DECLARE @DatabaseName nvarchar(50)
SET @DatabaseName = N'NSJProject1'

DECLARE @SQL varchar(max)

SELECT @SQL = COALESCE(@SQL,'') + 'Kill ' + Convert(varchar, SPId) + ';'
FROM MASTER..SysProcesses
WHERE DBId = DB_ID(@DatabaseName) AND SPId <> @@SPId

--SELECT @SQL 
EXEC(@SQL) */
select * from Users
select * from UserGroup