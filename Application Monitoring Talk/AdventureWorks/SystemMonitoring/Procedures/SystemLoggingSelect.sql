CREATE PROCEDURE [dbo].[SystemLoggingSelect]
	@BeginDate DATETIME = NULL
	,@EndDate DATETIME = NULL
AS

	SELECT * FROM LogEntry WHERE (LogEntry.Date >= @BeginDate OR @BeginDate IS NULL) AND (Date <= @EndDate OR @EndDate IS NULL)