using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace StructuredSight.CallerExample
{

    class Program
    {

        static void Main(string[] args)
        {
            var prog = new Program();
            
            prog.DoApplicationThings();

        }

        void DoApplicationThings()
        {
            StructuredSight.CallerExample.Logging.Logger.Log("Running the Application");
            var mLogic = new MoreBusinessLogic();

            mLogic.DoApplicationThings();

            Console.ReadLine();
        }
        



    }
}
