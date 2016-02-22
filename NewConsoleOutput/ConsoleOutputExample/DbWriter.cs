using System;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Xml.Linq;

namespace ConsoleOutputExample
{
    public class DbWriter : TextWriter
    {
        public override Encoding Encoding { get; }

        private void WriteEntry(object item)
        {
            using (var command = new SqlCommand())
            {
                command.Connection = _connection;
                command.CommandText = "INSERT INTO TextLog (Date,Message) VALUES (@Date, @Message)";
                command.Parameters.Add(new SqlParameter {ParameterName = "@Date", Value = DateTime.UtcNow});
                command.Parameters.Add(new SqlParameter { ParameterName = "@Message", Value = item });

                command.ExecuteNonQuery();
            }

        }

        private readonly SqlConnection _connection;

        public DbWriter(SqlConnection connection)
        {
            _connection = connection;

        }

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