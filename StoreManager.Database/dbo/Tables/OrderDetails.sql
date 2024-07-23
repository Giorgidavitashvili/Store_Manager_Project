CREATE TABLE [dbo].[OrderDetails] (
    [ProductID]          INT            NOT NULL,
    [OrderID]            INT            NOT NULL,
    [Quantity]           INT            NOT NULL,
    [UnitPrice]          MONEY          NOT NULL,
    [DiscountPercentage] DECIMAL(5, 2)  NOT NULL DEFAULT(0),
    [ProductionDate] DATETIME    NOT NULL,
    [ExpireDate]  DATETIME     NULL,
    PRIMARY KEY CLUSTERED ([ProductID] ASC, [OrderID] ASC),
    FOREIGN KEY ([OrderID]) REFERENCES [dbo].[Orders] ([OrderID]),
    FOREIGN KEY ([ProductID]) REFERENCES [dbo].[Products] ([ProductID])
);

