<#  
.SYNOPSIS  
  Connects to Sql Server and Pulls the Stored Procedure and Function Code.
.DESCRIPTION
 The script connects to SQL Server and accesses data from the INFORMATION_SCHEMA.ROUTINES view and pulls the code.  It reformats the script and prepends code to create a "shell" procedure if it doesn't exist in a target environment, so it won't fail on creation or alteration of a procedure.  The files are saved in the target directory with a naming convention of Schema.Procedure.Sql and automatically filters out all procedures prepended in the name with fn_ or sp_ as those are supposed to be system functions for SQL Server.
.NOTES
 Author: Kevin Miller
 Site: structuredsight.com
 License: Creative Commons -BY

#>


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