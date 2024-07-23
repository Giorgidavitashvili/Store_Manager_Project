CREATE PROCEDURE sp_DeleteCustomer
    @CustomerID INT
AS
BEGIN
    SET NOCOUNT ON;
   
    UPDATE Customers
    SET IsActive = 0,
        UpdateDate = GETDATE()
    WHERE CustomerID = @CustomerID AND IsActive = 1;

    RETURN 0;
END;
