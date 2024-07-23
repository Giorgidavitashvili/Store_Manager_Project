CREATE PROCEDURE sp_DeleteEmployee
    @EmployeeID INT
AS
BEGIN
    SET NOCOUNT ON;
    
    UPDATE Employees
    SET IsActive = 0,
        UpdateDate = GETDATE()
    WHERE EmployeeID = @EmployeeID AND isActive = 1;

    RETURN 0;
END;