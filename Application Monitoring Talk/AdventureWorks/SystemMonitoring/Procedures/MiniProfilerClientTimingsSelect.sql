CREATE PROCEDURE [dbo].[MiniProfilerClientTimingsSelect]
	@BeginDate DATETIME = NULL
	,@EndDate DATETIME = NULL

AS

SELECT * FROM MiniProfilerClientTimings m 
	JOIN MiniProfilers p ON m.MiniProfilerId = p.Id
WHERE (p.Started >= @BeginDate OR @BeginDate IS NULL) AND (p.Started <= @EndDate OR @EndDate IS NULL)