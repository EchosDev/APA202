create database Company;
use Company;

create table Employees (
	EmployeeID int primary key identity (1,1),
	FirstName nvarchar (50),
	LastName nvarchar (50),
	Email varchar (100),
	PhoneNumber nvarchar (20),
	HireDate date,
	JobTitle nvarchar (50),
	Salary decimal (10,2),
	Department nvarchar (50)
);

insert into Employees (FirstName,LastName,Email,PhoneNumber,HireDate,JobTitle,Salary,Department)
values 
('Elmir','Shikhaliyev','elmir@gmail.com','050-555-22-00','2020-04-14','Backend Developer',4000,'IT'),
('Ali', 'Mammadov', 'ali@gmail.com', '051-444-33-22', '2023-01-10', 'Frontend Developer', 2100, 'IT'),
('Nigar', 'Aliyeva', 'nigar@gmail.com', '055-777-88-99', '2019-06-05', 'HR Manager', 1300, 'HR'),
('Rashad', 'Hasanov', 'rashad@company.az', '070-111-22-33', '2021-09-20', 'Accountant', 1100, 'Finance'),
('Leyla', 'Karimova', 'leyla@company.az', '077-999-00-11', '2020-12-01', 'Project Manager', 2500, 'Management');

select * from Employees

select EmployeeID ,(FirstName + ' ' + LastName) as FullName from Employees where Salary >2000

select EmployeeID ,(FirstName + ' ' + LastName) as FullName from Employees where Department = 'IT'

select EmployeeID ,(FirstName + ' ' + LastName) as FullName , Salary from Employees order by Salary desc

select EmployeeID ,FirstName , Salary from Employees

select EmployeeID ,(FirstName + ' ' + LastName) as FullName , HireDate from Employees where HireDate > '2020-01-01'

select EmployeeID ,(FirstName + ' ' + LastName) as FullName , Email from Employees where Email like '%@company.az'

select max(Salary) as MaxSalary from Employees 

select min(Salary) as MinSalary from Employees 

select avg(Salary) as AvgSalary from Employees

select count(*) as EmpCount from Employees

select sum(Salary) as TotalSalary from Employees

select Department, count(*) as CountEmployees from Employees group by Department

select Department, avg(Salary) as AvgSalary from Employees group by Department

select Department, max(Salary) as MaxSalary from Employees group by Department

update Employees
set Salary = 2800
where EmployeeID = 1

update Employees
set Salary = Salary * 1.10
where Department = 'IT'

update Employees
set JobTitle = 'HR Manager',
	Department = 'HR'
where FirstName = 'Leyla' and LastName = 'Karimova'

delete from Employees
where EmployeeID = 5

delete from Employees
where Salary < 1500

select * from Employees where FirstName like '%a%'

select * from Employees where Salary between 2000 and 2500

select * from Employees where Department in ('Finance' ,'IT')