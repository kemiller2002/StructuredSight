namespace StructuredSight.Web.Api.Controller.UnitTests

open NUnit.Framework
open System.Web.Http
open System.Web
open StructuredSight.Web.Api
open System.Reflection
open UnitTests

[<TestFixture>]
type TypeTests () = 
    
    [<Test>]
    member this.GetName() = 
        let name = TypeInformation.GetName typeof<TestType>
        Assert.AreEqual("TestType", name.Name)
            

    [<Test>]
    member this.GetNamespace () = 
        let name = TypeInformation.GetName typeof<TestType>
        Assert.AreEqual("StructuredSight.Web.Api.Controller.UnitTests", name.Namespace.Value)


    [<Test>]
    member this.GetProperties () = 
        let properties = (TypeInformation.Create typeof<TestType>).Properties

        Assert.AreEqual(1, (Seq.length properties))
        Assert.AreEqual("String", (Seq.head properties).ObjectType.Name.Name)
        Assert.AreEqual("Property", (Seq.head properties).Name)
    
