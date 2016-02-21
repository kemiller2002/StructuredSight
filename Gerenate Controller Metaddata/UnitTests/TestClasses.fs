namespace StructuredSight.Web.Api.Controller.UnitTests

open NUnit.Framework
open System.Web.Http
open System.Web
open StructuredSight.Web.Api


[<Struct>]
type NestedType = 
    member this.PointProperty:int = 0
        

type TestTypeWithNesting () = 
    let mutable pointProperty : NestedType = new NestedType()

    member this.Property 
        with get () = pointProperty
        and set (value) = pointProperty <- value

type TestType () = 
    let mutable propertyValue : string = "this is a value"

    member this.Property 
        with get () = propertyValue
        and set (value) = propertyValue <- value


[<RoutePrefix("TestPathWithNesting")>]
type TestControllerWithNesting () = 
     inherit System.Web.Http.ApiController ()
        
     [<Route("Test")>]
     [<AcceptVerbs("post")>]
     member this.Test([<FromBody>] bodyParameter:string) = new TestTypeWithNesting()

[<RoutePrefix("TestPath")>]
type TestController () = 
     inherit System.Web.Http.ApiController ()
        
     [<Route("Test")>]
     [<AcceptVerbs("post")>]
     member this.Test([<FromBody>] bodyParameter:string) = new TestType()