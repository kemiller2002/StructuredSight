open System
open System.Data.SqlClient


let connectionString = "Data Source=localhost\sqlExpress;Initial Catalog=Scratch;Integrated Security=SSPI;"

type Table = {Id:int; TableName:string; SchemaName:string}
type TableRelationship = {ForiegnKey:Table; PrimaryKey:Table}

let connection = new SqlConnection(connectionString)
let command = new SqlCommand()

command.Connection <- connection
connection.Open() 


let tableSql = "SELECT t.object_id, t.name AS TableName, s.Name as SchemaName FROM sys.tables t JOIN sys.schemas s ON t.schema_id = s.schema_id"
let referenceSql = "SELECT fkeyid, rkeyid FROM sys.sysreferences"

let tables = [
    command.CommandText <- tableSql

    let reader = command.ExecuteReader()

    while reader.Read () do 
        yield {TableName = reader.["TableName"] :?> string; Id = reader.["object_id"] :?> int; SchemaName = reader.["SchemaName"] :?> string}
    
    reader.Close()

]

let findInList (tables: Table seq) (id:int) = 
    tables |> Seq.find(fun(x) ->x.Id = id)
let findTable = findInList tables


let relationships = [
    command.CommandText <- referenceSql
    let reader = command.ExecuteReader()
    while reader.Read () do 
        yield {ForiegnKey = reader.["fkeyid"] :?> int |> findTable; PrimaryKey = reader.["rkeyid"] :?> int |> findTable}
    reader.Close()
]

let relationshipGroup = relationships |> Seq.groupBy(fun(x) -> x.ForiegnKey) |> Seq.map(fun(x) -> let p, c = x;  
                                                                                                  (p , c |> Seq.toList)
                                                                                       )
let rec GetTableOrder (rs: (Table * TableRelationship list) seq) (lookup: Table) = 
    let findRelation = fun(x) ->
                        let fk, _ = x   
                        lookup.Id = fk.Id

    let found = Seq.tryFind findRelation rs

    

    match found with 
    | None -> [lookup]
    | _ as relation-> 
        let fkT, relations = Option.get relation
        match relations.Length with 
        | 0 -> [fkT]
        | _ -> 
                [
                    for r in relations do 
                        yield! GetTableOrder rs fkT
                ]


let GetTables  (rGroup) (tables) = 
    seq{
            for table in tables do
                yield! GetTableOrder rGroup table
        } |> Seq.distinct 
 

GetTables relationshipGroup tables |> Seq.iter(fun(x)->printfn "%s.%s" x.SchemaName x.TableName)