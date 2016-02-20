namespace StructuredSight.Web.Api
open System

    type Action =
        | Get 
        | Post 
        | Put 
        | Delete 

    type Name = {Name:string; Namespace:Option<string>}

    type ObjectType = {Name:Name;}

    type Variable = {ObjectType:ObjectType; Name:Name}

    type Parameter = {Variable:Variable; FromBody:bool}

    type Method = {Name:Name; Parameters:ObjectType seq; Actions : Action seq; Route:string }

    type Controller = {Name:Name; RoutePrefix: Option<string>; Methods:Method seq}

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


    let Create (controller:Type) = 
        {
            Name = GetName (controller);
            RoutePrefix = GetRoutePrefixAttribute controller;
            Methods = Seq.empty<Method>
        }
    