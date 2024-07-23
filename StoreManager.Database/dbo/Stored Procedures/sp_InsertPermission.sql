CREATE PROCEDURE sp_InsertPermission
    @PermissionName NVARCHAR(50),
    @Code VARCHAR(10),
	@PermissionID int output
AS
BEGIN
    SET NOCOUNT ON;
    
    INSERT INTO [Permissions] (Code, PermissionName)
    VALUES (@Code, @PermissionName);

	SET @PermissionID = SCOPE_IDENTITY();

    RETURN 0;
END;