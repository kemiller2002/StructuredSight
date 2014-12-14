#load "Generator.fsx"

open Generator

let tableName = "UserToRole"
let schemaName = "dbo"

let multipleInserts = seq {

    yield seq {
         yield {FieldName="UserId"; FieldValue = "2"; IsNumber=true; IsPrimaryKey=true} 
         yield {FieldName="RoleId"; FieldValue = "1"; IsNumber=true; IsPrimaryKey = true}
    }


}


let insertStatments = multipleInserts 
                    |> Seq.map(fun(x) -> GenerateInsertStatement schemaName tableName x) 
                    |> (fun(x) -> System.String.Join(@"
                    GO
                    ", x))

printfn "%s" insertStatments

//This line writes it to a text file.
//System.IO.File.WriteAllText(@"C:\temp\MyInsertScript.sql", insertStatments)