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

    public interface IGreetings: IHelloWorld
    {
        string SayGoodBye();
    }


    public class ParentClass : IHelloWorld
    {

        public virtual string SayHelloWorld()
        {
            return "This is the base method.";
        }


        public string CallMethodToSayHelloWorld()
        {
            return SayHelloWorld();
        }
    }


   

    public class ChildClassNew : ParentClass//, IGreetings
    {
        public new string SayHelloWorld()
        {
            return "This is the new method.";
        }

        public string SayGoodBye()
        {
            return "Goodbye.";
        }

    }

    public class ChildClassOverride : ParentClass
    {
        public override string SayHelloWorld()
        {
            return "This is the overridden method.";
        }
    }

}
