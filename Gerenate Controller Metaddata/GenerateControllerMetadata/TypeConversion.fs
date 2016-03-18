namespace StructuredSight.Web.Api
open System
open System.Reflection
open StructuredSight
open System.Web


module TypeConversion  = 
    let DiscoverTypes (mi:Method) = 
         seq {
            yield! mi.Parameters |> Seq.map (fun x-> x.Variable.ObjectType.Name)
            if mi.ReturnType.IsSome then yield mi.ReturnType.Value.Name
         }
    
    let ConvertTypes(name:Name) = 
        let oType = Type.GetType(sprintf "%s.%s" (if name.Namespace.IsSome then name.Namespace.Value else "System") name.Name)
        oType.GetProperties()