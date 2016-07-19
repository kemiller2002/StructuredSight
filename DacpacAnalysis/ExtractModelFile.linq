<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.IO.Compression.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.IO.Compression.FileSystem.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.XML.dll</Reference>
</Query>

void Main()
{
	var archive = System.IO.Compression.
		ZipFile.Open(@"Z:\Users\kemiller2002\GitHub\StructuredSight\DacpacAnalysis\Database1\Database1\bin\Debug\Database1.dacpac", 
		System.IO.Compression.ZipArchiveMode.Read);
	
	
	using (var stream = archive.Entries.First(x => x.Name.Equals("model.xml")).Open())
	{
		var document = new XmlDocument();
		document.Load(stream);
		
		var manager = new XmlNamespaceManager(document.NameTable);
		manager.AddNamespace("d", document.DocumentElement.NamespaceURI);
		
		var nodes = document.SelectNodes(
		"d:DataSchemaModel/d:Model/d:Element[@Type='SqlTable' or @Type='SqlProcedure' or @Type='SqlView' or @Type='SqlScalarFunction']",
		manager);

		nodes.Cast<XmlNode>().Select(node=>ParseNode(node, manager)).ToList();
	}
}

public static Entity ParseNode(XmlNode elementNode, XmlNamespaceManager manager)
{	
	//Console.WriteLine(elementNode.SelectNodes("d:Relationship[@Name='Parameters']/d:Entry",manager));
	var type = elementNode.Attributes["Type"].Value;

	var fields = (type.Equals("SqlTable")) ?
			  elementNode.SelectNodes("d:Relationship[@Name='Columns']/d:Entry", manager)
				.Cast<XmlNode>().Select(node => GetColumn(node, manager))
				
			: elementNode.SelectNodes("d:Relationship[@Name='Parameters']/d:Entry", manager)
				.Cast<XmlNode>().Select(node => GetField(node, manager));
	
	var entity =  new Entity(
		elementNode.Attributes["Name"].Value
		,type
		,fields
	);
	
	Console.WriteLine(entity);
	
	return entity;
}

public static Field GetField(XmlNode node, XmlNamespaceManager manager)
{

	var name = node.SelectSingleNode("d:Element", manager).Attributes["Name"].Value;
	var type = node.SelectSingleNode
		("d:Element/d:Relationship/d:Entry/d:Element/d:Relationship/d:Entry/d:References", manager).Attributes["Name"].Value;

	var allowsNull = node.SelectSingleNode
		("d:Element/d:Property[@Name='DefaultExpressionScript']", manager) != null;

	return new Field(name, type, allowsNull);
}

public static Field GetColumn(XmlNode node, XmlNamespaceManager manager)
{
	Console.WriteLine(node.OuterXml);
	var column = node.SelectSingleNode
		("d:Element", manager);
		
	var name = column.Attributes["Name"].Value;
	var typeNode = node.SelectSingleNode("d:Relationship/d:Entry/d:Element/d:Relationship/d:Entry/d:References",manager);

	var type = typeNode.Attributes["Name"].Value;
	var allowsNull = node.SelectSingleNode
		("d:Element/d:Property[@Name='IsNullable']", manager).Attributes["Value"].Value == "True";

	return new Field(name, type, allowsNull);

}

public class Entity
{
	public Entity(string name, string type, IEnumerable<Field> fields)
	{
		Type = type;
		Name = name;
		Fields = fields;
	}
	
	public String Type { get; set;}
	public String Name { get; set; }
	public IEnumerable<Field> Fields { get; set;}

	public override String ToString()
	{
		return "${Name} ${Type}";
	}
}

public class Field
{
	public Field(string name, string type, bool allowsNull)
	{
		Name = name;
		Type = type;
		AllowsNull = allowsNull;
	}
	
	public String Name { get; private set; }
	public String Type { get; private set; }
	public Boolean AllowsNull { get; private set;}
}



// Define other methods and classes here