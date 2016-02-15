CREATE PROCEDURE [dbo].[MiniProfilerTimingsSelect]
	@MiniprofilerId UNIQUEIDENTIFIER = NULL

AS

	SELECT	*  FROM MiniProfilerTimings
	WHERE MiniProfilerId = @MiniprofilerId
		OR @MiniprofilerId IS NULL