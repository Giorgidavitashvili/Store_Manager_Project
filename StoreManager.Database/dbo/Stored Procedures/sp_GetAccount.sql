CREATE PROCEDURE sp_GetAccount
	 @AccountID Int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT *
	FROM Accounts
	WHERE IsActive=1 AND AccountID=@AccountID;

	RETURN 0;
END;
