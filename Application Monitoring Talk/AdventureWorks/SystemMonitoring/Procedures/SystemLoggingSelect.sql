CREATE PROCEDURE [dbo].[SystemLoggingSelect]
	@BeginDate DATETIME = NULL
	,@EndDate DATETIME = NULL
AS

	SELECT * FROM SystemLogging WHERE (Date >= @BeginDate OR @BeginDate IS NULL) AND (Date <= DATEADD(dd, 1, @EndDate) OR @EndDate IS NULL)