using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticClassTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var harness = new TestHarnessProject.TestHarness(Console.WriteLine);


            harness.ManyObjectAttempt_String();
            harness.StaticAttempt_String();
            harness.OneObjectAttempt_String();
            harness.ManyStructAttempt_String();

            Console.ReadLine();

        }
    }
}
