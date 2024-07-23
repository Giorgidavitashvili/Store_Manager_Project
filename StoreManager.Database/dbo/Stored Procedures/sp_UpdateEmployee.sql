CREATE PROCEDURE dbo.sp_UpdateEmployee
    @EmployeeID INT,
    @FirstName NVARCHAR(50),
    @LastName NVARCHAR(50),
    @Email NVARCHAR(100),
    @ReportTo INT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Employees
    SET FirstName = @FirstName,
        LastName = @LastName,
        Email = @Email,
        ReportTo = @ReportTo,
        UpdateDate = GETDATE()
    WHERE EmployeeID = @EmployeeID;

    RETURN 0;
END;