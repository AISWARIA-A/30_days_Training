--Creating a new database
CREATE DATABASE EDUHUB;

--Using the created database
USE EDUHUB;

--Creating a table for storing user details
CREATE TABLE Users (
    ID INT PRIMARY KEY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    DateOfBirth DATE,
    Gender VARCHAR(10),
    Email VARCHAR(100),
    PhoneNumber VARCHAR(20),
    Address VARCHAR(200),
    City VARCHAR(50),
    State VARCHAR(50),
	Username VARCHAR(20),
	Password VARCHAR(25)
);

--Inserting data to the table

INSERT INTO Users VALUES
    (1, 'Krishna', 'Kumar', '1995-03-12', 'Male', 'krishna.kumar@example.com', '8765432109', '456 Oak Street', 'Chennai', 'Tamil Nadu', 'KrishnaK890@', 'secure890'),
    (2, 'Lakshmi', 'Raj', '1992-09-25', 'Female', 'lakshmi.raj@example.com', '7654321098', '789 Elm Avenue', 'Hyderabad', 'Telangana', 'LakshmiR567#', 'password567'),
    (3, 'Suresh', 'Nair', '1988-06-08', 'Male', 'suresh.nair@example.com', '6543210987', '123 Pine Street', 'Bengaluru', 'Karnataka', 'SureshN234*', 'hello234'),
    (4, 'Meenakshi', 'Prasad', '1997-01-18', 'Female', 'meenakshi.prasad@example.com', '5432109876', '234 Cedar Road', 'Kochi', 'Kerala', 'MeenakshiP890@', 'secure890'),
    (5, 'Rajesh', 'Gowda', '1991-08-04', 'Male', 'rajesh.gowda@example.com', '4321098765', '567 Maple Avenue', 'Coimbatore', 'Tamil Nadu', 'RajeshG123#', 'password123'),
    (6, 'Divya', 'Kumar', '1986-11-29', 'Female', 'divya.kumar@example.com', '3210987654', '789 Oak Street', 'Visakhapatnam', 'Andhra Pradesh', 'DivyaK234*', 'hello234'),
    (7, 'Harish', 'Menon', '1984-12-06', 'Male', 'harish.menon@example.com', '2109876543', '456 Cedar Road', 'Thiruvananthapuram', 'Kerala', 'HarishM567#', 'secure567'),
	(8, 'Vijay', 'Raghavan', '1990-05-20', 'Male', 'vijay.raghavan@example.com', '9876543210', '678 Pine Street', 'Mysuru', 'Karnataka', 'VijayR890@', 'secure890'),
    (9, 'Deepa', 'Menon', '1995-09-15', 'Female', 'deepa.menon@example.com', '8765432109', '345 Elm Avenue', 'Chennai', 'Tamil Nadu', 'DeepaM567#', 'password567'),
    (10, 'Prasad', 'Krishnan', '1993-03-08', 'Male', 'prasad.krishnan@example.com', '7654321098', '901 Maple Road', 'Kochi', 'Kerala', 'PrasadK234*', 'hello234')
    ;

--Implementing Updation
UPDATE Users SET Email = 'newemail@example.com' WHERE ID = 5;
SELECT * FROM Users WHERE ID = 5;

--Implementing Select
SELECT * FROM Users; --Selects all rows
SELECT FirstName FROM Users; --Selects firstnames of all users
SELECT Address FROM Users WHERE ID = 3; --Selects address of user with id 3


--Implementing Deletion
DELETE FROM Users WHERE ID = 8; --Deletes user with id 8
DELETE FROM Users WHERE FirstName = 'Suresh'; --Deletes user with firstname Suresh




