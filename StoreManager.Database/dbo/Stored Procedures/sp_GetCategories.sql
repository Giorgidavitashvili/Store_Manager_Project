﻿CREATE PROCEDURE sp_GetCategories
AS
BEGIN
	SET NOCOUNT ON;

	SELECT *
	FROM Categories
	WHERE IsActive=1;

	RETURN 0;
END;
