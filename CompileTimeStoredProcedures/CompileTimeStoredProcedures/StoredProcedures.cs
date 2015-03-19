
 
 
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
	
			public string ProductName{get {return _productName;}}
public int Major{get {return _major;}}
public int Minor{get {return _minor;}}
public int Patch{get {return _patch;}}


			public IEnumerable<StoredProcedureParameterTypeAndValue> SqlParameters {
				get {
					
					
					if(_productName != null)							{
								yield return new StoredProcedureParameterTypeAndValue {Value = _productName, ParameterName = "@ProductName"};

							}								yield return new StoredProcedureParameterTypeAndValue {Value = _major, ParameterName = "@Major"};
															yield return new StoredProcedureParameterTypeAndValue {Value = _minor, ParameterName = "@Minor"};
															yield return new StoredProcedureParameterTypeAndValue {Value = _patch, ParameterName = "@Patch"};
														
					
				}

			}
	
		}
	}

	namespace CompileTimeStoredProcedures.Result.dbo
	{ 
		public partial class InsertUpdateLogEntry_Result {

		public InsertUpdateLogEntry_Result (System.Data.IDataReader reader)
		{
					}



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
			
	
			


			public IEnumerable<StoredProcedureParameterTypeAndValue> SqlParameters {
				get {
					
					return new StoredProcedureParameterTypeAndValue[0];
												
					
				}

			}
	
		}
	}

	namespace CompileTimeStoredProcedures.Result.dbo
	{ 
		public partial class SelectLogEntry_Result {

		public SelectLogEntry_Result (System.Data.IDataReader reader)
		{
									DateApplied = (DateTime)reader[5 -1] ;
						//the object is the ordinal position of the column.
						//-1 because of 0 based array in C#.


											Major = (int)reader[2 -1] ;
						//the object is the ordinal position of the column.
						//-1 because of 0 based array in C#.


											Minor = (int)reader[3 -1] ;
						//the object is the ordinal position of the column.
						//-1 because of 0 based array in C#.


											Patch = (int)reader[4 -1] ;
						//the object is the ordinal position of the column.
						//-1 because of 0 based array in C#.


											ProductName = (string)reader[1 -1] ;
						//the object is the ordinal position of the column.
						//-1 because of 0 based array in C#.


							}



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
	
			public IEnumerable<CompileTimeStoredProceduresTableValuedParameter.dbo.CategoryTableType> Categories{get {return _categories;}}


			public IEnumerable<StoredProcedureParameterTypeAndValue> SqlParameters {
				get {
					
					
													yield return new StoredProcedureParameterTypeAndValue {Value = _categories, ParameterName = "@Categories"};
														
					
				}

			}
	
		}
	}

	namespace CompileTimeStoredProcedures.Result.dbo
	{ 
		public partial class UseTempTable_Result {

		public UseTempTable_Result (System.Data.IDataReader reader)
		{
									CategoryID = (int?)reader[1 -1] ;
						//the object is the ordinal position of the column.
						//-1 because of 0 based array in C#.


											CategoryName = (string)reader[2 -1] ;
						//the object is the ordinal position of the column.
						//-1 because of 0 based array in C#.


							}



		public int? CategoryID {get;set;}
				
				public string CategoryName {get;set;}
				
						}
	}

