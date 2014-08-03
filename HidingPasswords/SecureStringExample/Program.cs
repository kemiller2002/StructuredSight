using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security;

namespace SecureStringExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Passphrase: ");

            using (var passphrase = GetPassphraseFromConsole())
            {






            }

        }


        static SecureString GetPassphraseFromConsole()
        {
            var password = new SecureString();

            var key = Console.ReadKey(true);

            while (key.Key != ConsoleKey.Enter)
            {
                password.AppendChar(key.KeyChar);
            }

            return password;
        }



    }
}
