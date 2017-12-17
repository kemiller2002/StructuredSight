using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImmutableStringsExamples
{
    public class ImmutableStringsExample
    {
        public readonly string SeasonsGreetings = "Bah Humbug!!!!!";

        static void Main(string[] args)
        {
            var examples = new ImmutableStringsExample();

            examples.MutateSeasonsGreetingsString();

            examples.MutateLocalSeasonsGreetingsString();
        }

        public string ReturnLocalCopyOfSeaonsGreetings ()
        {
            return "Bah Humbug!!!!!";
        }

        public static string ReturnLocalCopyOfSeaonsGreetingsFromStaticMethod()
        {
            return "Bah Humbug!!!!!";
        }

        public unsafe void MutateSeasonsGreetingsString ()
        {
            var happyHolidays = "Happy Holidays!";

            fixed (char* seasonsGreetingsLocation = SeasonsGreetings)
            {
                for(var ii = 0; ii < happyHolidays.Length; ii++)
                {
                    seasonsGreetingsLocation[ii] = happyHolidays[ii];
                }
            }

        }

        public unsafe void MutateLocalSeasonsGreetingsString ()
        {
            string localSeasonsGreetings = SeasonsGreetings;

            var happyHolidays = "Happy Holidays!";

            fixed (char* seasonsGreetingsLocation = localSeasonsGreetings)
            {
                for (var ii = 0; ii < happyHolidays.Length; ii++)
                {
                    seasonsGreetingsLocation[ii] = happyHolidays[ii];
                }
            }
        }

        public unsafe void MutateCopyofSeasonsGreetings()
        {
            string localSeasonsGreetings = "Bah Humbug!!!!!";

            Console.WriteLine($"Local Seasons Greetings: {localSeasonsGreetings}");
            Console.WriteLine($"Class Variable Seasons Greetings: {SeasonsGreetings}");

            Console.WriteLine
               ($"Are the two variables equal: " +
                   $"{localSeasonsGreetings.Equals(SeasonsGreetings)}");

            var happyHolidays = "Happy Holidays!";

            fixed (char* seasonsGreetingsLocation = localSeasonsGreetings)
            {
                for (var ii = 0; ii < happyHolidays.Length; ii++)
                {
                    seasonsGreetingsLocation[ii] = happyHolidays[ii];
                }
            }

            Console.WriteLine("Modification has run.");

            Console.WriteLine
                ($"Are the two variables equal: " +
                    $"{localSeasonsGreetings.Equals(SeasonsGreetings)}");
        }

        public unsafe void MutateCopyofSecondSeasonsGreetings()
        {
            string localSeasonsGreetings = "Bah Humbug!!!!!";

            Console.WriteLine($"Local Seasons Greetings: {localSeasonsGreetings}");
            Console.WriteLine($"Class Variable Seasons Greetings: {SeasonsGreetings}");

            Console.WriteLine
               ($"Are the two variables equal: " +
                   $"{localSeasonsGreetings.Equals(SeasonsGreetings)}");

            var happyHolidays = "Happy Holidays!";

            fixed (char* seasonsGreetingsLocation = localSeasonsGreetings)
            {
                for (var ii = 0; ii < happyHolidays.Length; ii++)
                {
                    seasonsGreetingsLocation[ii] = happyHolidays[ii];
                }
            }

            Console.WriteLine("Modification has run.");

            Console.WriteLine
                ($"Are the two variables equal: " +
                    $"{localSeasonsGreetings.Equals(SeasonsGreetings)}");
        }

        public unsafe void MutatePiecedTogetherSeasonsGreetings()
        {
            string exclamations = "!!!!!";
            string localSeasonsGreetings = "Bah Humbug" + exclamations;

            Console.WriteLine($"Local Seasons Greetings: {localSeasonsGreetings}");
            Console.WriteLine($"Class Variable Seasons Greetings: {SeasonsGreetings}");
            Console.WriteLine
                ($"Are the two variables equal: " +
                    $"{localSeasonsGreetings.Equals(SeasonsGreetings)}");

            var happyHolidays = "Happy Holidays!";

            fixed (char* seasonsGreetingsLocation = localSeasonsGreetings)
            {
                for (var ii = 0; ii < happyHolidays.Length; ii++)
                {
                    seasonsGreetingsLocation[ii] = happyHolidays[ii];
                }
            }   

            Console.WriteLine("Modification has run.");

            Console.WriteLine
                ($"Are the two variables equal: " +
                    $"{localSeasonsGreetings.Equals(SeasonsGreetings)}");
        }

    }
}
