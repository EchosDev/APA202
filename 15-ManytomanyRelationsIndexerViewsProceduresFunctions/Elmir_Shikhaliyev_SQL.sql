create database CompanyMM
go 

use CompanyMM
go
create table Employees (
	EmployeeID int primary key identity,
	FirstName nvarchar (50) not null,
	LastName nvarchar (50) not null,
	BirthDate date not null check (BirthDate<=getdate()),
	Email varchar(100) not null unique
);
go
create table Projects (
	ProjectID int primary key identity,
	ProjectName nvarchar (100),
	StartDate date,
	EndDate date
);
go
create table EmployeeProjects (
	EmployeeID int foreign key references Employees(EmployeeID),
	ProjectID int foreign key references Projects(ProjectID),
	AssignedDate date,

	primary key (EmployeeID , ProjectID)
);
go
insert into Employees (FirstName, LastName, BirthDate, Email)
values 
('Ali', 'Mammadov', '1995-03-12', 'ali.mammadov@example.com'),
('Leyla', 'Aliyeva', '1992-07-21', 'leyla.aliyeva@example.com'),
('Orkhan', 'Huseynov', '1988-11-05', 'orkhan.huseynov@example.com'),
('Nigar', 'Hasanova', '1997-01-30', 'nigar.hasanova@example.com'),
('Elmir', 'Shikhaliyev', '2006-08-23', 'elmir.shikhaliyev@example.com'),
('Kamran', 'Ibrahimov', '1990-09-18', 'kamran.ibrahimov@example.com');
go
insert into Projects (ProjectName, StartDate, EndDate)
values 
('Website Development', '2024-01-10', '2024-06-10'),
('Mobile App', '2024-02-01', '2024-08-01'),
('CRM System', '2023-09-15', '2024-03-15'),
('Data Analytics', '2024-03-01', '2024-09-01'),
('E-commerce Platform', '2023-11-20', '2024-05-20');
go
insert into EmployeeProjects (EmployeeID, ProjectID , AssignedDate)
values 
(1, 1, '2024-01-10'),
(1, 2, '2024-02-01'),
(2, 2, '2024-02-15'),
(3, 3, '2024-03-01'),
(4, 4, '2024-03-10'),
(5, 2, '2024-04-01');
go
select * from Employees

select * from Projects

select (e.FirstName + ' ' + e.LastName) as FullName, p.ProjectName from Employees as e
join EmployeeProjects as ep on ep.EmployeeID = e.EmployeeID
join Projects as p on p.ProjectID = ep.ProjectID

select p.ProjectName as ProjectName , count (e.EmployeeID) as TotalEmployees from Employees as e
join EmployeeProjects as ep on ep.EmployeeID = e.EmployeeID
join Projects as p on p.ProjectID = ep.ProjectID
group by (ProjectName)

select p.ProjectName as ProjectName , count (e.EmployeeID) as TotalEmployees from Employees as e
join EmployeeProjects as ep on ep.EmployeeID = e.EmployeeID
join Projects as p on p.ProjectID = ep.ProjectID
group by (ProjectName)
having  count (e.EmployeeID) > 2
go
create view EmployeeProjectView
as
select e.EmployeeID,(e.FirstName + ' ' + e.LastName) as FullName , p.ProjectID , p.ProjectName, ep.AssignedDate from Employees as e
join EmployeeProjects as ep on ep.EmployeeID = e.EmployeeID
join Projects as p on p.ProjectID = ep.ProjectID
go
select * from EmployeeProjectView
where EmployeeID = 1
GO
create procedure sp_AssignEmployeeToProject (@empId int, @projId int)
as 
begin
	if not exists(
		select * from EmployeeProjects
		where EmployeeID = @empid and ProjectID = @projId
	)
	begin 
		insert into EmployeeProjects
		values (@empId, @projId,getdate())
	end
end
go
create function fn_GetProjectCount(@empid int) returns int
as
begin
    declare @count int;

    select @count = count(*)
    from EmployeeProjects
    where EmployeeID = @empid;

    return @count;
end
go
exec sp_AssignEmployeeToProject 5,1

select dbo.fn_GetProjectCount(1) as ProjectCount

select * from EmployeeProjectView
where EmployeeID = 2

delete from EmployeeProjects
where EmployeeID = 2;