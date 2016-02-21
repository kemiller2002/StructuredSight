namespace StructuredSight.Web.Api


type Action =
        | Get 
        | Post 
        | Put 
        | Delete 
        | Custom of string

type Name = {Name:string; Namespace:Option<string>}

type TypeReference = {Name:Name}

type Variable = {ObjectType:TypeReference; Name:string;}

type ObjectType = {Name:Name; Properties : Variable seq}

type Parameter = {Variable:Variable; FromBody:bool; HasDefaultValue:bool}

type Method = {Name:Name; Parameters:Parameter seq; Actions : Action seq; 
    Route:Option<string>; ReturnType: Option<TypeReference>; }

type Controller = {Name:Name; RoutePrefix: Option<string>; Methods:Method seq}
