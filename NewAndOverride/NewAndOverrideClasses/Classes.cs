using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewAndOverrideClasses
{


    public interface IHelloWorld
    {
        string SayHelloWorld () ;
    }

    public class ParentClass : IHelloWorld
    {

        public virtual string SayHelloWorld()
        {
            return "This is the virtual method.";
        }


        public string CallMethodToSayHelloWorld()
        {
            return SayHelloWorld();
        }


        public string ExampleOfChangingProperties()
        {
            return "base example.";
        }

    }


    public class ChildClassOverride : ParentClass
    {
        public override string SayHelloWorld()
        {
            return "This is the overridden method.";
        }
    }

    public class ChildClassNew : ParentClass  /*IHelloWorld*/
    {
        public new string SayHelloWorld()
        {
            return "This is the new method.";
        }


        public new void ExampleOfChangingProperties(string newParemeter)
        {
            System.Diagnostics.Debug.WriteLine(newParemeter);
        }

    }
    


}
