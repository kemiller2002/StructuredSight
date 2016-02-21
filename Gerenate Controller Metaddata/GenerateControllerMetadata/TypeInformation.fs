namespace StructuredSight.Web.Api
open System
open System.Reflection
open StructuredSight
open System.Web

module TypeInformation = 
    let GetName (oType:Type) = NameInformation.GetName oType

    let GetProperties (oType:Type) = 
        oType.GetProperties() |> 
        Seq.where(fun x -> x.CanWrite && x.CanRead) |>
        Seq.map(fun x-> VariableInformation.Create(x.Name, x.PropertyType))

    let Create (oType:Type) =
        {
            ObjectType.Name = GetName oType;
            Properties  = GetProperties oType
        }