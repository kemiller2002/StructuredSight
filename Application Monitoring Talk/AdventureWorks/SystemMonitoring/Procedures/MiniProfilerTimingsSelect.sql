CREATE PROCEDURE [dbo].[MiniProfilerTimingsSelect]
	@MiniprofilerId UNIQUEIDENTIFIER

AS

	SELECT	*  FROM MiniProfilerTimings
	WHERE MiniProfilerId = @MiniprofilerId