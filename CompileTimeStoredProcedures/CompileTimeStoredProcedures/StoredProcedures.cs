







namespace glbl
{

    public partial class CategoryTableType
    {
        public int? CategoryID { get; set; }
        public string CategoryName { get; set; }
    }

		




  [Query("dbo.InsertUpdateLogEntry")]
  public partial class InsertUpdateLogEntry
{

  	public InsertUpdateLogEntry (
		int major,
int minor,
int patch,
string productName
	)
	{
		Major = major;
Minor = minor;
Patch = patch;
ProductName = productName;
	}
	

		private readonly int _major;
private readonly int _minor;
private readonly int _patch;
private readonly string _productName;

		[QueryColumn("@Major")] 
 public int Major{get {return _major;}}
[QueryColumn("@Minor")] 
 public int Minor{get {return _minor;}}
[QueryColumn("@Patch")] 
 public int Patch{get {return _patch;}}
[QueryColumn("@ProductName")] 
 public string ProductName{get {return _productName;}}

	}


}


