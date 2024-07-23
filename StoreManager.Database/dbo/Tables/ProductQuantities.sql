CREATE TABLE [dbo].[ProductQuantities] (
    [ProductID]  INT      NOT NULL,
    [Quantity]   INT      NULL,
    [UpdateDate] DATETIME NULL,
    [IsActive]    BIT  DEFAULT ((1)) NOT NULL,
    PRIMARY KEY CLUSTERED ([ProductID] ASC),
    FOREIGN KEY ([ProductID]) REFERENCES [dbo].[Products] ([ProductID])
);

