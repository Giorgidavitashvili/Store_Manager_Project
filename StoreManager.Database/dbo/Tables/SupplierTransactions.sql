CREATE TABLE [dbo].[SupplierTransactions] (
    [TransactionID]   INT          IDENTITY (1, 1) NOT NULL,
    [SupplierID]      INT          NOT NULL,
    [EmployeeID]      INT          NOT NULL,
    [TransactionCode] NVARCHAR(10) NOT NULL UNIQUE,
    [TransactionDate] DATETIME  NOT NULL,
    [Status]    TINYINT NOT NULL, -- 0: Pending, 1: Processing, 2: Shipped, 3: Delivered, 4: Cancelled
    [Description] NVARCHAR (1000) NULL,
    [CreateDate]      DATETIME     DEFAULT (getdate()) NOT NULL,
    PRIMARY KEY CLUSTERED ([TransactionID] ASC),
    FOREIGN KEY ([SupplierID]) REFERENCES [dbo].[Suppliers] ([SupplierID]),
    FOREIGN KEY ([EmployeeID]) REFERENCES [dbo].[Employees] ([EmployeeID]),
    UNIQUE NONCLUSTERED ([TransactionCode] ASC)
);

