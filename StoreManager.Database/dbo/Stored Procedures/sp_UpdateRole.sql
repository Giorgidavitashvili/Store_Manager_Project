CREATE PROCEDURE sp_UpdateRole
    @RoleID INT,
    @RoleName NVARCHAR(50),
    @Description NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    
    UPDATE Roles
    SET RoleName = @RoleName,
        Description = @Description
    WHERE RoleID = @RoleID;

    RETURN 0;
END;