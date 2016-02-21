namespace StructuredSight.Web.Api
open System
open System.Reflection
open StructuredSight
open System.Web


module VariableInformation =
    let Create (name:string, oType:Type) = 
       {
            Variable.ObjectType = TypeReferenceInformation.Create oType
            Name = name
       }