#load "Generator.fsx"

open Generator

let tableName = "Users"

let multipleInserts = seq {

    yield seq {
            //This is the Entry record.  Defined in the other fsx file.
         yield {FieldName="UserId"; FieldValue = "1"; IsNumber=true; IsPrimaryKey=true} 
         yield {FieldName="Login"; FieldValue = "kmiller"; IsNumber=false; IsPrimaryKey = false}
         yield {FieldName="Password"; FieldValue = "password"; IsNumber=false; IsPrimaryKey = false} 
    }

    yield seq {
            //This is the Entry record.  Defined in the other fsx file.
         yield {FieldName="UserId"; FieldValue = "2"; IsNumber=true; IsPrimaryKey=true} 
         yield {FieldName="Login"; FieldValue = "Lucy"; IsNumber=false; IsPrimaryKey = false}
         yield {FieldName="Password"; FieldValue = "woof"; IsNumber=false; IsPrimaryKey = false} 
    }


}


let insertStatments = multipleInserts 
                    |> Seq.map(fun(x) -> GenerateInsertStatement tableName x) 
                    |> (fun(x) -> System.String.Join(@"
                    GO
                    ", x))

printfn "%s" insertStatments

//This line writes it to a text file.
//System.IO.File.WriteAllText(@"C:\temp\MyInsertScript.sql", insertStatments)