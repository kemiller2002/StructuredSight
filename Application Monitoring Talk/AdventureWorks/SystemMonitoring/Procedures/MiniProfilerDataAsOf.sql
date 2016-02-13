CREATE PROCEDURE [dbo].[MiniProfilerDataAsOf]
AS
	SELECT TOP 1

RowId
,Id
,RootTimingId
,Started
,DurationMilliseconds
,User
,HasUserViewed
,MachineName
,CustomLinksJson
,ClientTimingsRedirectCount


FROM 
	MiniProfilers 

ORDER BY Started ASC