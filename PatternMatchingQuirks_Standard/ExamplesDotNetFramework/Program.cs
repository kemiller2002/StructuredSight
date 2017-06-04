using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamplesDotNetFramework
{

    class Program
    {


        static void BaseExampleIsString ()
        {
            string jennysNumber = "867-5309";

            if(jennysNumber is string)
            {
                Console.WriteLine("The variable is a string");
            }

            switch (jennysNumber)
            {
                case string s:
                    Console.WriteLine("The switch statement recognizes the variable is a string: " + s);
                    break;
                default:
                    Console.WriteLine("The default statement was triggered");
                    break;
            }
        }


        static void BaseExampleNull ()
        {
            string jennysNumber = null;
            switch (jennysNumber)
            {
                case string s when (s is null):
                    Console.WriteLine("The variable is of type string and is null");
                    break;
                case string s:
                    Console.WriteLine("The variable is of type string");
                    break;
                default:
                    Console.WriteLine("This is the default statement.");
                    break;
            }
        }



        static void Main(string[] args)
        {
            //Execute(BaseExampleIsString);
            Execute(BaseExampleNull);
            // Execute(IsExamples.ShowIsType);
            // Execute(IsExamples.ShowIsTypeWithVar);
            // Execute(IsExamples.ShowIsTypeNull);
            // Execute(IsExamples.ShowIsTypeWithQuestion);
            // Execute(IsExamples.ShowIsTypeWithQuestionWithParentheses);
            // Execute(IsExamples.ShowIsTypeWithQuestionFlipped);
            // Execute(PatternMatchingExamples.NullExample);
            // Execute(PatternMatchingExamples.NullWithObjectExample);
            // Execute(PatternMatchingExamples.VarCase);
            //Execute(PatternMatchingExamples.ObjectCase);

            //Execute(IsExamples.ShowCanDetermineNull);
            

            Console.ReadLine();
        }

        static void Execute (Action method)
        {
            Console.WriteLine("***** Starting  : " + method.Method.Name + " *****");
            Console.WriteLine();

            method();

            Console.WriteLine();
            Console.WriteLine("***** Ending : " + method.Method.Name + " *****");
            Console.WriteLine(System.Environment.NewLine);
        }


    }
}
