﻿CREATE PROCEDURE sp_GetProducts
	 @ProductID Int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT *
	FROM Products
	WHERE IsActive=1;

	RETURN 0;
END;
