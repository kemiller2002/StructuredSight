using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamplesDotNetFramework
{
    class IsExamples
    {

        public static void ShowIsType ()
        {
            string jennysNumber = "867-5309";

           Console.WriteLine(jennysNumber is string);
        }

        public static void ShowIsTypeWithVar()
        {
            var jennysNumber = "867-5309";

            Console.WriteLine(jennysNumber is string);
        }


        public static void ShowIsTypeNull ()
        {
            string jennysNumber = null;

            Console.WriteLine(jennysNumber is string);
        }

        public static void ShowIsTypeWithQuestion ()
        {
            string jennysNumber = "867-5309";

            Console.WriteLine("What is Jenny's Number? " + jennysNumber is string);
        }

        public static void ShowIsTypeWithQuestionWithParentheses()
        {
            string jennysNumber = "867-5309";

            Console.WriteLine("What is Jenny's Number? " + (jennysNumber is string));
        }

        public static void ShowIsTypeWithInt ()
        {

            int jennysNumber = 8675309;

            Console.WriteLine("What is Jenny's Number? " + jennysNumber is int);
        }
    }
}
