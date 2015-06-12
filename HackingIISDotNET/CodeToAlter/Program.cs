using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeToAlter
{
    class Program
    {
        public static int AddTwoNumbers(int a, int b)
        {
            return a + b;
        }


        public static int GetNumber()
        {
            return int.Parse(Console.ReadLine());
        }

        public static string GetMessage()
        {
            return "Add Two Numbers Together";
        }

        static void Main(string[] args)
        {
            Console.WriteLine(GetMessage());

            Console.Write("Number One: ");
            var fNumber = GetNumber();

            Console.Write("Number Two: ");
            var sNumber = GetNumber();
            

            Console.WriteLine(AddTwoNumbers(fNumber, sNumber));

            Console.ReadLine();
        }
    }
}
