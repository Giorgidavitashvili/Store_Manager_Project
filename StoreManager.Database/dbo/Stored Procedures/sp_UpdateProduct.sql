CREATE PROCEDURE sp_UpdateProduct
    @ProductID INT,
    @CategoryID INT,
    @SupplierID INT,
    @ProductName NVARCHAR(50),
    @Description NVARCHAR(2000),
    @Price MONEY
AS
BEGIN
    UPDATE Products
    SET CategoryID = @CategoryID,
        SupplierID = @SupplierID,
        ProductName = @ProductName,
        Price = @Price,
       [Description] = @Description,
        UpdateDate = GETDATE()
    WHERE ProductID = @ProductID;

    RETURN 0;
END;
