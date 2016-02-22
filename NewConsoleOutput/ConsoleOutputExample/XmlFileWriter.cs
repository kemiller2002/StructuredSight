using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Linq;
using System.Xml.Linq;

namespace ConsoleOutputExample
{
    public class XmlFileWriter : TextWriter
    {
        private readonly Stream _stream;
        private readonly XDocument _writer;
        private readonly XElement _header;

        private void WriteEntry(object item)
        {
            _header.Add(
                    new XElement("Entry", 
                        new XElement("Date", DateTime.UtcNow), 
                        new XElement("Message", new XCData(item.ToString()))
                                )
                        );


            _writer.Save(_stream);
        }

        public XmlFileWriter(Stream writerStream)
        {
            _writer = new XDocument();
            _header = new XElement("Entries");
            _writer.Add(_header);

            _stream = writerStream;
        }

        public override Encoding Encoding { get; }

        public override void Write(string value) => WriteEntry(value);
        public override void WriteLine(string value) => WriteEntry(value);

        public override void Write(string format, object arg0, object arg1)
        {
            var formatted = String.Format(format, arg0, arg1);
            WriteEntry(formatted);
        }

        public override void Write(string format, object arg0)
        {
            var formatted = string.Format(format, arg0);
            WriteEntry(formatted);
        }

        public override void Write(string format, object arg0, object arg1, object arg2)
        {
            var formatted = String.Format(format, arg0, arg1, arg2);
            WriteEntry(formatted);
        }

        public override void Write(string format, params object[] arg)
        {
            var formatted = String.Format(format, arg);
            WriteEntry(formatted);
        }

        public override void Write(char[] buffer, int index, int count)
        {
            var arrayPart = new char[count];
            Array.Copy(buffer, index, arrayPart, 0, count);

            WriteEntry(String.Join("", arrayPart));
        }

    }
}