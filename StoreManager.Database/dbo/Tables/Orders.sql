CREATE TABLE [dbo].[Orders] (
    [OrderID]    INT  IDENTITY (1, 1) NOT NULL,
    [CustomerID] INT  NOT NULL,
    [EmployeeID] INT  NOT NULL,
    [OrderDate]  DATETIME  NOT NULL,
    [Status]     TINYINT NOT NULL, -- 0: Pending, 1: Processing, 2: Shipped, 3: Delivered, 4: Cancelled
    [Description] NVARCHAR (1000) NULL,
    [CreateDate] DATETIME DEFAULT (getdate()) NOT NULL,
    PRIMARY KEY CLUSTERED ([OrderID] ASC),
    FOREIGN KEY ([CustomerID]) REFERENCES [dbo].[Customers] ([CustomerID])
);

