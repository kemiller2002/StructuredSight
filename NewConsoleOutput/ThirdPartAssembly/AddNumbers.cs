using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace ThirdPartAssembly
{
    public static class AddNumbers
    {
        public static int Add(int number, int number2)
        {
            var result = number + number2;

            Console.WriteLine($"{number} + {number2} = {result}");

            return result;
        }

    }
}
