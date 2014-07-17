using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Reflection;
using System.Dynamic;

namespace StructuredSight.CallerExample
{

    class Program
    {

        static void Main(string[] args)
        {
            var prog = new Program();
            
            prog.DoApplicationThings();

            Console.WriteLine("Reflection Call");
            Console.WriteLine("");

            prog.ReflectionCall();

            Console.ReadLine();

        }


        void ReflectionCall()
        {
            var typeInfo = typeof(StructuredSight.CallerExample.Logging.Logger);

            var method = typeInfo.GetMethod("Log");
            
            method.Invoke(null, new[] { "Reflection Method", Type.Missing, Type.Missing, Type.Missing });  
        }


        void DoApplicationThings()
        {
            StructuredSight.CallerExample.Logging.Logger.Log("Running the Application");
            var mLogic = new MoreBusinessLogic();

            mLogic.DoApplicationThings();
        }



    }
}
