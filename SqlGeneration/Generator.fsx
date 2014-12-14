type Entry  = {FieldName:string; FieldValue:string; IsNumber:bool; IsPrimaryKey:bool} 
    with 
        member x.FormatValue = 
              match x.IsNumber with 
                | true -> sprintf "%s" x.FieldValue
                | _ -> sprintf "'%s'" x.FieldValue      
        
        member x.FormatName = sprintf "[%s]" x.FieldName

let Notify (message:string) = sprintf "RAISERROR('%s', 0, 0) WITH NOWAIT" message

let GenerateComparison (field:Entry) = 
    sprintf "%s=%s" field.FormatName field.FormatValue
 
let GetTableFullName(schema:string)(table:string) =  
    match schema with 
    | s when System.String.IsNullOrWhiteSpace(schema) -> sprintf "[%s]" table
    | _ -> sprintf "[%s].[%s]" schema table

                                    
let AddIdentityInsertWrapper (schema:string) (tableName:string) (sql:string) = 
    let table = GetTableFullName schema tableName
    sprintf @"SET IDENTITY_INSERT %s ON

%s 
    
SET IDENTITY_INSERT %s OFF" table sql table

let GenerateInsertStatement (schema:string) (tableName:string) (fields:Entry seq) = 
    let joinWithType = fun (seperator:string )(x:string seq) -> System.String.Join(seperator, x)
    
    let table = GetTableFullName schema tableName

    let joinConditional = joinWithType "
    AND
    "

    let join = fun(x:string seq) -> System.String.Join(",", x)

    let appendConditional (insert:string) (update:string) = 
        let qualifier =  fields     
                                  |> Seq.where(fun(x)->x.IsPrimaryKey)
                                  |> Seq.map (fun x-> GenerateComparison x) 
                                  |> (fun(x) -> joinConditional x)

        sprintf @"
IF NOT EXISTS (SELECT * FROM %s WHERE %s)
BEGIN
        %s
END
ELSE
BEGIN
        %s
END
            " table qualifier insert update

    let insert (table:string) (fields:Entry seq) =

        let values = fields |> Seq.map(fun x -> match x with 
                                                | {IsNumber = true} as entry -> sprintf "%s" entry.FieldValue
                                                | _ as entry -> sprintf "'%s'" entry.FieldValue
                                                ) |> join

        let fieldNames = fields |> Seq.map(fun x -> x.FormatName) |> join

        let notifyComplete = Notify <| (sprintf "INSERT ran for %s" table)

        sprintf @"
        INSERT INTO %s
        (
            %s
        )   
        VALUES
        (
            %s
        )

        %s 

        " table fieldNames values notifyComplete

    let update (table:string) (fields:Entry seq)  =
        let notPrimaryKey = fields |> Seq.where (fun x -> not x.IsPrimaryKey)
        let comparison  = notPrimaryKey |> Seq.map(fun x -> GenerateComparison x)
        let set = comparison |> join
        let where = fields |> Seq.where (fun x -> x.IsPrimaryKey) |>
                        Seq.map(fun x -> GenerateComparison x) |> joinConditional

        

        if notPrimaryKey |> Seq.length = 0 then
            Notify <| (sprintf "NO UPDATE RAN FOR %s WHERE: %s.  All update fields were primary keys." table where)
        else 
            let notifyComplete = Notify <| (sprintf "UPDATE ran for %s with %s" table where)
            sprintf @"
             UPDATE %s
             SET %s
             WHERE %s
             %s
            " table set where notifyComplete 
        
    appendConditional (insert table fields) (update table fields)


let CreateField field value number primaryKey = {FieldName=field; FieldValue=value; IsNumber=number; IsPrimaryKey=primaryKey}