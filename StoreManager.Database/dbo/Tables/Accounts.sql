CREATE TABLE [dbo].[Accounts] (
    [AccountID]    INT          IDENTITY (1, 1) NOT NULL,
    [Email]        NVARCHAR (100) NOT NULL UNIQUE,
    [Username]     NVARCHAR (50)  NOT NULL UNIQUE,
    [Password]     VARBINARY(MAX) NOT NULL,
    [IsActive]     BIT           DEFAULT ((1)) NOT NULL,
    [CreateDate]   DATETIME      DEFAULT (getdate()) NOT NULL,
    [UpdateDate]   DATETIME      NULL,
    [EmployeeID]   INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([AccountID] ASC),
    CONSTRAINT FK_Accounts_Employees FOREIGN KEY ([EmployeeID]) REFERENCES [dbo].[Employees] ([EmployeeID])
);

