namespace StructuredSight.Web.Api.Controller.UnitTests
open NUnit.Common

open NUnit.Framework
open System.Web.Http
open System.Web
open StructuredSight.Web.Api
open UnitTests



    [<TestFixture>]
    type ControllerTests () = 

        [<Test>]
        member this.GetName () = 
          let name = ControllerInformation.GetName typeof<TestController>
          Assert.AreEqual ("TestController", name.Name)
        
        [<Test>]
        member this.GetNamespace () = 
          let name = ControllerInformation.GetName typeof<TestController>
          Assert.AreEqual ("StructuredSight.Web.Api.Controller.UnitTests", name.Namespace.Value)

        [<Test>]
        member this.CheckControllerName () = 
            let ci = ControllerInformation.Create (typeof<TestController>)
            Assert.AreEqual("TestController", ci.Name.Name)

        [<Test>]
        member this.CheckRoutePrefix () = 
            let ci = ControllerInformation.Create (typeof<TestController>)
            Assert.AreEqual("TestPath", ci.RoutePrefix.Value)