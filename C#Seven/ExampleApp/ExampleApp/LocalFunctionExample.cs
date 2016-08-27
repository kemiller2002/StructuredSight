using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleApp
{
    public class LocalFunctionExample
    {
        public int AddFactorialNumbers (int number)
        {
            int Multiply (int innerNumber) => 
                 (innerNumber == 1) ? 1 : innerNumber * Multiply(innerNumber - 1);
   
            return Multiply(number);
        }
    }
}
