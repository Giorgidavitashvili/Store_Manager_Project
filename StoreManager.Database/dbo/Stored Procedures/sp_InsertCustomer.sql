CREATE PROCEDURE sp_InsertCustomer
    @FirstName NVARCHAR(50),
    @MiddleName NVARCHAR(50),
    @LastName NVARCHAR(50),
    @Email NVARCHAR(100),
    @Phone NVARCHAR(20),
    @Country NVARCHAR(50),
    @City NVARCHAR(50),
    @CustomerAddress NVARCHAR(255),
    @CustomerID INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;


    INSERT INTO Customers(FirstName, MiddleName, LastName, Email, Phone, Country,City, CustomerAddress)
    VALUES (@FirstName, @MiddleName, @LastName, @Email, @Phone, @Country, @City, @CustomerAddress);

    SET @CustomerID = SCOPE_IDENTITY();

    RETURN 0;
END;
