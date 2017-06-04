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

        /*
         
                public static void NullExample ()
        {
            string jennysNumber = null; //"867-5309";

            switch (jennysNumber)
            {

                case string s when (s is null):
                    Console.WriteLine("It's a string and it's null");
                break;

                case var s when (s is null):
                    Console.WriteLine("It doesn't know what type it is, but it knows its null");
                break;

                case null:
                    Console.WriteLine("There is no Jenny's Number");
                    break;
                case string s:
                    Console.WriteLine("Well at least it is a string");
                    break;
            }
        }
         
         */



    }
}
