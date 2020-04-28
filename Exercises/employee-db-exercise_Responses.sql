CREATE TABLE Department (
	ID NVARCHAR(16) NOT NULL,
	Name NVARCHAR(120) NOT NULL,
	Location NVARCHAR(120) NOT NULL
	CONSTRAINT PK_DepartmentID PRIMARY KEY CLUSTERED (ID)
);

CREATE TABLE EmployeeB (
	ID NVARCHAR(16) NOT NULL,
	FirstName NVARCHAR(60) NOT NULL,
	LastName NVARCHAR(60) NOT NULL,
	SSN NVARCHAR(10) NOT NULL,
	DeptID NVARCHAR(16) NOT NULL
	CONSTRAINT PK_EmployeeID PRIMARY KEY CLUSTERED (ID)
);

CREATE TABLE EmpDetails (
	ID NVARCHAR(16) NOT NULL,
	EmployeeID NVARCHAR(16) NOT NULL,
	Salary INT NOT NULL,
	Address1 NVARCHAR(64) NOT NULL,
	Address2 NVARCHAR(64),
	City NVARCHAR(32) NOT NULL,
	State NVARCHAR(2) NOT NULL,
	Country NVARCHAR(32) NOT NULL
	CONSTRAINT PK_ID PRIMARY KEY CLUSTERED (ID)
);

INSERT INTO Department (
Id, 
Name,
Location) 
VALUES 
(1,'Human-Resources','ND'),
(2,'Sales','GA'),
(3,'Support','UT'),
(4,'Marketing','NY');

INSERT INTO EmployeeB (
ID,
FirstName,
LastName,
SSN,
DeptID)
VALUES 
('A','Kevin','Bacon',987654321,2),
('B','Hugo','Weaving',875397460,4),
('C','Emma','Roberts',809564329,3),
('D','Tina','Smith',123456789,4);

INSERT INTO EmpDetails (
ID,
EmployeeID,
Salary,
Address1,
Address2,
City,
State,
Country)
VALUES 
('f76s','A',65000,'234 Nothing Blvd.',NULL,'Atlanta','GA','USA'),
('fja8','B',70000,'298 Sidewalk Pl.',NULL,'Buffalo','NY', 'USA'),
('r298','C',80000,'435 Suburb Rd.',NULL,'Salt Lake City','UT','USA'),
('g345','D',60000,'123 Apple Ln.','Apt 456','New York City','NY','USA');

-- List all employees in Marketing
select
em.*
from EmployeeB as em
join Department as de
on em.DeptID = de.ID
where de.name = 'Marketing'

-- Report total salary of marketing
select
sum(ed.salary) as total_salary
from EmpDetails as ed
join EmployeeB as em
on ed.EmployeeID = em.ID
join Department as de
on em.DeptID = de.ID
where de.name = 'Marketing'

-- Report total employees by department
select
count(em.ID) as total_employees,
de.name as department_name
from EmployeeB as em
join Department as de
on em.DeptID = de.ID
group by de.name

-- Increate salary of Tina Smith to $90,000
UPDATE EmpDetails
set salary = 90000
where EmployeeID in (
select
ID
from EmployeeB
where FirstName='Tina'
and LastName='Smith');