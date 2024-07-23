CREATE PROCEDURE sp_GetProductsQuantity
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT *
	FROM ProductQuantities
	WHERE IsActive=1;

	RETURN 0;
END;
