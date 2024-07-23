CREATE PROCEDURE sp_InsertCategory
    @CategoryName NVARCHAR(100),
    @CategoryID INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Categories(CategoryName)
    VALUES (@CategoryName);

    SET @CategoryID = SCOPE_IDENTITY();

    RETURN 0;
END;
