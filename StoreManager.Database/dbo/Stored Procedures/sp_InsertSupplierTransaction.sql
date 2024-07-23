CREATE PROCEDURE InsertSupplierTransaction
    @SupplierID INT,
    @TransactionCode NVARCHAR(10),
    @Status TINYINT,
    @TransactionID INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO SupplierTransactions (SupplierID, TransactionCode, Status)
    VALUES (@SupplierID ,@TransactionCode, @Status);

    
	SET @TransactionID =  SCOPE_IDENTITY();

    RETURN 0;
END;
