CREATE TABLE [dbo].[Categories] (
    [CategoryID]   INT          IDENTITY (1, 1) NOT NULL,
    [CategoryName] NVARCHAR (50) NOT NULL,
    [IsActive]     BIT          DEFAULT ((1)) NOT NULL,
    [CreateDate]   DATETIME     DEFAULT (getdate()) NOT NULL,
    [UpdateDate]   DATETIME     NULL,
    PRIMARY KEY CLUSTERED ([CategoryID] ASC)
);

