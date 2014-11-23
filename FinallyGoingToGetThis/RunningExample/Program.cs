using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunningExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                throw new Exception("This is a normal exception.");
            }
            finally
            {
                Console.WriteLine("Finally block executed.");
            }
        }

    }
}
