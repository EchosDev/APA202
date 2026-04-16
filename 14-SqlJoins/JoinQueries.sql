create database Company
use Company

create table Countries (
	Id int primary key identity,
	Name nvarchar (50) not null
);

create table Cities (
	Id int primary key identity,
	Name nvarchar (50) not null,
	CountryId int foreign key references Countries(Id)
);

create table Employees (
	Id int primary key identity,
	Name nvarchar(50) not null,
	Surname nvarchar (50),
	Age int,
	Salary decimal(10,2),
	Position nvarchar (50),
	IsDeleted bit default 0,
	CityId int foreign key references Cities(Id)
);

insert into Countries(Name) 
values ('Azerbaijan'),('Turkey');

insert into Cities(Name , CountryId)
values ('Baku',1),('Shamakhi',1),('Istanbul',2),('Ankara',2)

insert into Employees (Name,Surname,Age,Salary,Position,CityId)
values 
('Elmir','Shikhaliyev',20,3000,'Developer',2),
('Feyzullah','Memmedov',21,2800,'Manager',1),
('Atakan', 'Demir', 25, 900, 'Tester', 1),
('Ayse', 'Yilmaz', 28, 2500, 'Developer', 3);

select * from Countries

select * from Cities

select * from Employees

select e.Name as EmployeeName,ci.Name as CityName,c.Name as CountryName from Employees as e
join Cities as ci on e.CityId = ci.Id
join Countries as c on ci.CountryId = c.Id

select e.Name as EmployeeName,ci.Name as CityName,c.Name as CountryName ,e.Salary as EmployeeSalary from Employees as e
join Cities as ci on e.CityId = ci.Id
join Countries as c on ci.CountryId = c.Id
where Salary > 2000

select ci.Name as CityName,c.Name as CountryName  from Cities as ci
join Countries as c on ci.CountryId = c.Id

select e.Name as EmployeeName,
		Surname,
		Age,
		Salary,
		Position,
		ci.Name as CityName,
		c.Name as CountryName  
from Employees as e 
join Cities as ci on ci.Id = e.CityId
join Countries as c on c.Id = ci.CountryId
where Position <> 'Developer' --Mellim Burda mende reseption yoxdu deye yerine Developer eledim

update Employees
set IsDeleted = 1
where Id= 3

select  e.Name as EmployeeName,
		Surname,
		Age,
		Salary,
		Position,
		ci.Name as CityName,
		c.Name as CountryName 
from Employees as e 
join Cities as ci on ci.Id = e.CityId
join Countries as c on c.Id = ci.CountryId
where IsDeleted = 1