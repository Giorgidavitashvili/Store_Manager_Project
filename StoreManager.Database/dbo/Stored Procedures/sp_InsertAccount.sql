CREATE PROCEDURE sp_InsertAccount
    @Email NVARCHAR(100),
    @Username NVARCHAR(50),
    @Password NVARCHAR(50),
    @EmployeeID INT,
    @AccountID INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @PasswordHash VARBINARY(MAX) = HASHBYTES('SHA2_512', @Password);

    INSERT INTO Accounts (Email, Username, [Password], EmployeeID)
    VALUES (@Email, @Username, @PasswordHash, @EmployeeID);

    SET @AccountID = SCOPE_IDENTITY();

    RETURN 0;
END;

