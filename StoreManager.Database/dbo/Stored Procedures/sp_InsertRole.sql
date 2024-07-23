CREATE PROCEDURE sp_InsertRole
    @RoleName NVARCHAR(50),
    @Description NVARCHAR(100),
	@RoleID INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    
    INSERT INTO Roles(RoleName, Description)
    VALUES (@RoleName, @Description);

	SET @RoleID = SCOPE_IDENTITY();

	RETURN 0;
END;