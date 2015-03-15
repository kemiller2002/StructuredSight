








/*Start Table Valued Columns*/ 

		namespace CompileTimeStoredProcedures.TableValuedParameter.dbo
		{ 
			public partial class CategoryTableType {
				public int? CategoryID{get;set;}
public string CategoryName{get;set;}
			}

		}

		/*End Table Valued Columns*/
 



  namespace CompileTimeStoredProcedures.Query.dbo
  { 

	  public partial class InsertUpdateLogEntry : IDbQuery {
	
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
		
			public String Query {get{return "InsertUpdateLogEntry";}}
			private readonly int _major;
private readonly int _minor;
private readonly int _patch;
private readonly string _productName;
	
			[Parameter("@Major")] 
 public int Major{get {return _major;}}
[Parameter("@Minor")] 
 public int Minor{get {return _minor;}}
[Parameter("@Patch")] 
 public int Patch{get {return _patch;}}
[Parameter("@ProductName")] 
 public string ProductName{get {return _productName;}}
	
		}
	}

	namespace CompileTimeStoredProcedures.Result.dbo
	{ 
		public partial class InsertUpdateLogEntry_Result {
		public   {get;set;}		}
	}

  namespace CompileTimeStoredProcedures.Query.dbo
  { 

	  public partial class SelectLogEntry : IDbQuery {
	
	  	public SelectLogEntry (
			
		)
		{
			
		}
		
			public String Query {get{return "SelectLogEntry";}}
			
	
			
	
		}
	}

	namespace CompileTimeStoredProcedures.Result.dbo
	{ 
		public partial class SelectLogEntry_Result 
        {
		public   {get;set;}		
        }
}

