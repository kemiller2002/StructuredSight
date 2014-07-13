using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Reflection;

namespace StructuredSight.CallerExample
{

    class Program
    {

        static void Main(string[] args)
        {
            var prog = new Program();
            
            prog.DoApplicationThings();

            prog.ReflectionCall();

            Console.ReadLine();
        }


        void ReflectionCall()
        {
            var typeInfo = typeof(StructuredSight.CallerExample.Logging.Logger);

            var method = typeInfo.GetMethod("Log");

            /*
             * method.Invoke(null, new[] { "Reflection Method" });  
             * //Runtime Error!  Default parameters don't work with reflection.  They have to specified!
             */

            method.Invoke(null, new object [] { "Reflection Method", "My Method", "My File Path", 0 });  
        }


        void DoApplicationThings()
        {
            StructuredSight.CallerExample.Logging.Logger.Log("Running the Application");
            var mLogic = new MoreBusinessLogic();

            mLogic.DoApplicationThings();
        }



    }
}
