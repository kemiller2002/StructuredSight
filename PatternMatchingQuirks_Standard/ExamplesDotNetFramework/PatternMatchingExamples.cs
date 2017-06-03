using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamplesDotNetFramework
{
    class PatternMatchingExamples
    {
        static void NullExample ()
        {
            string jennysNumber = "867-5309";

            switch (jennysNumber)
            {

                case null:
                    Console.WriteLine("There is no Jenny's Number");
                    break;
                case string s:
                    Console.WriteLine("Well at least it is a string");
                    break;


            }


        }



    }
}
