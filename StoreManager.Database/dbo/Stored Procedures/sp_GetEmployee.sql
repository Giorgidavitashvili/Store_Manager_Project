CREATE PROCEDURE sp_GetEmployee
    @EmployeeID int
AS
BEGIN
    SET NOCOUNT ON;

    SELECT * 
    FROM Employees
    WHERE IsActive = 1 AND EmployeeID = @EmployeeID;

    RETURN 0;
END;