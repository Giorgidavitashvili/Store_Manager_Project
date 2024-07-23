CREATE PROCEDURE sp_UpdatePermission
    @PermissionID INT,
    @PermissionName NVARCHAR(50),
    @Code VARCHAR(10)
AS
BEGIN
    SET NOCOUNT ON;
    
    UPDATE [Permissions]
    SET Code = @Code,
        PermissionName = @PermissionName
    WHERE PermissionID = @PermissionID AND IsActive = 1;

    RETURN 0;
END;