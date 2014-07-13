[<EntryPoint>]
let main argv = 
    printfn "%A" argv
    
    StructuredSight.CallerExample.Logging.Logger.Log("F Sharp application start.")

    0 // return an integer exit code
