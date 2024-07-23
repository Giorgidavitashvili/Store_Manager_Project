CREATE PROCEDURE sp_DeleteProduct
    @ProductID INT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Products
    SET IsActive = 0,
        UpdateDate = GETDATE()
    WHERE ProductID = @ProductID AND IsActive = 1;

  
    RETURN 0;
END;
