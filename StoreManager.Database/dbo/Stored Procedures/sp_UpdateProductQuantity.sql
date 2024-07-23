CREATE PROCEDURE sp_UpdateProductQuantity
    @ProductQuantityID INT,
    @Quantity INT,
    @UpdateDate DATETIME
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE ProductQuantities
    SET Quantity = @Quantity,
        UpdateDate = GETDATE()
    WHERE ProductID = @ProductQuantityID;

    RETURN 0;
END;