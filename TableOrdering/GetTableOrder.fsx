open System
open System.Data.SqlClient


let connectionString = "Data Source=localhost\sqlExpress;Initial Catalog=Scratch;Integrated Security=SSPI;"

type TableRelationship = {ForiegnKey:int; PrimaryKey:int}
type Table = {Id:int; TableName:string; SchemaName:string}

let connection = new SqlConnection(connectionString)
let command = new SqlCommand()

command.Connection <- connection
connection.Open() 


let tableSql = "SELECT t.object_id, t.name AS TableName, s.Name as SchemaName FROM sys.tables t JOIN sys.schemas s ON t.schema_id = s.schema_id"
let referenceSql = "SELECT fkeyid, rkeyid FROM sys.sysreferences"

let tables = seq {
    command.CommandText <- tableSql
    let reader = command.ExecuteReader()
    while reader.Read () do 
        yield {TableName = reader.["TableName"]; }
}