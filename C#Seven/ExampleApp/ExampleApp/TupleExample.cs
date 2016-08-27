using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleApp
{
    class TupleExample
    {

        public void PrintNameCount()
        {
            var nameAndWord = GetWordCount("test,test,test,test,test");

            Console.WriteLine(nameAndWord.Item1);

        }

        public (int count, string name) GetWordCount(string message)
        {
            var messageArray = message.Split(',');

            return (count:messageArray.Length, name:messageArray[0]);
        }

        public Tuple<string,string,string> GetNameAddressPhone ()
        {
            return new Tuple<string, string, string>("867-5309", "Jenny", "Ny Ny");
        }


        public (string Phone, string Name, string Address) GetNameAdressAndPhoneByNewTuple() => ("867-5309", "Jenny", "NY Ny");
        public string GetName()
        {
            var tuple = GetNameAdressAndPhoneByNewTuple();

            return tuple.Name;
        } 

        public (string, string) GetNameAndPhoneNumber ()
        {
            (var phone, var name, var address) = GetNameAdressAndPhoneByNewTuple();

            return (name, phone);
        }


        /*public bool CheckIfItsJenny((string name, string number) nameAndNumber)
        {
            var isJennyResponse = OtherLanguageAssembly.IntegrationAssembly.CheckNameAndPhone(nameAndNumber);
            return isJennyResponse.Item1;
        }*/


        /*public Tuple<string,string> ChangeTupleName(Tuple<string,string> nameAndPhone)
        {
            nameAndPhone.Item1 = "Jane"; //Can't set value.
            return nameAndPhone;
        }*/

        public static (string, string) ChangeTupleName((string,string) nameAndPhone)
        {
            nameAndPhone.Item1 = "Jenny";
            return nameAndPhone;
        }
    }



}
