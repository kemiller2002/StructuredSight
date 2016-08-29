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
            var person = new PersonInformation { Name = "jenny", PhoneNumber = "867-5309" };

            ref var name = ref GetName(person);

            MakeNameCapitalized(ref name);

            Console.WriteLine(person.Name);
        }

        static ref string GetName (PersonInformation person)
        {
            return ref person.Name;
        }

        public static void MakeNameCapitalized (ref string name)
        {
            name = name[0].ToString().ToUpper() + String.Join("", name.Skip(1));
        }


    }
}
