namespace StructuredSight.Web.Api
open System
open System.Reflection
open StructuredSight
open System.Web


module MethodInformation = 
    let GetName (mi:MethodInfo) = 
        {
            Name = mi.Name;
            Namespace = None;
        }
    
    let GetRoute (mi:MethodInfo)= 
        let routes = 
            mi.GetCustomAttributes() |> 
            Seq.where(fun x->x.GetType().Name = "RouteAttribute") |>
            Seq.map(fun x-> x :?> System.Web.Http.RouteAttribute)
            
        if Seq.isEmpty routes then None
        else Some ((Seq.head routes).Template)

    let MapHttpMethod (methodName:string) = 
        match methodName.ToLower() with 
        | "get" -> Action.Get
        | "put" -> Action.Post 
        | "delete" -> Action.Delete
        | "post" -> Action.Post
        | _ as a -> Action.Custom(a)

    let GetAction (mi:MethodInfo) = 
        
        let ats = 
            mi.GetCustomAttributes() |> 
            Seq.where(fun x-> x.GetType().Name = "AcceptVerbsAttribute") |>
            Seq.map (fun x -> x :?> System.Web.Http.AcceptVerbsAttribute) |>
            Seq.map(fun x-> x.HttpMethods) |>
            Seq.concat |>
            Seq.map(fun x-> x.Method) |>
            Seq.map(MapHttpMethod)
            
        seq {    
                match ats with
                | ats when Seq.length ats > 0 -> yield! ats
                | _ ->  if "put,post,get,delete".Contains(mi.Name.ToLower()) then
                            yield MapHttpMethod mi.Name
            }
            
    let Create (mi:MethodInfo) = 
       {
            Name = GetName mi;
            Parameters =    mi.GetParameters() |>  
                            Seq.map(ParameterInformation.Create);

            Actions = GetAction mi;
            Route = GetRoute mi;
            ReturnType = 
                if mi.ReturnType = null then None
                else Some (TypeReferenceInformation.Create mi.ReturnType)
       }
