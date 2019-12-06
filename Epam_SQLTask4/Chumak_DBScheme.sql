create database SQL4TaskDB
go

use SQL4TaskDB
go

create table Project
(
	Project_ID int Not null identity(1,1) primary key,
	Project_Name nvarchar(50) not null,
	Project_State varchar(5) not null check (Project_State in ('Open', 'Close')),
	Project_DateOfOpen date not null Default getdate(),
	Project_DateOfFinish date default  DATEADD(DAY, +30, getdate())
)
go

create table Employee
(
	Employee_ID int Not null identity(1,1) primary key,
	Employee_Name nvarchar(50) not null,
	Employee_Age int not null
)
go

create table ProjectIns
(
	ProjectIns_Id int not null identity primary key,
	ProjectIns_Project_ID int null foreign key references Project(Project_ID),
	ProjectIns_Employee_ID int null foreign key references Employee(Employee_ID),
	ProjectIns_Employee_Position nvarchar(50) null
)
go

create table Task
(
	Task_ID int not null identity primary key,
	Task_Name nvarchar(50) not null,
	Task_State nvarchar(30) not null check (Task_State in ('Open','Completed','Needs completion','Closed')),
	Task_State_SettedBy int not null foreign key references Employee(Employee_ID),
	Task_State_DateOfSet date default GETDATE(),	
	Task_Project int not null foreign key references Project(Project_ID),
	Task_Employee int not null foreign key references Employee(Employee_ID),
	Task_Deadline date default GETDATE()
)