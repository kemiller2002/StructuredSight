CREATE PROCEDURE [dbo].[CallLogEntrySelect]
	@BeginDate DATETIME
	,@EndDate DATETIME

AS
	
		SELECT * FROM CallLogEntry WHERE (Date >= @BeginDate OR @BeginDate IS NULL ) AND (Date <= @EndDate OR @EndDate IS NULL)
