namespace Profiler

module Models = 

    open System.Data.SqlClient

    open FSharp.Data

    [<Literal>]
    let connectionString = 
        @"Data Source=.;Initial Catalog=SystemMonitoring;Integrated Security=True"


    type DataAccess(connectionString:string) = 
        member this.X = "F#"


