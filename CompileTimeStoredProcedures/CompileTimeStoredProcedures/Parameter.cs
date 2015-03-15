using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompileTimeStoredProcedures
{
    public class Parameter : Attribute
    {
        public Parameter(string name) { }

    }
}
