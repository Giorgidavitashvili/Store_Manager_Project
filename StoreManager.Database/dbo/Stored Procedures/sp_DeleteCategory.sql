CREATE PROCEDURE sp_DeleteCategory
    @CategoryID INT
AS
BEGIN
    SET NOCOUNT ON;
   
    IF NOT EXISTS (SELECT * FROM Categories WHERE CategoryID = @CategoryID)
    BEGIN 
        RAISERROR('Record Does Not Exist', 16, 1);
        RETURN 1;
    END
    UPDATE Categories
    SET IsActive = 0,
        UpdateDate = GETDATE()
    WHERE CategoryID = @CategoryID AND IsActive = 1;

    RETURN 0;
END;
