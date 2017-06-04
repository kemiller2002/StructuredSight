using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamplesDotNetFramework
{
    class PatternMatchingExamples
    {
        public static void NullExample ()
        {
            string jennysNumber = null;

            switch (jennysNumber)
            {
                case string s:
                    Console.WriteLine("It's a string and it's null");
                break;

                case null:
                    Console.WriteLine("There is no Jenny's Number");
                    break;

                default:
                    Console.WriteLine("This is the default case.");
                    break;
            }
        }

        
         
        public static void NullWithObjectExample ()
        {
            Object jennysNumber = null;

            switch (jennysNumber)
            {

                case string s:
                    Console.WriteLine("This is a string");
                break;
                case Object o:
                    Console.WriteLine("It's an object");
                break;
                case null:
                    Console.WriteLine("This is the null case");
                break;

            }
        }
         
         



    }
}
