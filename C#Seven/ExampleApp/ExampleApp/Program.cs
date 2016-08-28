using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleApp
{
    struct NameAndPhone {
        public string Name;
        public string Phone; 
    }

    class Program
    {
        static void Main(string[] args)
        {
            var local = new LocalFunctionExample();

            var localFunctionMethods = typeof(LocalFunctionExample)
                    .GetMethods(System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);

            var iterations = 100000;
            var localFunctionTime = TimeLocalFunction(iterations);
            var lambdaFunctionTime = TimeLambda(iterations);
        }


        static double TimeLocalFunction (int iterations)
        {
            var localFunctionExample = new LocalFunctionExample();
            var stopwatch = new System.Diagnostics.Stopwatch();

            stopwatch.Start();

            for(var ii = 0; ii < iterations; ii++)
            {
                localFunctionExample.MakeFirstCharacterUpperCase("jenny");    
            }

            stopwatch.Stop();

            return stopwatch.ElapsedTicks;
        }


        static double TimeLambda(int iterations)
        {
            var localFunctionExample = new LocalFunctionExample();
            var stopwatch = new System.Diagnostics.Stopwatch();

            stopwatch.Start();

            for (var ii = 0; ii < iterations; ii++)
            {
                localFunctionExample.MakeUpperCaseWithLamda("jenny");
            }

            stopwatch.Stop();

            return stopwatch.ElapsedTicks;
        }



        public static (string, string) ChangeNameToJenny((string, string) nameAndPhone)
        {
            nameAndPhone.Item1 = "Jenny";
            return nameAndPhone;
        }

        public static NameAndPhone ChangeNameToJenny (NameAndPhone nameAndPhone)
        {
            nameAndPhone.Name = "Jenny";

            return nameAndPhone;

        }



    }
}
