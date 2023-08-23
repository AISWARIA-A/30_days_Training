USE OFFICE;

-- Create Courses table
CREATE TABLE Course (
    CourseID INT PRIMARY KEY,
    CourseName VARCHAR(100),
    Department VARCHAR(50)
);

-- Insert data into Courses table
INSERT INTO Course (CourseID, CourseName, Department)
VALUES
    (1, 'Computer Science', 'Engineering'),
    (2, 'Mathematics', 'Science'),
    (3, 'History', 'Arts');

-- Create Students table with foreign key constraint
CREATE TABLE Student (
    StudentID INT PRIMARY KEY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    CourseID INT,
    FOREIGN KEY (CourseID) REFERENCES Course(CourseID)
);

-- Insert data into Students table
INSERT INTO Student (StudentID, FirstName, LastName, CourseID)
VALUES
    (1, 'Anjali', 'Nair', 1),
    (2, 'Arun', 'Kumar', 2),
    (3, 'Deepa', 'Menon', 1),
    (4, 'Manoj', 'Pillai', 3);

-- Query to combine necessary fields from Students and Courses tables
SELECT
    s.StudentID,
    s.FirstName,
    s.LastName,
    c.CourseName,
    c.Department
FROM Student s
INNER JOIN Course c ON s.CourseID = c.CourseID;
