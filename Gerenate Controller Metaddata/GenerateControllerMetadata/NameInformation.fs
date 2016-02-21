
namespace StructuredSight.Web.Api
open System
open System.Reflection
open StructuredSight
open System.Web



module NameInformation = 
    let GetName (oType:Type) = 
        {
            Name = oType.Name;
            Namespace = if String.IsNullOrWhiteSpace oType.Namespace then None else Some oType.Namespace;
        }