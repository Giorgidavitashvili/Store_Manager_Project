CREATE PROCEDURE UpdateSupplierTransaction
    @TransactionID INT,
    @SupplierID INT,
    @TransactionCode NVARCHAR(10),
    @TransactionDate DATETIME,
    @Status TINYINT

AS
BEGIN
    SET NOCOUNT ON;

    UPDATE SupplierTransactions
    SET SupplierID = @SupplierID,
        TransactionCode = @TransactionCode,
        TransactionDate = @TransactionDate,
        Status = @Status
    WHERE TransactionID = @TransactionID;

    RETURN 0;
END;
