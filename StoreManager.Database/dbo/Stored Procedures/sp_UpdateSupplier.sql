CREATE PROCEDURE sp_UpdateSupplier
    @SupplierID INT,
    @CompanyName NVARCHAR(50),
    @Country VARCHAR(50),
    @City NVARCHAR(50),
    @Address NVARCHAR(255),
    @PostalCode NVARCHAR(50),
    @Phone NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Suppliers
    SET CompanyName = @CompanyName,
        Country = @Country,
        City = @City,
        [Address] = @Address,
        PostalCode = @PostalCode,
        Phone = @Phone,
        UpdateDate = GETDATE()
    WHERE SupplierID = @SupplierID;

    RETURN 0;
END