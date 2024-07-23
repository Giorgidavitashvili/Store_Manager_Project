CREATE PROCEDURE sp_AccountLogin
    @Username NVARCHAR(50),
    @Password NVARCHAR(50)
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @PasswordHash VARBINARY(MAX);
	SET @PasswordHash = HASHBYTES('SHA2_512', @Password);

	IF EXISTS(
		SELECT 1 
        FROM Accounts 
        WHERE Username = @Username 
			AND [Password] = @PasswordHash 
			AND IsActive = 1
	)
	BEGIN 
		SELECT 1 AS IsValid;
	END
	ELSE
	BEGIN
		SELECT 0 AS IsValid;
	END

	RETURN 0;
END;
