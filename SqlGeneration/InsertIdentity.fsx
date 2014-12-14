#load "Generator.fsx"

open Generator


let tableName = "IdUserInsert"
let schemaName = "dbo"

let fields = seq {
            //This is the Entry record.  Defined in the other fsx file.
    yield {FieldName="UserID"; FieldValue = "1"; IsNumber=true; IsPrimaryKey=true} 
    yield {FieldName="UserName"; FieldValue = "kmiller"; IsNumber=false; IsPrimaryKey = false}
}


let insertStatments = GenerateInsertStatement schemaName tableName fields

//prints to console or fsi. 
let fullSql = AddIdentityInsertWrapper schemaName tableName insertStatments

printfn "%s" fullSql

//This line writes it to a text file.
//System.IO.File.WriteAllText(@"C:\temp\MyInsertScript.sql", insertStatments)