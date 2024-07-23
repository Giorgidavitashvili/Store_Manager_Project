CREATE TABLE [dbo].[SupplierTransactionDetails] (
    [TransactionID]      INT            NOT NULL,
    [ProductID]          INT            NOT NULL,
    [Price]              INT            NOT NULL,
    [Quantity]           INT            NOT NULL,
    [ProductionDate]     DATETIME       DEFAULT (getdate()) NOT NULL,
    [ExpirationDate]     DATETIME       NULL,
    [DiscountPercentage] DECIMAL (5, 2) NULL,
    [DiscountedValue]    INT            NULL,
    [DiscountDetails]    NVARCHAR (255)  NULL,
    [UpdateDate]  DATETIME     NULL,
    PRIMARY KEY CLUSTERED ([TransactionID] ASC, [ProductID] ASC),
    FOREIGN KEY ([ProductID]) REFERENCES [dbo].[Products] ([ProductID]),
    FOREIGN KEY ([TransactionID]) REFERENCES [dbo].[SupplierTransactions] ([TransactionID])
);

