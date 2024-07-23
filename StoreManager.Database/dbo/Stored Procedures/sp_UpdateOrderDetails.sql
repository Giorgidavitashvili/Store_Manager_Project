CREATE PROCEDURE sp_UpdateOrderDetail
    @ProductID INT,
    @OrderID INT,
    @Quantity INT,
    @UnitPrice INT,
    @DiscountPrice INT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE OrderDetails
    SET Quantity = @Quantity,
        UnitPrice = @UnitPrice
    WHERE ProductID = @ProductID AND OrderID = @OrderID;

    RETURN 0;
END;
