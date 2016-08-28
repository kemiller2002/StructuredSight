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




    }
}