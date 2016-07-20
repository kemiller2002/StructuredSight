using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;
using System.Security.Cryptography;
using System.Xml;

namespace DataAccessLayerWriter
{

    class Writer
    {
        static void Main(string[] args)
        {

            var writer = new Writer();
            writer.Write();
        }

        public bool Write()
        {
            var archive = ZipFile.Open(
                @"Z:\Users\kemiller2002\GitHub\StructuredSight\DacpacAnalysis\Database1\Database1\bin\Debug\Database1.dacpac",
                    System.IO.Compression.ZipArchiveMode.Read);

            using (var stream = archive.Entries.First(x => x.Name.Equals("model.xml")).Open())
            {
                var document = new XmlDocument();
                document.Load(stream);

                var manager = new XmlNamespaceManager(document.NameTable);
                manager.AddNamespace("d", document.DocumentElement.NamespaceURI);
                var nodes = document.SelectNodes("d:DataSchemaModel/d:Model/d:Element", manager);

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


            return new Field
            {
                Name = name,
                Type = type,
                AllowsNull = true
            };
        }
        
        public string ParseProcedure(XmlNode node, XmlNamespaceManager manager)
        {
            var nameAttributeValue = node.Attributes["Name"].Value;
            var nameAttributeValueParts = nameAttributeValue.Split('.');

            var procedureNamespace = nameAttributeValueParts[0].RemoveSquareBrackets();
            var procedureName = nameAttributeValueParts[0].RemoveSquareBrackets();

            var parameters = node.SelectNodes("d:Relationship[@Name='Parameters']/d:Entry", manager)
                .Cast<XmlNode>().Select(n => CreateParameterEntry(n, manager));

            return parameters.Count().ToString();
        }





    }
}
