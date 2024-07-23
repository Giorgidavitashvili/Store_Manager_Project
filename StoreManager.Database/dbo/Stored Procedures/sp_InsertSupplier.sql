CREATE PROCEDURE sp_InsertSupplier
    @CompanyName NVARCHAR(50),
    @Country VARCHAR(50),
    @City NVARCHAR(50),
    @Address NVARCHAR(255),
    @PostalCode NVARCHAR(50),
    @Phone NVARCHAR(20),
    @SupplierID INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Suppliers (CompanyName, Country, City, [Address], PostalCode, Phone)
    VALUES (@CompanyName, @Country, @City, @Address, @PostalCode, @Phone);

    SET @SupplierID = SCOPE_IDENTITY();

    RETURN 0;
END