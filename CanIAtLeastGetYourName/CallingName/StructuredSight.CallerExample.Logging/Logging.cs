using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace StructuredSight.CallerExample.Logging
{
    public class Logger
    {
        public static void Log(string message,
        [CallerMemberNameAttribute]string methodName = "No Name Given",
        [CallerFilePathAttribute]string filePath = "No File Path Given",
        [CallerLineNumberAttribute]int lineNumber = -1)
        {
            Console.WriteLine("Message: " + message);
            Console.WriteLine("\tFile Path: " + filePath);
            Console.WriteLine("\tLine Number: " + lineNumber);
            Console.WriteLine("\tMethod Name: " + methodName);
            Console.WriteLine("");

        }
    }
}
