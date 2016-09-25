using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutExamples
{



    class Program
    {
        class PersonInformation
        {
            public String Name;
            public String PhoneNumber;
        }

        static void Main(string[] args)
        {
            var jenny = new PersonInformation { Name = "jenny", PhoneNumber = "867-5309" };
            var steve = new PersonInformation { Name = "steve", PhoneNumber = "555-1212" };

            ref var jennyName = ref GetName(jenny);
            ref var steveName = ref GetName(steve);

            jennyName = steveName;


            MakeNameCapitalized(ref jennyName);


            Console.WriteLine(jenny.Name);
        }

        static ref string GetName(PersonInformation person) => ref person.Name;

        public static void MakeNameCapitalized(ref string name)
        {
            name = name[0].ToString().ToUpper() + String.Join("", name.Skip(1));
        }


        public static ref int ReturnRefOfNumber()
        {
            var someNumber = 123;
            return ref PassSomeNumber(ref someNumber);
        }

        public static ref int PassSomeNumber(ref int number) => ref number;

        public ref string GetStringLocation(ref string str) => ref str;

    }
}
