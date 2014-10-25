using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
namespace TestHarnessProject
{

    public class StaticStringAddition
    {

        public static string AddTwo(string sOne, string sTwo)
        {
            return sOne + sTwo;
        }

        public static int AddTwo(int iOne, int iTwo)
        {
            return iOne + iTwo;
        }


    }


    public struct StructureStringAddition
    {
        public string AddTwo(string sOne, string sTwo)
        {
            return sOne + sTwo;
        }


        public int AddTwo(int iOne, int iTwo)
        {
            return iOne + iTwo;
        }


    }






    public class StringAddition
    {
        public string AddTwo(string sOne, string sTwo)
        {
            return sOne + sTwo;
        }


        public int AddTwo(int iOne, int iTwo)
        {
            return iOne + iTwo;
        }


    }

    
    [TestClass]
    public class TestHarness
    {
        public TestHarness() { }
        public TestHarness(Action<string> opt)
        {
            output = opt;
        }

        int _numberOfIteration = 1000000;

        Action<string> output = new Action<string>(x => { System.Diagnostics.Debug.WriteLine(x); }); 

        [TestMethod]
        public void StaticAttempt_String()
        {
            var stopWatch = new Stopwatch();

            stopWatch.Start();


            for (var ii = _numberOfIteration; ii > 0; ii--)
            {
                var val = StaticStringAddition.AddTwo("Part One", "Part Two");
            }

            stopWatch.Stop();

            output("Elasped Time: " + stopWatch.ElapsedTicks);
        }


        [TestMethod]
        public void OneObjectAttempt_String()
        {
            var stopWatch = new Stopwatch();

            stopWatch.Start();

            var stringAddition = new StringAddition();

            for (var ii = _numberOfIteration; ii > 0; ii--)
            {
                var val = stringAddition.AddTwo("Part One", "Part Two");
            }

            stopWatch.Stop();

            output("Elasped Time: " + stopWatch.ElapsedTicks);

        }


        [TestMethod]
        public void ManyObjectAttempt_String()
        {
            var stopWatch = new Stopwatch();

            stopWatch.Start();


            for (var ii = _numberOfIteration; ii > 0; ii--)
            {
                var stringAddition = new StringAddition();

                var val = stringAddition.AddTwo("Part One", "Part Two");
            }

            stopWatch.Stop();

            output("Elasped Time: " + stopWatch.ElapsedTicks);

        }


          [TestMethod]
        public void ManyStructAttempt_String()
        {
            var stopWatch = new Stopwatch();

            stopWatch.Start();


            for (var ii = _numberOfIteration; ii > 0; ii--)
            {
                var stringAddition = new StructureStringAddition();

                var val = stringAddition.AddTwo("Part One", "Part Two");
            }

            stopWatch.Stop();

            output("Elasped Time: " + stopWatch.ElapsedTicks);

        }
        [TestMethod]
          public void ManyStructAttempt_Int()
          {
              var stopWatch = new Stopwatch();

              stopWatch.Start();


              for (var ii = _numberOfIteration; ii > 0; ii--)
              {
                  var stringAddition = new StructureStringAddition();

                  var val = stringAddition.AddTwo(1, 2);
              }

              stopWatch.Stop();

              output("Elasped Time: " + stopWatch.ElapsedTicks);

          }


        [TestMethod]
        public void StaticAttempt_int()
        {
            var stopWatch = new Stopwatch();

            stopWatch.Start();

            for (var ii = _numberOfIteration; ii > 0; ii--)
            {
                var val = StaticStringAddition.AddTwo(1, 2);
            }

            stopWatch.Stop();

            output("Elasped Time: " + stopWatch.ElapsedTicks);
        }


        [TestMethod]
        public void OneObjectAttempt_int()
        {
            var stopWatch = new Stopwatch();

            stopWatch.Start();

            var stringAddition = new StringAddition();

            for (var ii = _numberOfIteration; ii > 0; ii--)
            {
                var val = stringAddition.AddTwo(1, 2);
            }

            stopWatch.Stop();

            output("Elasped Time: " + stopWatch.ElapsedTicks);

        }


        [TestMethod]
        public void ManyObjectAttempt_int()
        {
            var stopWatch = new Stopwatch();

            stopWatch.Start();


            for (var ii = _numberOfIteration; ii > 0; ii--)
            {
                var stringAddition = new StringAddition();

                var val = stringAddition.AddTwo(1, 2);
            }

            stopWatch.Stop();

            output("Elasped Time: " + stopWatch.ElapsedTicks);

        }





    }
}
