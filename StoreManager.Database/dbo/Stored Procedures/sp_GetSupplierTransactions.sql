CREATE PROCEDURE sp_GetSupplierTransactions
AS
BEGIN
    SET NOCOUNT ON;

    SELECT * 
    FROM SupplierTransactions;

    RETURN 0;
END;
