CREATE PROCEDURE GetStudents
AS
BEGIN
    SELECT s.StudentID, s.FirstName, s.LastName, s.Email, c.CourseName
    FROM Students s
    INNER JOIN Courses c ON s.CourseID = c.CourseID;
END;

EXEC GetStudents;