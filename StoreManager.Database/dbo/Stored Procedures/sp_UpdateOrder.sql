CREATE PROCEDURE [dbo].[sp_UpdateOrderDetail]
    @ProductID INT,
    @OrderID INT,
    @Quantity INT,
    @UnitPrice INT,
    @DiscountPrice INT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE dbo.OrderDetails
    SET Quantity = @Quantity,
        UnitPrice = @UnitPrice,
        DiscountPrice = @DiscountPrice
    WHERE ProductID = @ProductID AND OrderID = @OrderID;
END;
