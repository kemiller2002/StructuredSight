using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewAndOverrideClasses
{
    public static class StaticCallHelloWorld
    {
        public static string CallHelloWorld(ParentClass parent)
        {
            return parent.SayHelloWorld();
        }

        public static string CallHelloWorld(ChildClassNew child)
        {
            return child.SayHelloWorld();
        }

    }
}
