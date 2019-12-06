use SQL4TaskDB
go

insert Project(Project_Name, Project_State, Project_DateOfOpen, Project_DateOfFinish)
values 
('First', 'Open', DATEADD(DAY, -100, GETDATE()), DATEADD(DAY, +20, GETDATE())),
('Second', 'Close', DATEADD(DAY, -50, GETDATE()), DATEADD(DAY, -10, GETDATE())),
('Third', 'Open', DATEADD(DAY, -40, GETDATE()), DATEADD(DAY, +30, GETDATE()))
go

insert Employee(Employee_Name, Employee_Age)
values 
('Mihail', 30), ('Oleg', 45),
('Victor', 25),('Anton', 31),
('Vasyl', 18), ('Yaroslav', 25),
('Danilo', 25), ('Petro', 27)
go

insert ProjectIns(ProjectIns_Project_ID, ProjectIns_Employee_ID, ProjectIns_Employee_Position)
values 
(1, 1, 'Senior'), (1, 2, 'Senior'),
(1, 3, 'Middle'), (1, 5, 'Junior'),
(1, 6, 'QA'), (1, 7, 'Junior'),

(3, 1, 'Senior'), (3, 3, 'Middle'),
(3, 4, 'Middle'), (3, 5, 'Junior'), 
(3, 8, 'Junior')

go

insert Task(Task_Name, Task_State, Task_State_SettedBy, Task_State_DateOfSet, 
			Task_Project, Task_Employee, Task_Deadline)
values 
('Some task 1', 'Open', 1, DATEADD(DAY, -100, GETDATE()), 1, 3, DATEADD(DAY, +40, GETDATE())),
('Some task 2', 'Completed', 1, DATEADD(DAY, -50, GETDATE()), 2, 3, DATEADD(DAY, -20, GETDATE())),
('Some task 3', 'Needs completion', 2, DATEADD(DAY, -55, GETDATE()), 3, 4, DATEADD(DAY, +50, GETDATE())),
('Some task 4', 'Closed', 2, DATEADD(DAY, -55, GETDATE()), 2, 4, DATEADD(DAY, -30, GETDATE())),

('First Project Task 1', 'Completed', 3, DATEADD(DAY, -25, GETDATE()), 1, 8, DATEADD(DAY, -5, GETDATE())),
('First Project Task 2', 'Completed', 3, DATEADD(DAY, -20, GETDATE()), 1, 8, DATEADD(DAY, -5, GETDATE())),
('First Project Task 3', 'Needs completion', 2, DATEADD(DAY, -35, GETDATE()), 1, 3, DATEADD(DAY, -15, GETDATE())),
('Third Project Task 1', 'Completed', 1, DATEADD(DAY, -15, GETDATE()), 3, 5, DATEADD(DAY, -5, GETDATE())),
('Third Project Task 2', 'Needs completion', 1, DATEADD(DAY, -10, GETDATE()), 3, 5, DATEADD(DAY, +20, GETDATE())),
('Third Project Task 3', 'Open', 1, DATEADD(DAY, -5, GETDATE()), 3, 5, DATEADD(DAY, +20, GETDATE()))
