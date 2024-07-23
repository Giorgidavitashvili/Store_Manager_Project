CREATE PROCEDURE sp_GetCategory
	 @CategoryID Int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT *
	FROM Categories
	WHERE IsActive=1 AND CategoryID=@CategoryID;

	RETURN 0;
END;
