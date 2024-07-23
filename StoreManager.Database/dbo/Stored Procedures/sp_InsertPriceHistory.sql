CREATE PROCEDURE sp_InsertPriceHistory
    @Price MONEY,
    @ProductID INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO PriceHistories(ProductID, Price)
    VALUES (@ProductID, @Price);

    SET @ProductID = SCOPE_IDENTITY();

    RETURN 0;
END;
