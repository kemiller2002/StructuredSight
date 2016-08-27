using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleApp
{
    class NameAndPhone {
        public string Name;
        public string Phone; 
    }

    class Program
    {
        static void Main(string[] args)
        {
            var janePhone = ("Jane", "867-5309");

            var janePhoneToo = ("Jane", "867-5309");

            var equal = janePhone.Equals(janePhoneToo);

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
