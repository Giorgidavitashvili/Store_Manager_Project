﻿CREATE PROCEDURE sp_GetOrders
	 @OrderID Int
AS
BEGIN
	SELECT *
	FROM Orders;
END;
