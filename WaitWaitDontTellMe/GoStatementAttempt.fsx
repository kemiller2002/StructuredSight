open System
open System.Data.SqlClient

try 
    let connectionString = 
      "Server=localhost\sqlexpress;Database=Scratch;Integrated Security=sspi"
    
    let procedure = 
      @"PRINT 'HELLO WORLD'
        GO
        PRINT 'HELLO WORLD AGAIN'"
    
    
    use connection = new SqlConnection(connectionString)
    
    connection.InfoMessage.Add
      (fun x->printfn "This is an informational message: %s" x.Message)
    
    connection.Open()
    
    let command = new SqlCommand (procedure, connection)
    
    command.ExecuteNonQuery() |> ignore
with  
    | ex  -> printfn "This is an exception message: %s \n Exception Type: %s" 
                     ex.Message (ex.GetType().ToString())
