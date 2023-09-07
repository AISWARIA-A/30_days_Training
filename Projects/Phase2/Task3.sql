--Creating a new database.
CREATE DATABASE OFFICE;

USE OFFICE;

--Creating a table for employees
CREATE TABLE Employee (
    EmployeeID INT PRIMARY KEY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    Department VARCHAR(50),
    Salary DECIMAL(10, 2)
);

--Inserting data into the table
INSERT INTO Employee (EmployeeID, FirstName, LastName, Department, Salary)
VALUES
    (1, 'Arun', 'Kumar', 'HR', 40000),
    (2, 'Anitha', 'Nair', 'IT', 60000),
    (3, 'Sreejith', 'Menon', 'Finance', 55000),
    (4, 'Deepa', 'Raj', 'IT', 48000),
    (5, 'Harish', 'Nair', 'HR', 42000),
    (6, 'Saranya', 'Pillai', 'Finance', 52000),
    (7, 'Vishnu', 'Raghavan', 'IT', 63000),
    (8, 'Lekshmi', 'Krishnan', 'IT', 56000),
    (9, 'Ranjith', 'Nair', 'Finance', 49000),
    (10, 'Meera', 'Menon', 'HR', 44000),
    (11, 'Suresh', 'Kumar', 'Finance', 59000),
    (12, 'Anu', 'Pillai', 'IT', 67000),
    (13, 'Manoj', 'Nair', 'HR', 46000),
    (14, 'Divya', 'Raj', 'IT', 51000),
    (15, 'Gopal', 'Menon', 'Finance', 53000);

--Displaying the second highest salary from the table.
SELECT TOP 1 Salary 
FROM (
    SELECT DISTINCT TOP 2 Salary
    FROM Employee
    ORDER BY Salary DESC
) AS SecondHighestSalary
ORDER BY Salary ASC;

