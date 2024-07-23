CREATE PROCEDURE sp_DeleteProductQuantity
    @ProductID INT
AS
BEGIN
    SET NOCOUNT ON;

  
    UPDATE ProductQuantities
    SET IsActive = 0,
        UpdateDate = GETDATE()
    WHERE ProductID = @ProductID AND IsActive = 1;

    RETURN 0;
END;
