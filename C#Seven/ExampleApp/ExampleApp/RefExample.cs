using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleApp
{

    public class PersonInformation
    {
        public String Name;
        public String PhoneNumber;
    }

    public class RefExample
    { 

        public ref string GetPhoneNumberLocation (PersonInformation person)
        {
            return ref person.PhoneNumber;
        }

    }
}
