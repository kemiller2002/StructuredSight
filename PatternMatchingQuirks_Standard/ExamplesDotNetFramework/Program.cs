using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamplesDotNetFramework
{

    class Program
    {
        static void Main(string[] args)
        {
            Execute(IsExamples.ShowIsType);
            Execute(IsExamples.ShowIsTypeWithVar);
            Execute(IsExamples.ShowIsTypeNull);
            Execute(IsExamples.ShowIsTypeWithQuestion);
            Execute(IsExamples.ShowIsTypeWithQuestionWithParentheses);


            Console.ReadLine();
        }

        static void Execute (Action method)
        {
            Console.WriteLine("Starting  : " + method.Method.Name);

            method();

            Console.WriteLine("Ending : " + method.Method.Name);
            Console.WriteLine(System.Environment.NewLine);
        }


    }
}
