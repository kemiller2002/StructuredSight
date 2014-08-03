using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SecureStringExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Passphrase: ");
            using (var passphrase = GetPassphraseFromConsole())
            {
                var arPass = new char[passphrase.Length];

                Console.WriteLine("Your password:");

                RuntimeHelpers.ExecuteCodeWithGuaranteedCleanup(
                    (uData) =>
                    {
                        unsafe
                        {
                            var handle = System.Runtime.InteropServices.GCHandle.Alloc(arPass, System.Runtime.InteropServices.GCHandleType.Pinned);

                            System.IntPtr ptr = System.IntPtr.Zero;

                            ptr = Marshal.SecureStringToBSTR(passphrase);

                            char* ptrPassword = (char*)ptr;

                            char* ptrArPass = (char*)handle.AddrOfPinnedObject();

                            for (var ii = 0; ii < arPass.Length; ii++)
                            {
                                ptrArPass[ii] = ptrPassword[ii];
                            }

                            Console.WriteLine(arPass);
                        }

                    },

                    (uData, ifExceptionThrown) =>
                    {
                        for (var ii = 0; ii < arPass.Length; ii++)
                        {
                            arPass[ii] = '\0';
                        }
                    },
                    null
                    );
            }

        }


        static SecureString GetPassphraseFromConsole()
        {
            var password = new SecureString();

            var key = Console.ReadKey(true);

            while (key.Key != ConsoleKey.Enter)
            {
                password.AppendChar(key.KeyChar);
                key = Console.ReadKey(true);
            }
            
            password.MakeReadOnly();

            return password;
        }



    }
}
