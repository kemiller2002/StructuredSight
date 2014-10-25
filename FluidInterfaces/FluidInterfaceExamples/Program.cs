using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluidInterfaceExamples
{
    class Program
    {
        static void Main(string[] args)
        {

            StringBuilderSingleReplacement();
            MultipleReplacement();

            Console.ReadLine();

        }

        static void StringBuilderSingleReplacement()
        {
            var sw = new System.Diagnostics.Stopwatch();

            sw.Start();

            for (var ii = 0; ii < 1000000; ii++)
            {
                var s = String.Format("Users {0}, {1}, {2}, {4} {5}, {6}, {7}, {8}"
                    , "Jane", "Sally", "Bob", "Steve", "Phil", "Parker", "Sara", "Muffy", "Buffy");
            }

            sw.Stop();
            Console.WriteLine("Single Insertion: {0}", sw.ElapsedTicks);
        }


        static void MultipleReplacement()
        {

                        var sw = new System.Diagnostics.Stopwatch();

            sw.Start();

            for (var ii = 0; ii < 1000000; ii++)
            {
                var sb = new StringBuilder();

                sb.Append("Users ")
                .Append("Jane,")
                .Append("Sally,")
                .Append("Bob,")
                .Append("Steve,")
                .Append("Phil,")
                .Append("Parker,")
                .Append("Sara,")
                .Append("Muffy")
                .Append("Buffy");

                var s = sb.ToString();
            }

            sw.Stop();
            Console.WriteLine("Multiple Insertion: {0}", sw.ElapsedTicks);




        }


        

    }
}
