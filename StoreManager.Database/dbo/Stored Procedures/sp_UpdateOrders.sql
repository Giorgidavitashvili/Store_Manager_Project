CREATE PROCEDURE sp_UpdateOrder
    @OrderID INT,
    @CustomerID INT,
    @EmployeeID INT,
    @Status TINYINT,
    @OrderDate DateTime,
    @Description NVARCHAR(1000)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Orders
    SET CustomerID  = @CustomerID,
        EmployeeID  = @EmployeeID,
        [Status] =   @Status,
        OrderDate = GETDATE(),
        [Description] = @Description

    WHERE OrderID = @OrderID;

    RETURN 0;
END;

