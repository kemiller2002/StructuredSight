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
