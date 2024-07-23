CREATE PROCEDURE sp_DeleteSupplier
    @SupplierID INT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Suppliers
    SET IsActive = 0
    WHERE SupplierID = @SupplierID AND 
          IsActive = 1;

    RETURN 0;
END