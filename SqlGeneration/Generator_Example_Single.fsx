#load "Generator.fsx"

open Generator


let tableName = "Users"

let fields = seq {
            //This is the Entry record.  Defined in the other fsx file.
    yield {FieldName="UserId"; FieldValue = "1"; IsNumber=true; IsPrimaryKey=true} 
    yield {FieldName="Login"; FieldValue = "kmiller"; IsNumber=false; IsPrimaryKey = false}
    yield {FieldName="Password"; FieldValue = "password"; IsNumber=false; IsPrimaryKey = false} 
}


let insertStatments = GenerateInsertStatement tableName fields

//prints to console or fsi. 
printfn "%s" insertStatments

//This line writes it to a text file.
//System.IO.File.WriteAllText(@"C:\temp\MyInsertScript.sql", insertStatments)