CREATE TABLE [dbo].[PriceHistories] (
    [ProductID]  INT        NOT NULL,
    [Price]      MONEY NOT NULL,
    [CreateDate] DATETIME   DEFAULT (getdate()) NOT NULL,
    PRIMARY KEY CLUSTERED ([ProductID] ASC),
    FOREIGN KEY ([ProductID]) REFERENCES [dbo].[Products] ([ProductID])
);

