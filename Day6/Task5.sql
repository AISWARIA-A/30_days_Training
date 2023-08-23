USE OFFICE;
-- Create Students Table

-- Create Enrolled Courses Table
CREATE TABLE Courses (
    CourseID INT PRIMARY KEY,
    CourseName VARCHAR(100),
    Instructor VARCHAR(50)
);

-- Populate Courses Table
INSERT INTO Courses 
VALUES
    (101, 'Mathematics', 'Dr. Deepa'),
    (102, 'History', 'Prof. Aneesh'),
    (103, 'Physics', 'Dr. Sreela'),
    (104, 'Computer Science', 'Prof. Tina');

CREATE TABLE Students (
    StudentID INT PRIMARY KEY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    Email VARCHAR(100),
	CourseID INT REFERENCES Courses(CourseID)
);

-- Inserting data into students table
INSERT INTO Students 
VALUES
    (1, 'Amit', 'Kumar', 'amit@example.com',102),
    (2, 'Priya', 'Rajeev', 'priya@example.com',104),
    (3, 'Rahul', 'Sudev', 'rahul@example.com',101);

INSERT INTO Students (StudentID, FirstName, LastName, Email)
VALUES
    (4, 'Anjali', 'Verma', 'anjali@example.com'),
	(5, 'Riya', 'Rajeev', 'riya@example.com' );


-- INNER JOIN: Retrieves students who have enrolled in courses.
SELECT Students.StudentID, Students.FirstName , Students.LastName ,
Courses.CourseName, Courses.Instructor 
FROM Students INNER JOIN Courses ON Students.CourseID = Courses.CourseID;

/* LEFT JOIN: Retrieve all students and their enrolled courses,
  including students without courses. */
SELECT Students.StudentID, Students.FirstName , Students.LastName ,
Courses.CourseName, Courses.Instructor 
FROM Students LEFT JOIN Courses ON Students.CourseID = Courses.CourseID;


/* RIGHT JOIN: RetrieveS all courses and their corresponding enrolled students, 
 including courses without students. */
SELECT Students.StudentID, Students.FirstName , Students.LastName ,
Courses.CourseName, Courses.Instructor 
FROM Students RIGHT JOIN Courses ON Students.CourseID = Courses.CourseID;

/* FULL OUTER JOIN: Retrieve all students and all courses,
  showing matching records where available. */
SELECT Students.StudentID, Students.FirstName , Students.LastName ,
Courses.CourseName, Courses.Instructor 
FROM Students FULL OUTER JOIN Courses ON Students.CourseID = Courses.CourseID;

-- SELF JOIN: Retrieve students who share the same last name.
SELECT s1.StudentID, s1.FirstName, s1.LastName, s2.StudentID AS RelativeID, s2.FirstName AS RelativeFirstName, s2.LastName AS RelativeLastName
FROM Students s1
JOIN Students s2 ON s1.LastName = s2.LastName AND s1.StudentID <> s2.StudentID;
