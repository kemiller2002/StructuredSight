DECLARE @SearchID VARCHAR(50)
DECLARE @TableName VARCHAR(50)
DECLARE @ColumnName VARCHAR(50)
DECLARE @SqlCode NVARCHAR(500)

SET @SearchId = 'CD839615-AE28-4B8B-99D0-11F82FADB187' 



DECLARE search_cursor CURSOR FOR
	SELECT t.Name, c.Name FROM sys.tables t 
		JOIN sys.columns c ON t.object_id = c.object_id
		JOIN sys.types tp ON c.system_type_id = tp.system_type_id
		WHERE tp.name = 'uniqueidentifier' 


OPEN search_cursor

FETCH NEXT FROM search_cursor 
INTO @TableName, @ColumnName

WHILE @@FETCH_STATUS = 0
BEGIN
	SET @SqlCode = 'SELECT * FROM ' + @TableName + ' WHERE ' + @ColumnName + ' = ''' + @SearchId + ''''
	PRINT @SqlCode

	exec sp_sqlexec @SqlCode

	FETCH NEXT FROM search_cursor 
	INTO @TableName, @ColumnName
END

CLOSE search_cursor
DEALLOCATE search_cursor