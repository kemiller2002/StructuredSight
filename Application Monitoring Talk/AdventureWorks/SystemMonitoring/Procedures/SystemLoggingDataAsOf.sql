CREATE PROCEDURE [dbo].[SystemLoggingDataAsOf]

AS

	SELECT TOP 1 * FROM LogEntry ORDER BY LogEntry.Id ASC