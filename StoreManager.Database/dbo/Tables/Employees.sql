CREATE TABLE [dbo].[Employees] (
    [EmployeeID] INT           IDENTITY(1,1) NOT NULL,
    [FirstName]  NVARCHAR(50)  NOT NULL,
    [LastName]   NVARCHAR(50)  NOT NULL,
    [Email]      NVARCHAR(100) NOT NULL UNIQUE,
    [ReportTo]   INT           NULL,
    [IsActive]   BIT           DEFAULT ((1)) NOT NULL,
    [CreateDate] DATETIME      DEFAULT (GETDATE()) NOT NULL,
    [UpdateDate] DATETIME      NULL,
    PRIMARY KEY CLUSTERED ([EmployeeID] ASC),
    CONSTRAINT FK_Employees_Employees FOREIGN KEY ([ReportTo]) REFERENCES [dbo].[Employees] ([EmployeeID])
);

