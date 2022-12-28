create database EmployeeData;

-- Department Table--
create table Departments (
    Dept_ID int PRIMARY KEY,
    Dept_Name varchar(50),
    Location varchar(25)
);

-- Employee table--
create table Employee_Data (
    Emp_id int PRIMARY KEY,
    firstName varchar(25),
    lastName varchar(25),
    SSN int,
    Dept_ID int,
    FOREIGN KEY(Dept_ID) REFERENCES Departments(Dept_ID)
);

-- Employee Details table--

create table Employee_Details(
    Salary int,
    Address1 varchar(25),
    Address2 varchar(25),
    city varchar(25),
    stateName varchar(20),
    Country varchar(25),
    Emp_id int unique FOREIGN KEY(Emp_id) REFERENCES Employee_Data(Emp_id)
);

-- inserting 3 values for each tables--
insert into Departments values (101,'Research','Bengalore'),
                                 (201,'Technology','Chennai'),
                                   (301,'Analysis','Mumbai');

insert into Employee_Data values 
    (1001,'Bhargav','Bhat','420840',101),
    (1002,'Pavan','Kumar','420842',201),
    (1003,'Madhu','Acharya','424844',301);

insert into Employee_Details VALUES
    (10000,'Magod Colony','Magod','Yellapur','Karnataka','India',1001),
    (15000,'KR mohalla','Mysore','Mysore','Karnataka','India',1002),
    (10000,'4th block','Vijayanagara','Bengalore','Karnataka','India',1003);

select * from Departments;
select * from Employee_Data;
select * from Employee_Details;

-- adding department Marketing--
insert into Departments values (401,'Marketing','Bengalore');

--inserting employee Teena Smith--
insert into Employee_Data values 
    (1004,'Teena','Smith','421841',401);

-- inserting Teena Smith Details--
insert into Employee_Details VALUES
    (25000,'6th Block','Jayanagara','Benglore','Karnataka','India',1004);

--list all the employees in marketing--
select ed.firstName,ed.lastName,d.Dept_Name 
from Employee_Data ed 
INNER JOIN Departments d on ed.Dept_ID=d.Dept_ID
where d.Dept_Name='Marketing';

--total salary of Marketing--
select sum(Salary) as Total_Salary 
from Employee_Details edt 
where edt.Emp_id in (select ed.Emp_id from Employee_Data ed 
                    inner join Departments d on ed.Dept_ID=d.Dept_ID
                    where d.Dept_Name='Marketing'); 

-- increasing salary of Teena smith by 90,000--
update [Employee_Details]
set [Salary]=90000
from Employee_Data ed inner join Employee_Details edt on ed.Emp_id=edt.Emp_id
where ed.firstName='Teena';

--total employees by the department--
select count(*) as Employee_Count,d.Dept_Name from Employee_Data ed
inner join Departments d on ed.Dept_ID = d.Dept_ID 
group by d.Dept_Name;

-- avg--
select avg(Salary) as Average_Salary 
from Employee_Details edt 
where edt.Emp_id in (Select ed.Emp_id from Employee_Data ed
                    inner join Departments d on ed.Dept_ID=d.Dept_ID
                    where d.Dept_Name='Marketing');