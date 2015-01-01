param(
    [string] $connectionString
    ,[string] $outputFilesLocation
)


function ExecuteReader
{
    param($fnExecuteReaderConents)

    $commandText = "SELECT SPECIFIC_CATALOG, SPECIFIC_SCHEMA, SPECIFIC_NAME, ROUTINE_DEFINITION FROM INFORMATION_SCHEMA.ROUTINES
	    WHERE ROUTINE_NAME NOT LIKE 'sp_%' AND ROUTINE_NAME NOT LIKE 'fn_%'"
    
    $connection = New-Object System.Data.SqlClient.SqlConnection
    $connection.ConnectionString = $connectionString
    $connection.Open()
    
    $command = New-Object System.Data.SqlClient.SqlCommand
    $command.Connection = $connection
    $command.CommandText = $commandText

    $reader= $command.ExecuteReader()
    
    while($reader.Read()){

        $fnExecuteReaderConents.Invoke($reader)
    
    }


}

$makeFileContens = {
    param($reader)

    $catalog = $reader.GetString(0)
    $schema = $reader.GetString(1)
    $procedureName = $reader.GetString(2)
    $contents = $reader.GetString(3)
    
    $replacementExpression = $contents -Replace "(?i:create procedure)","ALTER PROCEDURE"

    $header = "IF NOT EXISTS ( SELECT * FROM sys.procedures t JOIN sys.schemas s ON t.schema_id = s.schema_id WHERE t.name = '$procedureName' AND
s.name = '$schema')
    BEGIN 
        exec sp_sqlexec 'CREATE PROCEDURE $schema.$procedureName AS PRINT ''TEMPLATE'' '
    END

    GO

"


    @{
        FileName = "$schema.$procedureName.sql"
        Contents = $header + $replacementExpression
    }
}

ExecuteReader $makeFileContens | foreach{
    Set-Content "$outputFilesLocation\$($_.FileName)" $_.Contents
}