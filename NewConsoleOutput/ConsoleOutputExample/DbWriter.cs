using System.IO;
using System.Text;

namespace ConsoleOutputExample
{
    public class DbWriter : TextWriter
    {
        public override Encoding Encoding { get; }
        

    }

}