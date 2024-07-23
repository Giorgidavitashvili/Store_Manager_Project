CREATE TABLE [dbo].[SupplierProducts] (
    [SupplierID] INT NOT NULL,
    [ProductID]  INT NOT NULL,
    PRIMARY KEY CLUSTERED ([SupplierID] ASC, [ProductID] ASC),
    FOREIGN KEY ([ProductID]) REFERENCES [dbo].[Products] ([ProductID]),
    FOREIGN KEY ([SupplierID]) REFERENCES [dbo].[Suppliers] ([SupplierID])
);

