CREATE PROCEDURE sp_UpdatePriceHistory
    @ProductID INT,
    @Price MONEY
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE PriceHistories
    SET Price = @Price,
        CreateDate = GETDATE()
    WHERE ProductID = @ProductID;
    
    RETURN 0;
END;
