CREATE PROCEDURE sp_GetSuppliers
    @SupplierID int
AS
BEGIN
    SET NOCOUNT ON;

    SELECT * 
    FROM Suppliers
    WHERE IsActive = 1;

    RETURN 0;
END;
