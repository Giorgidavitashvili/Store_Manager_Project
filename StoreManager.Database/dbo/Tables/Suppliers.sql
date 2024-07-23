CREATE TABLE [dbo].[Suppliers] (
    [SupplierID]  INT          IDENTITY (1, 1) NOT NULL,
    [CompanyName] NVARCHAR (50) NOT NULL,
    [Country]     VARCHAR (50) NOT NULL,
    [City]        NVARCHAR (50) NOT NULL,
    [Address]     NVARCHAR (255) NOT NULL,
    [PostalCode]  NVARCHAR (50) NOT NULL,
    [Phone]       NVARCHAR (20) NOT NULL,
    [IsActive]    BIT          DEFAULT ((1)) NOT NULL,
    [CreateDate]  DATETIME DEFAULT (getdate()) NOT NULL,
    [UpdateDate]  DATETIME     NULL,
    PRIMARY KEY CLUSTERED ([SupplierID] ASC)
);

