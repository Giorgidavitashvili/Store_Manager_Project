CREATE TABLE [dbo].[Permissions] (
    [PermissionID]   INT          IDENTITY (1, 1) NOT NULL,
    [PermissionName] NVARCHAR (50) NULL,
    [Code] VARCHAR(10) NOT NULL UNIQUE,
    [IsActive]       BIT          DEFAULT ((1)) NOT NULL,
    [CreateDate]     DATETIME     DEFAULT (getdate()) NOT NULL,
    [UpdateDate]  DATETIME     NULL,
    PRIMARY KEY CLUSTERED ([PermissionID] ASC)
);

