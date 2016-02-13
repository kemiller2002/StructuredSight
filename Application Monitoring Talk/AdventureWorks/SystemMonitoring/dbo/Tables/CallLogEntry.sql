CREATE TABLE [dbo].[CallLogEntry]
(
	   CallLogEntryId INT NOT NULL PRIMARY KEY IDENTITY(1,1)
       ,CallLogEntryTypeId INT NOT NULL REFERENCES CallLogEntryType (CallLogEntryTypeId)
       ,RequestIdentifier UNIQUEIDENTIFIER
       ,Message VARCHAR(1000)
       ,StatusCode VARCHAR(10)
       ,Date DATETIME NOT NULL DEFAULT (GETDATE())
       ,Action VARCHAR(10)
       ,Uri VARCHAR(2000)
)
