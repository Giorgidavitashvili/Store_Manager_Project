CREATE PROCEDURE sp_GetPermission
    @PermissionID int
AS
BEGIN
    SET NOCOUNT ON;

    SELECT * 
    FROM Permissions
    WHERE IsActive = 1 AND PermissionID = @PermissionID;

    RETURN 0;
END;
