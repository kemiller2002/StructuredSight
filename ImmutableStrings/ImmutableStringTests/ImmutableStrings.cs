using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ImmutableStringsExamples;

namespace ImmutableStringTests
{
    [TestClass]
    public class ImmutableStrings
    {
        [TestMethod]
        public void MutateSeasonsGreetingsString()
        {
            var immutableStrings = new ImmutableStringsExample();

            Console.WriteLine(immutableStrings.SeasonsGreetings);

            immutableStrings.MutateSeasonsGreetingsString();

            Console.WriteLine(immutableStrings.SeasonsGreetings);
        }

        [TestMethod]
        public void MutateLocalSeasonsGreetings()
        {

            var immutableStrings = new ImmutableStringsExample();

            immutableStrings.MutateLocalSeasonsGreetingsString();

            Console.WriteLine(immutableStrings.SeasonsGreetings);

        }


        [TestMethod]
        public void MutateCopyOfSeasonsGreetings()
        {

            var immutableStrings = new ImmutableStringsExample();

            immutableStrings.MutateCopyofSeasonsGreetings();

            Console.WriteLine
                ($"Class Variable Seasons Greetings After Method Run: {immutableStrings.SeasonsGreetings}");

        }

        [TestMethod]
        public void MutatePiecedTogetherCopyOfSeasonsGreetings()
        {

            var immutableStrings = new ImmutableStringsExample();

            immutableStrings.MutatePiecedTogetherSeasonsGreetings();

            Console.WriteLine
                ($"Class Variable Seasons Greetings After Method Run: {immutableStrings.SeasonsGreetings}");

        }

        [TestMethod]
        public void MutateTestCopyOfSeasonsGreetings()
        {
            string testSeasonsGreetings = "Bah Humbug!!!!!";

            Console.WriteLine($"Before running method: {testSeasonsGreetings}");

            var immutableStrings = new ImmutableStringsExample();

            immutableStrings.MutateSeasonsGreetingsString();

            Console.WriteLine($"After running method: {testSeasonsGreetings}");
        }

        [TestMethod]
        public void MutateLocalCopyOfStringInOtherMethod()
        {
            var immutableStrings = new ImmutableStringsExample();
            immutableStrings.MutateSeasonsGreetingsString();

            var secondInstance = new ImmutableStringsExample();

            Console.WriteLine(
                $"Second instance return from method: {secondInstance.ReturnLocalCopyOfSeaonsGreetings()}");

            Console.WriteLine(
                $"Static method variable: " +
                $"{ImmutableStringsExample.ReturnLocalCopyOfSeaonsGreetingsFromStaticMethod()}");
        }

        [TestMethod]
        public void TryMutateCopyOfSeasonsGreetingsInSecondAssembly()
        {
            string TestSeasonsGreetings = "Bah Humbug!!!!!";

            var immutableStrings = new ImmutableStringsExample();
            immutableStrings.MutateSeasonsGreetingsString();

            Console.WriteLine(TestSeasonsGreetings);

            var secondSeasonsGreetings = 
                new SecondLibraryOfImmutableStringsExamples.SecondClassOfImmutableStringsExamples();

            Console.WriteLine($"Class variable: {secondSeasonsGreetings.SeasonsGreetings}");
            Console.WriteLine(
                $"Static variable: " +
                $@"{SecondLibraryOfImmutableStringsExamples.
                    SecondClassOfImmutableStringsExamples.
                    StaticSeasonsGreetings}");

        }

    }
}
