namespace StructuredSight.Web.Api
open System
open System.Reflection
open StructuredSight
open System.Web

type Action =
        | Get 
        | Post 
        | Put 
        | Delete 
        | Custom of string

type Name = {Name:string; Namespace:Option<string>}

type TypeReference = {Name:Name}

type Variable = {ObjectType:TypeReference; Name:String;}

type ObjectType = {Name:Name; Properties : Variable seq}

type Parameter = {Variable:Variable; FromBody:bool; HasDefaultValue:bool}

type Method = {Name:Name; Parameters:Parameter seq; Actions : Action seq; 
    Route:Option<string>; ReturnType: Option<TypeReference>; }

type Controller = {Name:Name; RoutePrefix: Option<string>; Methods:Method seq}


module NameInformation = 
    let GetName (oType:Type) = 
        {
            Name = oType.Name;
            Namespace = if String.IsNullOrWhiteSpace oType.Namespace then None else Some oType.Namespace;
        }


module TypeReferenceInformation = 
    let Create (oType:Type) = 
        {
            TypeReference.Name = NameInformation.GetName(oType)
        } 


module VariableInformation =
    let Create (name:string, oType:Type) = 
       {
            Variable.ObjectType = TypeReferenceInformation.Create oType
            Name = name
       }

module ParameterInformation = 
    let HasFromBody (pi:ParameterInfo) = 
        pi.GetCustomAttributes() |> 
            Seq.exists
                (
                    fun x-> 
                            x.GetType().Name
                                .Equals("FromBodyAttribute", StringComparison.OrdinalIgnoreCase)
                )

    let Create (pi:ParameterInfo) = 
        {
            Variable = VariableInformation.Create (pi.Name , pi.ParameterType);
            FromBody = HasFromBody pi
            HasDefaultValue = pi.HasDefaultValue
        }

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
    