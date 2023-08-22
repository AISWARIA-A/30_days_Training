CREATE PROCEDURE ManageStudent
    @Operation CHAR(1), -- C (Create), R (Read), U (Update), D (Delete)
    @StudentID INT = NULL,
    @FirstName VARCHAR(50) = NULL,
    @LastName VARCHAR(50) = NULL,
    @Email VARCHAR(100) = NULL,
	@CourseID INT = NULL
AS
BEGIN
    IF @Operation = 'C'
    BEGIN
        INSERT INTO Students (StudentID, FirstName, LastName, Email, CourseID)
        VALUES (@StudentID, @FirstName, @LastName, @Email, @CourseID);
    END
    ELSE IF @Operation = 'R'
    BEGIN
        SELECT * FROM Students WHERE StudentID = @StudentID;
    END
    ELSE IF @Operation = 'U'
    BEGIN
        UPDATE Students
        SET FirstName = @FirstName, LastName = @LastName, Email = @Email
        WHERE StudentID = @StudentID;
    END
    ELSE IF @Operation = 'D'
    BEGIN
        DELETE FROM Students WHERE StudentID = @StudentID;
    END
END;


EXEC ManageStudent 'D', 7;