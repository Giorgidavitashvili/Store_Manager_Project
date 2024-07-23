CREATE PROCEDURE sp_GetCustomers
AS
BEGIN
    SET NOCOUNT ON;

    SELECT * 
    FROM Customers
    WHERE IsActive = 1;

    RETURN 0;
END;