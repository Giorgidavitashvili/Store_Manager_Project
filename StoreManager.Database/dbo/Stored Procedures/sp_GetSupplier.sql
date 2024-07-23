CREATE PROCEDURE sp_GetSupplier
    @SupplierID int
AS
BEGIN
    SET NOCOUNT ON;

    SELECT * 
    FROM Suppliers
    WHERE IsActive = 1 AND SupplierID = @SupplierID;

    RETURN 0;
END;
