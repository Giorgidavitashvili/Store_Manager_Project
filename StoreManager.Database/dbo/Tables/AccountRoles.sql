CREATE TABLE [dbo].[AccountRoles] (
    [RoleID]    INT NOT NULL,
    [AccountID] INT NOT NULL,
    PRIMARY KEY ([RoleID], [AccountID]),
    FOREIGN KEY ([AccountID]) REFERENCES [dbo].[Accounts] ([AccountID]),
    FOREIGN KEY ([RoleID]) REFERENCES [dbo].[Roles] ([RoleID])
);

