CREATE TABLE [dbo].[RolePermissions] (
    [RoleID]       INT NOT NULL,
    [PermissionID] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([RoleID] ASC, [PermissionID] ASC),
    FOREIGN KEY ([PermissionID]) REFERENCES [dbo].[Permissions] ([PermissionID]),
    FOREIGN KEY ([RoleID]) REFERENCES [dbo].[Roles] ([RoleID])
);

