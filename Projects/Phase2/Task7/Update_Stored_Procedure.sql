USE OFFICE;

CREATE PROCEDURE UpdateStudent
    @StudentID INT,
    @FirstName VARCHAR(50),
    @LastName VARCHAR(50),
    @Email VARCHAR(100),
    @CourseID INT
AS
BEGIN
    UPDATE Students
    SET FirstName = @FirstName,
        LastName = @LastName,
        Email = @Email,
        CourseID = @CourseID
    WHERE StudentID = @StudentID;
END;

EXEC UpdateStudent 1, 'Kapil', 'Sharma', 'Kapil@example.com', 102;

