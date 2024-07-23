CREATE PROCEDURE sp_InsertProduct
    @CategoryID INT,
    @SupplierID INT,
    @ProductName NVARCHAR(50),
    @Description NVARCHAR(2000),
    @Price MONEY,
    @ProductID INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Products (CategoryID, SupplierID, ProductName,  [Description], Price)
    VALUES (@CategoryID, @SupplierID, @ProductName, @Description, @Price);
    
    SET @ProductID = SCOPE_IDENTITY();

    RETURN 0;
END;
