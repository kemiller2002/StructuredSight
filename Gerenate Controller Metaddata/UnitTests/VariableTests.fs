namespace StructuredSight.Web.Api.Controller.UnitTests

open NUnit.Framework
open System.Web.Http
open System.Web
open StructuredSight.Web.Api
open System.Reflection
open UnitTests

[<TestFixture>]
type VariableTests () = 
    
    [<Test>]
    member this.GetName () = 
       let name = VariableInformation.GetName typeof<TestType>
       Assert.AreEqual("TestType", name.Name)

    [<Test>]
    member this.GetNamespace () = 
        let name = VariableInformation.GetName typeof<TestType>
        Assert.AreEqual("StructuredSight.Web.Api.Controller.UnitTests", name.Namespace.Value)

