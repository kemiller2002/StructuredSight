//module SqlGenerator

type Entry  = {FieldName:string; FieldValue:string; IsNumber:bool; IsPrimaryKey:bool} 
    with 
        member x.FormatValue = 
              match x.IsNumber with 
                | true -> sprintf "%s" x.FieldValue
                | _ -> sprintf "'%s'" x.FieldValue      
        
        member x.FormatName = sprintf "[%s]" x.FieldName

let GenerateComparison (field:Entry) = 
    sprintf "%s=%s" field.FormatName field.FormatValue
                                    


let GenerateInsertStatement (table:string) (fields:Entry seq) = 
    let joinWithType = fun (seperator:string )(x:string seq) -> System.String.Join(seperator, x)
    let joinConditional = joinWithType "
    AND
    "

    let join = fun(x:string seq) -> System.String.Join(",", x)

    let appendConditional (insert:string) (update:string) = 
        let qualifier =  fields     
                                  |> Seq.where(fun(x)->x.IsPrimaryKey)
                                  |> Seq.map (fun x-> GenerateComparison x) 
                                  |> (fun(x) -> System.String.Join("
                                  ", x))

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

        sprintf @"
        INSERT INTO [%s]
        (
            %s
        )   
        VALUES
        (
            %s
        )
        " table fieldNames values


    let update (table:string) (fields:Entry seq)  =
        let comparison  = fields |> Seq.map(fun x -> GenerateComparison x)
        let set = comparison |> join
        let where = fields |> Seq.where (fun x -> x.IsPrimaryKey) |>
                        Seq.map(fun x -> GenerateComparison x) |> joinConditional

        sprintf @"
         UPDATE %s
         SET %s
         WHERE %s
        " table set where 
        
    appendConditional (insert table fields) (update table fields)


let CreateField field value number primaryKey = {FieldName=field; FieldValue=value; IsNumber=number; IsPrimaryKey=primaryKey}