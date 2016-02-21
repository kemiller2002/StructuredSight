namespace StructuredSight.Web.Api
open System
open System.Reflection
open StructuredSight
open System.Web


module TypeReferenceInformation = 
     let Create (oType:Type) = 
         {
             TypeReference.Name = NameInformation.GetName(oType)
         } 
