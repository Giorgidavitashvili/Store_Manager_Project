CREATE PROCEDURE sp_GetCustomer
    @CustomerID int
AS
BEGIN
    SELECT * 
    FROM Customers
    WHERE IsActive = 1 AND CustomerID = @CustomerID;
END;