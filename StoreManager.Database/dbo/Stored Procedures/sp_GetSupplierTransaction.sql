CREATE PROCEDURE sp_GetSupplierTransaction
    @TransactionID int
AS
BEGIN
    SET NOCOUNT ON;

    SELECT * 
    FROM SupplierTransactions
    WHERE TransactionID = @TransactionID;

    RETURN 0;
END;
