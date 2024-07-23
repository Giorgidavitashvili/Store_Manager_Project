CREATE PROCEDURE sp_UpdateAccount
    @AccountID INT,
    @Email NVARCHAR(100),
    @Username NVARCHAR(100),
    @Password NVARCHAR(50),
    @EmployeeID INT

AS
BEGIN
    SET NOCOUNT ON;
    
    DECLARE @PasswordHash NVARCHAR(255) = HASHBYTES('SHA2_512', @Password);

    UPDATE Accounts
    SET Email = @Email,
        Username = @Username,
        EmployeeID = @EmployeeID,
        [Password] = @PasswordHash,
        UpdateDate = GETDATE()
    WHERE AccountID = @AccountID;

	RETURN 0;
END;