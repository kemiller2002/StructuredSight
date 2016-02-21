namespace StructuredSight.Web.Api.Controller.UnitTests

open NUnit.Framework
open System.Web.Http
open System.Web
open StructuredSight.Web.Api
open Newtonsoft.Json
[<TestFixture>]
type Output () = 

    [<Test>]
    member this.ControllerOutput () = 
       let controllerInfo = ControllerInformation.Create typeof<TestController>

       let json = JsonConvert.SerializeObject(controllerInfo)

       System.Console.WriteLine json
       
    
    [<Test>]
    member this.TypeOutput () = 
       let controllerInfo = ControllerInformation.Create typeof<TestController>
       let types = ControllerInformation.CreateTypeEntriesForControllers [controllerInfo]

       let json = JsonConvert.SerializeObject(types)

       System.Console.WriteLine json
       