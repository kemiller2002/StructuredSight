CREATE PROCEDURE [dbo].[CallLogEntrySelect]
	@BeginDate DATETIME
	,@EndDate DATETIME

AS
	
		SELECT * FROM CallLogEntry WHERE (Date >= @BeginDate OR @BeginDate IS NULL ) AND (Date <= DATEADD(dd, 1, @EndDate) OR @EndDate IS NULL)
