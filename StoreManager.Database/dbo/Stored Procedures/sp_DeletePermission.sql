CREATE PROCEDURE sp_DeletePermission
    @PermissionID INT
AS
BEGIN
    SET NOCOUNT ON;
    
    UPDATE [Permissions]
    SET IsActive = 0
    WHERE PermissionID = @PermissionID  AND isActive = 1 ;

    RETURN 0;
END;