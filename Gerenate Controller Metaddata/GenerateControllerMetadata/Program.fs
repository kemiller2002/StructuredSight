namespace StructuredSight.Web.Api
open System
open System.Reflection
open StructuredSight


type Action =
        | Get 
        | Post 
        | Put 
        | Delete 

type Name = {Name:string; Namespace:Option<string>}

type ObjectType = {Name:Name;}

type Variable = {ObjectType:ObjectType; Name:Name}

type Parameter = {Variable:Variable; FromBody:bool}

type Method = {Name:Name; Parameters:Parameter seq; Actions : Action seq; Route:Option<string> }

type Controller = {Name:Name; RoutePrefix: Option<string>; Methods:Method seq}


module TypeInformation = 
    let GetName (oType:Type) = 
        {
            Name = oType.Name;
            Namespace = if String.IsNullOrWhiteSpace oType.Namespace then None else Some oType.Namespace;
        }

    let Create (oType:Type) =
        {
            ObjectType.Name = GetName oType;

        }

module VariableInformation =
    let GetName (oType:Type) = 
        {
            Name = oType.Name;
            Namespace = if String.IsNullOrWhiteSpace oType.Namespace then None else Some oType.Namespace
        } 

    let Create (oType:Type) = 
       {
            Variable.ObjectType = TypeInformation.Create oType
            Name = GetName oType
       }

module ParameterInformation = 
    let Create (oType:Type) = 
        {
            Parameter.FromBody = false
            Variable = VariableInformation.Create oType
        }


module MethodInformation = 
    let GetName (mi:MethodInfo) = 
        {
            Name = mi.Name;
            Namespace = None;
        }
    
    let Create (mi:MethodInfo) = 
       {
            Name = GetName mi;
            Parameters =    mi.GetParameters() |> 
                            Seq.map(fun x -> x.ParameterType ) |> 
                            Seq.map(ParameterInformation.Create);

            Actions = Seq.empty<Action>;
            Route = None
       }

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
    