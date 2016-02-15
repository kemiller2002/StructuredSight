CREATE PROCEDURE [dbo].[CallLogEntryInsert]
	@CallLogEntryTypeId INT
	,@Message VARCHAR(MAX)
	,@RequestIdentifier UNIQUEIDENTIFIER
	,@StatusCode VARCHAR(10) = NULL
	,@Uri VARCHAR(320) = NULL
	,@Action VARCHAR(10) = NULL
AS 
	INSERT INTO CallLogEntry
	(
		StatusCode
		,Message
		,RequestIdentifier
		,Uri
		,CallLogEntryTypeId
		,Action
		
	)

	VALUES
	(
		@StatusCode
		,@Message
		,@RequestIdentifier
		,@Uri
		,@CallLogEntryTypeId
		,@Action
	)