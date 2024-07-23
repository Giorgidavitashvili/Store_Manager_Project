CREATE PROCEDURE sp_GetPermissions
AS
BEGIN
    SET NOCOUNT ON;

    SELECT * 
    FROM Permissions
    WHERE IsActive = 1;

    RETURN 0;
END;
