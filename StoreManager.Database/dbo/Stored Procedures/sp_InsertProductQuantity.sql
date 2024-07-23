CREATE PROCEDURE sp_InsertProductQuantity
    @Quantity INT,
    @ProductID INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO ProductQuantities (Quantity, UpdateDate)
    VALUES (@Quantity, GETDATE());

     SET @ProductID = SCOPE_IDENTITY();

    RETURN 0;
END;

