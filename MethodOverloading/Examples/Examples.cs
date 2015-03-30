using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Examples
{
    [TestClass]
    public class Examples
    {
        [TestMethod]
        public void ShowParentExample()
        {
            var parent = new MethodOverloading.Parent ();

            System.Diagnostics.Debug.WriteLine(parent.FormatMessage("Hello World"));
        }


        [TestMethod]
        public void ShowChildExample()
        {
            var child = new MethodOverloading.Child();

            System.Diagnostics.Debug.WriteLine(child.FormatMessage("Hello World"));
        }

        [TestMethod]
        public void ShowChildExampleDeclaredAsParent()
        {
            MethodOverloading.Parent typeParent = new MethodOverloading.Child();
            MethodOverloading.Child typeChild = (MethodOverloading.Child)typeParent;


            System.Diagnostics.Debug.WriteLine("Variable type parent");
            System.Diagnostics.Debug.WriteLine(typeParent.FormatMessage("Hello World"));


            System.Diagnostics.Debug.WriteLine("");
            System.Diagnostics.Debug.WriteLine("Variable type child");
            System.Diagnostics.Debug.WriteLine(typeChild.FormatMessage("Hello World"));

        
        }


        [TestMethod]
        public void ShowParentAppendExample()
        {
            var parent = new MethodOverloading.Parent();

            System.Diagnostics.Debug.WriteLine(parent.AppendAndFormat("Hello World", "!"));
        }


        [TestMethod]
        public void ShowChildAppendExample()
        {
            var child = new MethodOverloading.Child();

            System.Diagnostics.Debug.WriteLine(child.AppendAndFormat("Hello World", "!"));
        }



        /*equal overloads*/

        [TestMethod]
        public void EqualOverloadString()
        {
            var equalOverload = new MethodOverloading.EqualOverloads();

            System.Diagnostics.Debug.WriteLine(equalOverload.FormatMessage("Hello World"));
        }

        [TestMethod]
        public void EqualOverloadObject()
        {
            var equalOverload = new MethodOverloading.EqualOverloads();

            System.Diagnostics.Debug.WriteLine(equalOverload.FormatMessage((object)"Hello World"));
        }


    }
}
