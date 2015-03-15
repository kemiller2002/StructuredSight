
 
 
//C:\Program Files (x86)\Microsoft SQL Server\100\SDK\Assemblies\Microsoft.SqlServer.SmoEnum.dll






using System;
using System.Collections.Generic;
using System.Linq;

 


/*Start Table Valued Columns*/ 

		namespace CompileTimeStoredProceduresTableValuedParameter.dbo
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
			string productName,
int major,
int minor,
int patch
		)
		{
			_productName = productName;
_major = major;
_minor = minor;
_patch = patch;
		}  
		
			public String Query {get{return "InsertUpdateLogEntry";}}
			private readonly string _productName;
private readonly int _major;
private readonly int _minor;
private readonly int _patch;
	
			[Parameter("@ProductName")] 
 public string ProductName{get {return _productName;}}
[Parameter("@Major")] 
 public int Major{get {return _major;}}
[Parameter("@Minor")] 
 public int Minor{get {return _minor;}}
[Parameter("@Patch")] 
 public int Patch{get {return _patch;}}
	
		}
	}

	namespace CompileTimeStoredProcedures.Result.dbo
	{ 
		public partial class InsertUpdateLogEntry_Result {

				}
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
		public partial class SelectLogEntry_Result {

		public DateTime DateApplied {get;set;}
				
				public int Major {get;set;}
				
				public int Minor {get;set;}
				
				public int Patch {get;set;}
				
				public string ProductName {get;set;}
				
						}
	}

 
  namespace CompileTimeStoredProcedures.Query.dbo
  { 
   
	  public partial class UseTempTable : IDbQuery {
	 
	  	public UseTempTable ( 
			IEnumerable<CompileTimeStoredProceduresTableValuedParameter.dbo.CategoryTableType> categories
		)
		{
			_categories = categories;
		}  
		
			public String Query {get{return "UseTempTable";}}
			private readonly IEnumerable<CompileTimeStoredProceduresTableValuedParameter.dbo.CategoryTableType> _categories;
	
			[Parameter("@Categories")] 
 public IEnumerable<CompileTimeStoredProceduresTableValuedParameter.dbo.CategoryTableType> Categories{get {return _categories;}}
	
		}
	}

	namespace CompileTimeStoredProcedures.Result.dbo
	{ 
		public partial class UseTempTable_Result {

		public int? CategoryID {get;set;}
				
				public string CategoryName {get;set;}
				
						}
	}

