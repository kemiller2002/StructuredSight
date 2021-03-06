﻿CREATE PROCEDURE [dbo].[MiniProfilersSelect]
	@BeginDate DATETIME = NULL
	,@EndDate DATETIME = NULL

AS
	SELECT 

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

	WHERE (Started >= @BeginDate OR @BeginDate IS NULL) AND (Started <= DATEADD(dd, 1, @EndDate) OR @EndDate IS NULL)
