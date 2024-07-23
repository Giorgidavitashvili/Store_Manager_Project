CREATE PROCEDURE sp_GetPriceHistory
	 @ProductID Int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT *
	FROM PriceHistories
	WHERE ProductID = @ProductID;

	RETURN 0;
END;
