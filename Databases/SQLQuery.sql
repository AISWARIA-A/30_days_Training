CREATE TABLE [dbo].[Book]
(
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [Title] VARCHAR(50) NOT NULL,
    [Author] VARCHAR(50) NOT NULL,
    [Category] VARCHAR(50) NOT NULL,
    [Publisher] VARCHAR(50) NULL,
    [Pages] INT NULL
);

CREATE PROCEDURE InsertTableRecord
    @Title VARCHAR(50),
    @Author VARCHAR(50),
    @Category VARCHAR(50),
    @Publisher VARCHAR(50),
    @Pages INT
AS
BEGIN
    INSERT INTO [dbo].[Book] (Title, Author, Category, Publisher, Pages)
    VALUES (@Title, @Author, @Category, @Publisher, @Pages);
END;


CREATE PROCEDURE UpdateTableRecord
    @Id INT,
    @Title VARCHAR(50),
    @Author VARCHAR(50),
    @Category VARCHAR(50),
    @Publisher VARCHAR(50),
    @Pages INT
AS
BEGIN
    UPDATE [dbo].[Book]
    SET Title = @Title,
        Author = @Author,
        Category = @Category,
        Publisher = @Publisher,
        Pages = @Pages
    WHERE Id = @Id;
END;


CREATE PROCEDURE GetTableRecordById
    @Id INT
AS
BEGIN
    SELECT * FROM [dbo].[Book]
    WHERE Id = @Id;
END;


CREATE PROCEDURE DeleteTableRecordById
    @Id INT
AS
BEGIN
    DELETE FROM [dbo].[Book]
    WHERE Id = @Id;
END;

