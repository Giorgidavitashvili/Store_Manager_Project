CREATE PROCEDURE sp_InsertEmployee
    @FirstName NVARCHAR(50),
    @LastName NVARCHAR(50),
    @Email NVARCHAR(100),
    @ReportTo INT,
	@EmployeeID INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    
    INSERT INTO Employees (FirstName, LastName, Email, ReportTo)
    VALUES (@FirstName, @LastName, @Email, @ReportTo);

	SET @EmployeeID = SCOPE_IDENTITY();

    RETURN 0;
END;