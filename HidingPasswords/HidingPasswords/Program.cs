using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace HidingPasswords
{
    class Program
    {


        string _storedPassphraseInCode = "This is my password hardcoded into the assembly.";

        string _passphrase;

        private Program()
        {
            _passphrase = ConfigurationManager.AppSettings["passphrase"]; 
        }


        static void Main(string[] args)
        {

            var p = new Program();
            p.CheckPassword();
        }


        public void CheckPassword()
        {
            Console.WriteLine("Enter Passphrase:");
            var phrase = Console.ReadLine();

            if (phrase == _passphrase.ToUpper())
            {
                Console.WriteLine("Authenticated.");
            }
            else
            {
                Console.WriteLine("Passphrase is incorrect.");
            }

            Console.ReadLine();


        }


    }
}
