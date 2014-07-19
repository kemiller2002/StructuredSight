using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lamdas
{
    class Program
    {
        static void Main(string[] args)
        {
            delegate lamda = () => "I AM A LAMDA;";
            var func = new Func<string> (() => {return "I AM A FUNC";});
        }
    }
}
