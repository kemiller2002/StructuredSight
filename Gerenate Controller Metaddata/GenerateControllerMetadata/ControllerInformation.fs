namespace StructuredSight.Web.Api
open System
open System.Reflection
open StructuredSight
open System.Web



module ControllerInformation = 
    let GetName (controller: Type) = 
        {
            Name = controller.Name;
            Namespace = Some controller.Namespace
        }

    let GetRoutePrefixAttribute (controller:Type) = 
        let paths = 
            controller.GetCustomAttributes(true) |> 
            Seq.where (fun x -> x.GetType().Name = "RoutePrefixAttribute" ) |>
            Seq.map (fun x-> x :?> System.Web.Http.RoutePrefixAttribute) |>
            Seq.map (fun x-> x.Prefix)

        match paths with 
        | paths when paths |> Seq.isEmpty -> None
        | _ as paths -> Some <| Seq.head paths


    let IsControllerMethod (mi:MethodInfo) = 
        
        mi.IsPublic && 
            ( 
                "get,put,post,delete".Contains(mi.Name.ToLower()) ||
                mi.GetCustomAttributes() |> Seq.exists(fun x->x.GetType().Name = "RouteAttribute")
            )

    let Create (controller:Type) = 
        {
            Name = GetName (controller);
            RoutePrefix = GetRoutePrefixAttribute controller;
            Methods = 
                controller.GetMethods() |> 
                Seq.where(IsControllerMethod) |>
                Seq.map MethodInformation.Create
        }

    let rec IsTypeApiController (t:Type) = 
        match t.BaseType with
        | t when t = typeof<System.Web.Http.ApiController> -> true
        | t when t = typeof<System.Object> -> false
        | _ as t -> IsTypeApiController t

    let FindControllerClasses (types:Type seq) =
        types |> Seq.where IsTypeApiController

    let FindAndConvertControllerClasses(types:Type seq) = 
        types |> FindControllerClasses |> Seq.map Create

    let ConvertControllersInAssembly (assembly:Assembly) = 
        FindAndConvertControllerClasses <| assembly.GetTypes()