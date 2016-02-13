CREATE PROCEDURE [dbo].[CallLogEntryDataAsOf]


AS
SELECT top 1 * FROM CallLogEntry ORDER BY Date ASC