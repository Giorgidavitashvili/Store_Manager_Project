CREATE PROCEDURE sp_GetProductQuantity
	 @ProductID Int
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT *
	FROM ProductQuantities
	WHERE IsActive=1 AND ProductID = @ProductID;

	RETURN 0;
END;
