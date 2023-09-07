USE OFFICE;


CREATE PROCEDURE ManageStudent
    @Operation VARCHAR(10), -- C (Create), R (Read), U (Update), D (Delete)
    @StudentID INT = NULL,
    @FirstName VARCHAR(50) = NULL,
    @LastName VARCHAR(50) = NULL,
    @Email VARCHAR(100) = NULL,
	@CourseID INT = NULL
AS
BEGIN
    IF @Operation = 'Create'
    BEGIN
        INSERT INTO Students (StudentID, FirstName, LastName, Email, CourseID)
        VALUES (@StudentID, @FirstName, @LastName, @Email, @CourseID);
    END
    ELSE IF @Operation = 'Read'
    BEGIN
        SELECT * FROM Students WHERE StudentID = @StudentID;
    END
    ELSE IF @Operation = 'Update'
    BEGIN
        UPDATE Students
        SET FirstName = @FirstName, LastName = @LastName, Email = @Email
        WHERE StudentID = @StudentID;
    END
    ELSE IF @Operation = 'Delete'
    BEGIN
        DELETE FROM Students WHERE StudentID = @StudentID;
    END
END;

EXEC ManageStudent 'Read',5;
EXEC ManageStudent 'Delete', 7;

