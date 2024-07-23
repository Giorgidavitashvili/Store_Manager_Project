CREATE TABLE [dbo].[Products] (
    [ProductID]   INT          IDENTITY (1, 1) NOT NULL,
    [CategoryID]  INT          NOT NULL,
    [SupplierID]  INT          NOT NULL,
    [ProductName] NVARCHAR (50) NOT NULL,
    [Description] NVARCHAR (2000) NULL,
    [Price]       MONEY   NOT NULL,
    [IsActive]    BIT          DEFAULT ((1)) NOT NULL,
    [CreateDate]  DATETIME     DEFAULT (getdate()) NOT NULL,
    [UpdateDate]  DATETIME     NULL,
    PRIMARY KEY CLUSTERED ([ProductID] ASC),
    FOREIGN KEY ([CategoryID]) REFERENCES [dbo].[Categories] ([CategoryID]),
    FOREIGN KEY ([SupplierID]) REFERENCES [dbo].[Suppliers] ([SupplierID])
);

