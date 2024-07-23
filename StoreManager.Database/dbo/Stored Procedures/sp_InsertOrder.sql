CREATE PROCEDURE sp_InsertOrder
    @CustomerID INT,
    @EmployeeID INT,
    @Status TINYINT,
    @OrderDate DateTime,
    @Description NVARCHAR(1000),
    @OrderID INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO dbo.Orders (CustomerID, EmployeeID, Status, OrderDate, Description)
    VALUES (@CustomerID, @EmployeeID, @Status, @OrderDate, @Description);

      SET @OrderID = SCOPE_IDENTITY();

    RETURN 0;
END;
