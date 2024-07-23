CREATE TABLE [dbo].[Customers] (
    [CustomerID]      INT           IDENTITY (1, 1) NOT NULL,
    [FirstName]       NVARCHAR (50)  NOT NULL,
    [MiddleName]      NVARCHAR (50)  NULL,
    [LastName]        NVARCHAR (50)  NOT NULL,
    [Email]           NVARCHAR (100) NOT NULL,
    [Phone]           NVARCHAR (20)  NOT NULL,
    [Country]         NVARCHAR (50)  NOT NULL,
    [City]            NVARCHAR (50)  NOT NULL,
    [CustomerAddress] NVARCHAR (255) NOT NULL,
    [IsActive]        BIT           DEFAULT ((1)) NOT NULL,
    [CreateDate]      DATETIME      DEFAULT (getdate()) NOT NULL,
    [UpdateDate]      DATETIME      NULL,
    PRIMARY KEY CLUSTERED ([CustomerID] ASC),
    UNIQUE NONCLUSTERED ([Email] ASC)
);

