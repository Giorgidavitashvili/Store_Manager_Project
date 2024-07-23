CREATE PROCEDURE sp_deleteOrder
    @OrderID INT
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM Orders WHERE OrderID = @OrderID;

    RETURN 0;

END;
