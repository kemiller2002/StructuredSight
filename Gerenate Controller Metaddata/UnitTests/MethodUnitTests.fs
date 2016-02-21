namespace StructuredSight.Web.Api.Controller.UnitTests

open NUnit.Framework
open System.Web.Http
open System.Web
open StructuredSight.Web.Api
open System.Reflection
open UnitTests

[<TestFixture>]
type MethodsTests () = 

    [<Test>]
    member this.GetName () = 
       let members = typeof<TestController>.GetMethods()
       
       let testMethod = members |> Seq.map(fun x -> MethodInformation.GetName x) |> Seq.head

       Assert.AreEqual("Test", testMethod.Name)
    
    [<Test>]
    member this.GetNamespace () = 
       let members = typeof<TestController>.GetMethods()
       
       let testMethod = members |> Seq.map(fun x -> MethodInformation.GetName x) |> Seq.head

       Assert.AreEqual(None, testMethod.Namespace)
    
    [<Test>]
    member this.CheckFromBody () = 
        let members = typeof<TestController>.GetMethods()

        let oneMember = Seq.head members |> MethodInformation.Create

        let fromBody = oneMember.Parameters |> Seq.head |> (fun x->x.FromBody)

        Assert.IsTrue(fromBody)