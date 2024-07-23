CREATE PROCEDURE sp_DeleteRole
    @RoleID INT
AS
BEGIN
	SET NOCOUNT ON;
    
    UPDATE Roles
    SET IsActive = 0
    WHERE RoleID = @RoleID AND isActive = 1; 

    RETURN 0;
END;