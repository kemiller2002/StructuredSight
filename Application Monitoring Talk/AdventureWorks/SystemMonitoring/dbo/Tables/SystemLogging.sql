CREATE TABLE [dbo].[SystemLogging]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	SystemLogId UNIQUEIDENTIFIER NULL,
        ParentLogId VARCHAR(100) NULL,
        Module VARChAR(100) NULL,
        Level VARChAR(100) NULL,
        Logger VARChAR(100) NULL,
        Message VARChAR(MAX) NULL,
        MachineName VARChAR(100) NULL,
        Username VARChAR(100) NULL,
        CallSite VARChAR(500) NULL,
        Thread VARChAR(100) NULL,
        Exception VARChAR(1000) NULL,
        Stacktrace VARChAR(1000) NULL,
        MethodName VARChAR(100) NULL,
        FilePath VARChAR(256) NULL,
        LineNumber INT NULL
)
