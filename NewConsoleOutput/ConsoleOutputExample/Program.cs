using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThirdPartAssembly;

namespace ConsoleOutputExample
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("I am a console message.");
            var primaryOut = Console.Out;

            //using (var stream = new FileStream ("C:\\temp\\log.xml", FileMode.OpenOrCreate))
            using(var connection = new SqlConnection())
            {
                connection.ConnectionString =
                    "Data Source=localhost;Initial Catalog=SystemMonitoring;Integrated Security=SSPI";
                connection.Open();

                var writer = new DbWriter(connection);
                Console.SetOut(writer);

                var p = new Program();

                p.UseThirdPartyAssembly();


                Console.Write("this is an arra".ToCharArray(), 3, 5);


                Console.Write("this is a message.");
            }
                        
        }

//new Program();

                //Console.ReadLine();
        Program()
        {
            ShowExampleFromMainProgram();

        }

        void ShowExampleFromMainProgram()
        {
            Console.WriteLine("This is an output from the main program.");
        }

        void UseThirdPartyAssembly()
        {
            var result = AddNumbers.Add(2, 2);
            Console.WriteLine($"the result of the addition is: {result}");
        }


    }
}
