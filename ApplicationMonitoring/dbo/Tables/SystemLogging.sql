CREATE TABLE [dbo].[SystemLogging](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SystemLogId] [uniqueidentifier] NULL,
	[ParentLogId] [varchar](100) NULL,
	[Module] [varchar](100) NULL,
	[Level] [varchar](100) NULL,
	[Logger] [varchar](100) NULL,
	[Message] [varchar](max) NULL,
	[MachineName] [varchar](100) NULL,
	[Username] [varchar](100) NULL,
	[CallSite] [varchar](500) NULL,
	[Thread] [varchar](100) NULL,
	[Exception] [varchar](max) NULL,
	[Stacktrace] [varchar](max) NULL,
	[MethodName] [varchar](100) NULL,
	[FilePath] [varchar](256) NULL,
	[LineNumber] [int] NULL,
	[Date] [datetime] NULL DEFAULT (getutcdate())
) 

GO

