







namespace glbl
{


  [Query("InsertUpdateLogEntry")]
  public partial class InsertUpdateLogEntry
  {

  	public InsertUpdateLogEntry (
		int Major,
int Minor,
int Patch,
string ProductName
	)
	{
		this.Major = Major;
this.Minor = Minor;
this.Patch = Patch;
this.ProductName = ProductName;
	}
	

		private readonly int _Major;
private readonly int _Minor;
private readonly int _Patch;
private readonly string _ProductName;

		[QueryParameter("@Major")] 
 public int Major{get {return _Major;}}
[QueryParameter("@Minor")] 
 public int Minor{get {return _Minor;}}
[QueryParameter("@Patch")] 
 public int Patch{get {return _Patch;}}
[QueryParameter("@ProductName")] 
 public string ProductName{get {return _ProductName;}}

  }

}


