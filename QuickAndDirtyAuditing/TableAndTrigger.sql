
DROP TABLE Auditing

	CREATE TABLE Auditing 
	(
		TableId INT NOT NULL
		,EntryyDateTime DATETIME NOT NULL DEFAULT (GETUTCDATE())
		,Action VARCHAR(10) NOT NULL
		,AuditEntry VARCHAR(MAX) NOT NULL
		,TransactionEntryId UNIQUEIDENTIFIER NOT NULL
	)

	CREATE CLUSTERED INDEX IX_Auditint_Clustered_TableId_TransactionEntryId ON Auditing(TableId,TransactionEntryId)

GO


DROP TABLE AuditTables 

CREATE TABLE AuditTables 
(
	TableId INT NOT NULL PRIMARY KEY 
)


DROP TRIGGER KeyDeployment.Audit_KeyDeployment_Environments

GO 

CREATE TRIGGER KeyDeployment.Audit_KeyDeployment_Environments
	ON KeyDeployment.Environments
AFTER INSERT, UPDATE, DELETE
AS
BEGIN

	DECLARE @TransactionId UNIQUEIDENTIFIER = NEWID()
	DECLARE @ParentTableId INT

	SELECT @ParentTableId = parent_id FROM sys.triggers WHERE object_id = @@PROCID

	IF EXISTS (SELECT 1 FROM AuditTables WHERE TableId = @ParentTableId)
	BEGIN
		IF EXISTS (SELECT 1 FROM inserted)
		BEGIN
		
			INSERT INTO 
				dbo.Auditing (TableId, Action, TransactionEntryId, AuditEntry) 
			SELECT 
				@ParentTableId, 
				'Insert',
				@TransactionId,
				(SELECT * FROM inserted FOR XML RAW)
	
		END
	
		IF EXISTS(SELECT 1 FROM deleted)
		BEGIN
			INSERT INTO 
				dbo.Auditing (TableId, Action, AuditEntry, TransactionEntryId) 
			SELECT 
				@ParentTableId, 
				'Deleted',
				(SELECT * FROM deleted FOR XML RAW) 
				,@TransactionId
	
		END		
	END
END