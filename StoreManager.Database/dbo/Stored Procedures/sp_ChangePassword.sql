CREATE PROCEDURE sp_ChangePassword
    @Username NVARCHAR(50),
    @OldPassword NVARCHAR(50),
    @NewPassword NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @OldPasswordHash NVARCHAR(255);
    DECLARE @NewPasswordHash NVARCHAR(255);
    DECLARE @StoredPasswordHash NVARCHAR(255);

    -- Hash the old password
    SET @OldPasswordHash = HASHBYTES('SHA2_512', @OldPassword);

    -- Retrieve the stored password hash for the user
    SELECT @StoredPasswordHash = [Password]
    FROM Accounts
    WHERE Username = @Username;

    -- Check if the provided old password matches the stored password
    IF @StoredPasswordHash <> @OldPasswordHash
    BEGIN
        -- If the old password does not match, return an error code
        RETURN -1;
    END

    -- Hash the new password
    SET @NewPasswordHash = HASHBYTES('SHA2_512', @NewPassword);

    -- Update the password and update date
    UPDATE Accounts
    SET [Password] = @NewPasswordHash,
        UpdateDate = GETDATE()
    WHERE Username = @Username;

    RETURN 0;
END;
