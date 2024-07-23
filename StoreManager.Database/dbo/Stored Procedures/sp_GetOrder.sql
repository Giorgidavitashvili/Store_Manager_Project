CREATE PROCEDURE sp_GetOrder
	 @OrderID Int
AS
BEGIN	
	SELECT *
	FROM Orders
	WHERE OrderID = @OrderID;

	RETURN 0;
END;
