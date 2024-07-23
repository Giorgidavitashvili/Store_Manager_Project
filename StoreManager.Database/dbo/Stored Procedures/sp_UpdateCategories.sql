CREATE PROCEDURE sp_UpdateCategory 
    @CategoryID INT,
    @CategoryName NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE dbo.Categories
    SET CategoryName = @CategoryName,
        UpdateDate = GETDATE()
    WHERE CategoryID = @CategoryID;

    RETURN 0;
END;
