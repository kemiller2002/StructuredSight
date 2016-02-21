namespace StructuredSight.Web.Api.Controller.UnitTests

open NUnit.Framework
open System.Web.Http
open System.Web
open StructuredSight.Web.Api

type TestType () = 
    let mutable propertyValue : string = "this is a value"

    member this.Property 
        with get () = propertyValue
        and set (value) = propertyValue <- value


[<RoutePrefix("TestPath")>]
type TestController () = 
     inherit System.Web.Http.ApiController ()
        
     [<Route("Test")>]
     [<AcceptVerbs("post")>]
     member this.Test() = new TestType()