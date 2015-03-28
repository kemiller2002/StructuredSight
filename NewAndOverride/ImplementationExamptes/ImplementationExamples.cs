using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ImplementationExamptes
{
    [TestClass]
    public class ImplementationExamples
    {

        /*Calling hello world from class */
        [TestMethod]
        public void ParentClassSayingHelloWorld()
        {
            var parentClass = new NewAndOverrideClasses.ParentClass();

            System.Diagnostics.Debug.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);
            System.Diagnostics.Debug.WriteLine(parentClass.SayHelloWorld());
        }

        [TestMethod]
        public void ChildClassSayingHelloWorld()
        {
            var childClass = new NewAndOverrideClasses.ChildClassOverride();

            System.Diagnostics.Debug.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);
            System.Diagnostics.Debug.WriteLine(childClass.SayHelloWorld());
        }

        [TestMethod]
        public void ChildClassWithNewMethodSayingHelloWorld()
        {
            var childClass = new NewAndOverrideClasses.ChildClassNew();

            System.Diagnostics.Debug.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);
            System.Diagnostics.Debug.WriteLine(childClass.SayHelloWorld());
        }


        /*Calling Hello World From Helper Method*/
        [TestMethod]
        public void ParentClassCallingHelperMethod()
        {
            var parentClass = new NewAndOverrideClasses.ParentClass();

            System.Diagnostics.Debug.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);
            System.Diagnostics.Debug.WriteLine(parentClass.CallMethodToSayHelloWorld());
        }

        [TestMethod]
        public void ChildClassCallingHelperMethod()
        {
            var childClass = new NewAndOverrideClasses.ChildClassOverride();

            System.Diagnostics.Debug.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);
            System.Diagnostics.Debug.WriteLine(childClass.CallMethodToSayHelloWorld());
        }

        [TestMethod]
        public void ChildClassWithNewMethodCallingHelperMethod()
        {
            var childClass = new NewAndOverrideClasses.ChildClassNew();

            System.Diagnostics.Debug.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);
            System.Diagnostics.Debug.WriteLine(childClass.CallMethodToSayHelloWorld());
        }



        /*Explicit Parent Class Instantiation*/
        [TestMethod]
        public void ParentClassExplicitParentClass()
        {
            NewAndOverrideClasses.ParentClass parentClass = new NewAndOverrideClasses.ParentClass();

            System.Diagnostics.Debug.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);
            System.Diagnostics.Debug.WriteLine(parentClass.SayHelloWorld());
        }

        [TestMethod]
        public void ChildClassExplicitParentClassOverridden()
        {
            NewAndOverrideClasses.ParentClass childClass = new NewAndOverrideClasses.ChildClassOverride();

            System.Diagnostics.Debug.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);
            System.Diagnostics.Debug.WriteLine(childClass.SayHelloWorld());
        }

        [TestMethod]
        public void ChildClassExplicitParentClassNewMethod()
        {
            NewAndOverrideClasses.ParentClass childClass = new NewAndOverrideClasses.ChildClassNew();

            System.Diagnostics.Debug.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);
            System.Diagnostics.Debug.WriteLine(childClass.SayHelloWorld());
        }











        /*Parent Interface*/
        [TestMethod]
        public void ParentClassExplicitInterface()
        {
            NewAndOverrideClasses.IHelloWorld parentClass = new NewAndOverrideClasses.ParentClass();

            System.Diagnostics.Debug.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);
            System.Diagnostics.Debug.WriteLine(parentClass.SayHelloWorld());
        }

        [TestMethod]
        public void ChildClassExplicitInterfaceOverridden()
        {
            NewAndOverrideClasses.IHelloWorld childClass = new NewAndOverrideClasses.ChildClassOverride();

            System.Diagnostics.Debug.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);
            System.Diagnostics.Debug.WriteLine(childClass.SayHelloWorld());
        }

        [TestMethod]
        public void ChildClassExplicitInterfaceNewMethod()
        {
            NewAndOverrideClasses.IHelloWorld childClass = new NewAndOverrideClasses.ChildClassNew();

            System.Diagnostics.Debug.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);
            System.Diagnostics.Debug.WriteLine(childClass.SayHelloWorld());
        }






        /*Casting*/
        [TestMethod]
        public void CastingToParentClass()
        {
            NewAndOverrideClasses.ParentClass childClass = new NewAndOverrideClasses.ChildClassNew();

            System.Diagnostics.Debug.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);
            System.Diagnostics.Debug.WriteLine(((NewAndOverrideClasses.ChildClassNew)childClass).SayHelloWorld());
        }



    }
}
