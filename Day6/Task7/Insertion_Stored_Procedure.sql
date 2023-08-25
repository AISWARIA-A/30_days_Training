USE OFFICE;

CREATE PROCEDURE InsertStudent
	@StudentID INT,
    @FirstName VARCHAR(50),
    @LastName VARCHAR(50),
    @Email VARCHAR(100),
    @CourseID INT
AS
BEGIN
    INSERT INTO Students (StudentID, FirstName, LastName, Email, CourseID)
    VALUES (@StudentID, @FirstName, @LastName, @Email, @CourseID);
END;


EXEC InsertStudent 12,'Joe', 'Jacob', 'joel@example.com', 101;

select * from Students;