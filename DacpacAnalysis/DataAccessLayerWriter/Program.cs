using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Xml;

namespace DataAccessLayerWriter
{

    class Writer
    {
        static void Main(string[] args)
        {

            var writer = new Writer();
            writer.Write(
                @"Z:\Users\kemiller2002\GitHub\StructuredSight\DacpacAnalysis\Database1\Database1\bin\Debug\Database1.dacpac",
                "C:\\temp\\"
                );
        }

        public bool Write(string inputFile, string outputFolder)
        {
            var archive = ZipFile.Open(inputFile
                ,
                    System.IO.Compression.ZipArchiveMode.Read);

            using (var stream = archive.Entries.First(x => x.Name.Equals("model.xml")).Open())
            {
                var document = new XmlDocument();
                document.Load(stream);

                var manager = new XmlNamespaceManager(document.NameTable);
                manager.AddNamespace("d", document.DocumentElement.NamespaceURI);
                var nodes = document.SelectNodes("d:DataSchemaModel/d:Model/d:Element", manager);

                Console.WriteLine(nodes.Cast<XmlNode>().Where(n => n.Attributes["Type"].Value.Equals("SqlProcedure")).Count());

                var code = nodes.Cast<XmlNode>()
                     .Where(n => n.Attributes["Type"].Value.Equals("SqlProcedure"))
                     .Select(n => ParseProcedure(n, manager));

                Console.WriteLine(code);

                return code.Any();
                
            }

        }

        public Field CreateParameterEntry(XmlNode node, XmlNamespaceManager manager)
        {
            var fullName = node.SelectSingleNode("d:Element", manager).Attributes["Name"].Value;
            var name = fullName.Split('.').Last().RemoveSquareBrackets();

            var typeNode = node.SelectSingleNode("d:Element/d:Relationship/d:Entry/d:Element/d:Relationship/d:Entry/d:References", manager);

            var type = (typeNode.Attributes["ExternalSource"].Value.Equals("BuiltIns"))
                ? typeNode.Attributes["Name"].Value.RemoveSquareBrackets()
                : "";

            var allowsNull = node.SelectSingleNode("d:Element/d:Property[@Name='DefaultExpressionScript']", manager) != null;

            return new Field
            {
                Name = name,
                Type = LookupDataType(type),
                AllowsNull = allowsNull
            };
        }
        
        public Tuple<string,string> ParseProcedure(XmlNode node, XmlNamespaceManager manager)
        {
            var nameAttributeValue = node.Attributes["Name"].Value;
            var nameAttributeValueParts = nameAttributeValue.Split('.');

            var procedureNamespace = nameAttributeValueParts[0].RemoveSquareBrackets();
            var procedureName = nameAttributeValueParts[0].RemoveSquareBrackets();

            var parameters = node.SelectNodes("d:Relationship[@Name='Parameters']/d:Entry", manager)
                .Cast<XmlNode>().Select(n => CreateParameterEntry(n, manager));

            return new Tuple<string, string>($"{procedureNamespace}{procedureName}", 
                    ProcedureEntry.Create(procedureNamespace, procedureName, parameters));
        }

        public string LookupDataType(string input)
        {
           switch (input)  
            {
                case "bigint": return "Int64";

                case "binary": return "Byte[]";

                case "bit": return "Boolean";

                case "char": return "String";

                case "date": return "DateTime";

                case "Date": return "datetime";

                case "datetime2": return "DateTime";

                case "datetimeoffset": return "DateTimeOffset";

                case "decimal": return "Decimal";

                case "FILESTREAM": return "Byte[]";

                case "float": return "Double";

                case "image": return "Byte[]";

                case "int": return "Int32";

                case "money": return "Decimal";

                case "nchar": return "String";

                case "ntext": return "String";

                case "numeric": return "Decimal";

                case "nvarchar": return "String";

                case "real": return "Single";

                case "rowversion": return "Byte[]";

                case "smalldatetime": return "DateTime";

                case "smallint": return "Int16";

                case "smallmoney": return "Decimal";

                case "sql_variant": return "Object";

                case "text": return "String";

                case "time": return "TimeSpan";

                case "timestamp": return "Byte[]";

                case "tinyint": return "Byte";

                case "uniqueidentifier": return "Guid";

                case "varbinary": return "Byte[]";

                case "varchar": return "String";

                case "xml": return "Xml";
            }

            throw new Exception($"Type not found: {input}");
        }

    }
}
