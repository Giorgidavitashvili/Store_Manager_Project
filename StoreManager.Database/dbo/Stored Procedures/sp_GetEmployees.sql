CREATE PROCEDURE sp_GetEmployees
    @EmployeeID int
AS
BEGIN
    SET NOCOUNT ON;

    SELECT * 
    FROM Employees
    WHERE IsActive = 1;

    RETURN 0;
END;