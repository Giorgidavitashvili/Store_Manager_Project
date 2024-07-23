CREATE TABLE [dbo].[Roles] (
    [RoleID]      INT           IDENTITY (1, 1) NOT NULL,
    [RoleName]    NVARCHAR (50)  NOT NULL,
    [Description] NVARCHAR (100) NULL,
    [IsActive]    BIT          DEFAULT ((1)) NOT NULL,
    [UpdateDate]  DATETIME    NULL,
    PRIMARY KEY CLUSTERED ([RoleID] ASC)
);

