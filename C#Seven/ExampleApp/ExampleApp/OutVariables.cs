using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleApp
{
    class OutVariables
    {

        public static string GetPhoneNumber (string name)
        {

            Dictionary<string, string> phoneBook = new Dictionary<string, string>();
            phoneBook.Add("jenny", "867-5309");

            if(phoneBook.TryGetValue(name, out var phoneNumber))
            {
                return phoneNumber;
            }

            throw new Exception("phone number not found for: {name}");
        }

        public static void GetPersonInfoByPhoneNumber (string phoneNumber, out Person person)
        {
            person = new Person { Name = "jenny", PhoneNumber = "8675309", Address = "NY" };
        }

        public static void GetPersonInfoByPhoneNumber(string phoneNumber, out string name)
        {
            name = "jenny";
        }

        public static void GetFirstNameByPhoneNumber()
        {
            //GetPersonInfoByPhoneNumber("8675309", out var name);
        }


        public bool GetFirstNameAndLast(out string firstName, out string lastName)
        {
            firstName = "Jenny";
            lastName = "?";

            return true;
        }

        public void PrintFirstName()
        {
            if (GetFirstNameAndLast(out string firstName, out string lastName))
            {
                Console.WriteLine(firstName);
            }
        }

    }

    class Person
    {
        public String Name;
        public String PhoneNumber;
        public string Address; 
    }
}












