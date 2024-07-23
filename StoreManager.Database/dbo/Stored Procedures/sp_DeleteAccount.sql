CREATE PROCEDURE dbo.sp_DeleteAccount
    @AccountID INT
AS
BEGIN
    SET NOCOUNT ON;
    
    UPDATE Accounts
    SET IsActive = 0,
        UpdateDate = GETDATE()
    WHERE AccountID = @AccountID AND isActive = 1;

	RETURN 0;
END;