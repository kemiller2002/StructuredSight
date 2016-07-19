/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/


IF NOT EXISTS(SELECT * FROM CallLogEntryType WHERE CallLogEntryTypeId = 1)
BEGIN
	INSERT INTO CallLogEntryType
	(
		CallLogEntryTypeId
		,Name
	)
	VALUES
	(
		1
		,'Request'
	)
END

IF NOT EXISTS(SELECT * FROM CallLogEntryType WHERE CallLogEntryTypeId = 2)
BEGIN
	INSERT INTO CallLogEntryType
	(
		CallLogEntryTypeId
		,Name
	)
	VALUES
	(
		2
		,'Response'
	)
END