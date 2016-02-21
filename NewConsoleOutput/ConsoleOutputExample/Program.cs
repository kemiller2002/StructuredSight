using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThirdPartAssembly;

namespace ConsoleOutputExample
{
    class DebugWriter : TextWriter
    {
        public override Encoding Encoding { get; }

        protected virtual void WriteItem(dynamic d)
        {
            System.Diagnostics.Debug.WriteLine((object)d);
        }

        public override void WriteLine()
        {
            base.WriteLine();
        }

        public override void WriteLine(bool value) => WriteItem(value);
        public override void Write(bool value) => WriteItem(value);

        public override void Write(char value) => WriteItem(value);
        public override void WriteLine(char value) => WriteItem(value);

        public override void Write(int value) => WriteItem(value);
        public override void WriteLine(int value) => WriteItem(value);

        public override void Write(string value) => WriteItem(value);
        public override void WriteLine(string value) => WriteItem(value);

        public override void Write(object value) => WriteItem(value);
        public override void WriteLine(object value) => WriteItem(value);

        public override void Write(char[] value) => WriteItem(value);
        public override void WriteLine(char[] value) => WriteItem(value);

        public override void Write(float value) => WriteItem(value);
        public override void WriteLine(float value) => WriteItem(value);

        public override void Write(decimal value) => WriteItem(value);
        public override void WriteLine(decimal value) => WriteItem(value);


        public override void Write(double value) => WriteItem(value);
        public override void WriteLine(double value) => WriteItem(value);


        public override void Write(long value) => WriteItem(value);
        public override void WriteLine(long value) => WriteItem(value);

        public override void Write(uint value) => WriteItem(value);
        public override void WriteLine(uint value) => WriteItem(value);
        
        public override void Write(ulong value) => WriteItem(value);
        public override void WriteLine(ulong value) => WriteItem(value);

        public override void Write(char[] buffer, int index, int count)
        {
            base.Write(buffer, index, count);
        }

        public override void Write(string format, object arg0)
        {
            base.Write(format, arg0);
        }

        public override void Write(string format, object arg0, object arg1)
        {
            base.Write(format, arg0, arg1);
        }

        public override void Write(string format, object arg0, object arg1, object arg2)
        {
            base.Write(format, arg0, arg1, arg2);
        }

        public override void Write(string format, params object[] arg)
        {
            base.Write(format, arg);
        }

        public override void WriteLine(char[] buffer, int index, int count)
        {
            base.WriteLine(buffer, index, count);
        }

        public override void WriteLine(string format, object arg0)
        {
            base.WriteLine(format, arg0);
        }

        public override void WriteLine(string format, object arg0, object arg1)
        {
            base.WriteLine(format, arg0, arg1);
        }

        public override void WriteLine(string format, object arg0, object arg1, object arg2)
        {
            base.WriteLine(format, arg0, arg1, arg2);
        }

        public override void WriteLine(string format, params object[] arg)
        {
            base.WriteLine(format, arg);
        }

        public override Task WriteAsync(char value)
        {
            return base.WriteAsync(value);
        }

        public override Task WriteAsync(string value)
        {
            return base.WriteAsync(value);
        }

        public override Task WriteAsync(char[] buffer, int index, int count)
        {
            return base.WriteAsync(buffer, index, count);
        }

        public override Task WriteLineAsync(string value)
        {
            return base.WriteLineAsync(value);
        }

        public override Task WriteLineAsync(char value)
        {
            return base.WriteLineAsync(value);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        public override Task WriteLineAsync(char[] buffer, int index, int count)
        {
            return base.WriteLineAsync(buffer, index, count);
        }

        public override Task WriteLineAsync()
        {
            return base.WriteLineAsync();
        }

    }

    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("I am a console message.");


            //new Program();

            Console.ReadLine();
        }

        Program()
        {
            ShowExampleFromMainProgram();

            UseThirdPartyAssembly();

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
