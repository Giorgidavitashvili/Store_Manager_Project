CREATE PROCEDURE sp_UpdateCustomer
    @CustomerID INT,
    @FirstName NVARCHAR(50),
    @MiddleName NVARCHAR(50),
    @LastName NVARCHAR(50),
    @Email NVARCHAR(100),
    @Phone NVARCHAR(20),
    @Country NVARCHAR(50),
    @City NVARCHAR(50),
    @CustomerAddress NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Customers
    SET FirstName = @FirstName,
        MiddleName = @MiddleName,
        LastName = @LastName,
        Email = @Email,
        Phone = @Phone,
        Country = @Country,
        City = @City,
        CustomerAddress = @CustomerAddress,
        UpdateDate = GETDATE()
    WHERE CustomerID = @CustomerID;

    RETURN 0;
END;