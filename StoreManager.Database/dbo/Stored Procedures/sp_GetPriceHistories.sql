CREATE PROCEDURE sp_GetPriceHistories
	 @ProductID Int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT *
	FROM PriceHistories

	RETURN 0;
END;