using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Dynamic;
using StructuredSite.ApplicationBusinessLogic;


namespace UnitTestProject1
{
    [TestClass]
    public class ApplicationUnitTestCode
    {
        [TestMethod]
        public void TestConstructor()
        {
            dynamic iDataInterface = new ExpandoObject();

            var bLogic = new BusinessLogic(iDataInterface);



        }
    }
}
