CREATE PROCEDURE sp_GetProduct
	 @ProductID Int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT *
	FROM Products
	WHERE IsActive=1 AND ProductID = @ProductID;

	RETURN 0;
END;
