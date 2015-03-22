
 
 
//C:\Program Files (x86)\Microsoft SQL Server\100\SDK\Assemblies\Microsoft.SqlServer.SmoEnum.dll






using System;
using System.Collections.Generic;
using System.Linq;

//Starting Table Valued Columns//Starting Procedures//Starting Header//Starting Table Valued Column Header//Starting Results Column Header//Starting Property 


/*Start Table Valued Columns*/ 
/*End Table Valued Columns*/
  



 
  namespace CompileTimeStoredProcedures.Query.dbo
  { 
   
	  public partial class uspGetBillOfMaterials : IDbQuery {
	 
	  	public uspGetBillOfMaterials ( 
			int startProductID,
DateTime checkDate
		)
		{
			_startProductID = startProductID;
_checkDate = checkDate;
		}  
		
			public String Query {get{return "uspGetBillOfMaterials";}}
			private readonly int _startProductID;
private readonly DateTime _checkDate;
	
			public int StartProductID{get {return _startProductID;}}
public DateTime CheckDate{get {return _checkDate;}}


			public IEnumerable<StoredProcedureParameterTypeAndValue> SqlParameters 
			{
				get 
				{
					 
					
													yield return new StoredProcedureParameterTypeAndValue {Value = _startProductID, ParameterName = "@StartProductID"};
															yield return new StoredProcedureParameterTypeAndValue {Value = _checkDate, ParameterName = "@CheckDate"};
														
					
				}

			}
	
		}
	}

	namespace CompileTimeStoredProcedures.Result.dbo
	{ 

		public partial class uspGetBillOfMaterials_Result {

		public uspGetBillOfMaterials_Result (System.Data.IDataReader reader)
		{
									BOMLevel = (Int16?)reader[7 -1] ;
						//the object is the ordinal position of the column.
						//-1 because of 0 based array in C#.


											ComponentDesc = (string)reader[3 -1] ;
						//the object is the ordinal position of the column.
						//-1 because of 0 based array in C#.


											ComponentID = (int?)reader[2 -1] ;
						//the object is the ordinal position of the column.
						//-1 because of 0 based array in C#.


											ListPrice = (Single?)reader[6 -1] ;
						//the object is the ordinal position of the column.
						//-1 because of 0 based array in C#.


											ProductAssemblyID = (int?)reader[1 -1] ;
						//the object is the ordinal position of the column.
						//-1 because of 0 based array in C#.


											RecursionLevel = (int?)reader[8 -1] ;
						//the object is the ordinal position of the column.
						//-1 because of 0 based array in C#.


											StandardCost = (Single?)reader[5 -1] ;
						//the object is the ordinal position of the column.
						//-1 because of 0 based array in C#.


											TotalQuantity = (Decimal?)reader[4 -1] ;
						//the object is the ordinal position of the column.
						//-1 because of 0 based array in C#.


							}



		public Int16? BOMLevel {get;set;}
				
				public string ComponentDesc {get;set;}
				
				public int? ComponentID {get;set;}
				
				public Single? ListPrice {get;set;}
				
				public int? ProductAssemblyID {get;set;}
				
				public int? RecursionLevel {get;set;}
				
				public Single? StandardCost {get;set;}
				
				public Decimal? TotalQuantity {get;set;}
				
						}
	}

 
  namespace CompileTimeStoredProcedures.Query.dbo
  { 
   
	  public partial class uspGetEmployeeManagers : IDbQuery {
	 
	  	public uspGetEmployeeManagers ( 
			int businessEntityID
		)
		{
			_businessEntityID = businessEntityID;
		}  
		
			public String Query {get{return "uspGetEmployeeManagers";}}
			private readonly int _businessEntityID;
	
			public int BusinessEntityID{get {return _businessEntityID;}}


			public IEnumerable<StoredProcedureParameterTypeAndValue> SqlParameters 
			{
				get 
				{
					 
					
													yield return new StoredProcedureParameterTypeAndValue {Value = _businessEntityID, ParameterName = "@BusinessEntityID"};
														
					
				}

			}
	
		}
	}

	namespace CompileTimeStoredProcedures.Result.dbo
	{ 

		public partial class uspGetEmployeeManagers_Result {

		public uspGetEmployeeManagers_Result (System.Data.IDataReader reader)
		{
									BusinessEntityID = (int?)reader[2 -1] ;
						//the object is the ordinal position of the column.
						//-1 because of 0 based array in C#.


											FirstName = (string)reader[3 -1] ;
						//the object is the ordinal position of the column.
						//-1 because of 0 based array in C#.


											LastName = (string)reader[4 -1] ;
						//the object is the ordinal position of the column.
						//-1 because of 0 based array in C#.


											ManagerFirstName = (string)reader[6 -1] ;
						//the object is the ordinal position of the column.
						//-1 because of 0 based array in C#.


											ManagerLastName = (string)reader[7 -1] ;
						//the object is the ordinal position of the column.
						//-1 because of 0 based array in C#.


											OrganizationNode = (string)reader[5 -1] ;
						//the object is the ordinal position of the column.
						//-1 because of 0 based array in C#.


											RecursionLevel = (int?)reader[1 -1] ;
						//the object is the ordinal position of the column.
						//-1 because of 0 based array in C#.


							}



		public int? BusinessEntityID {get;set;}
				
				public string FirstName {get;set;}
				
				public string LastName {get;set;}
				
				public string ManagerFirstName {get;set;}
				
				public string ManagerLastName {get;set;}
				
				public string OrganizationNode {get;set;}
				
				public int? RecursionLevel {get;set;}
				
						}
	}

 
  namespace CompileTimeStoredProcedures.Query.dbo
  { 
   
	  public partial class uspGetManagerEmployees : IDbQuery {
	 
	  	public uspGetManagerEmployees ( 
			int businessEntityID
		)
		{
			_businessEntityID = businessEntityID;
		}  
		
			public String Query {get{return "uspGetManagerEmployees";}}
			private readonly int _businessEntityID;
	
			public int BusinessEntityID{get {return _businessEntityID;}}


			public IEnumerable<StoredProcedureParameterTypeAndValue> SqlParameters 
			{
				get 
				{
					 
					
													yield return new StoredProcedureParameterTypeAndValue {Value = _businessEntityID, ParameterName = "@BusinessEntityID"};
														
					
				}

			}
	
		}
	}

	namespace CompileTimeStoredProcedures.Result.dbo
	{ 

		public partial class uspGetManagerEmployees_Result {

		public uspGetManagerEmployees_Result (System.Data.IDataReader reader)
		{
									BusinessEntityID = (int?)reader[5 -1] ;
						//the object is the ordinal position of the column.
						//-1 because of 0 based array in C#.


											FirstName = (string)reader[6 -1] ;
						//the object is the ordinal position of the column.
						//-1 because of 0 based array in C#.


											LastName = (string)reader[7 -1] ;
						//the object is the ordinal position of the column.
						//-1 because of 0 based array in C#.


											ManagerFirstName = (string)reader[3 -1] ;
						//the object is the ordinal position of the column.
						//-1 because of 0 based array in C#.


											ManagerLastName = (string)reader[4 -1] ;
						//the object is the ordinal position of the column.
						//-1 because of 0 based array in C#.


											OrganizationNode = (string)reader[2 -1] ;
						//the object is the ordinal position of the column.
						//-1 because of 0 based array in C#.


											RecursionLevel = (int?)reader[1 -1] ;
						//the object is the ordinal position of the column.
						//-1 because of 0 based array in C#.


							}



		public int? BusinessEntityID {get;set;}
				
				public string FirstName {get;set;}
				
				public string LastName {get;set;}
				
				public string ManagerFirstName {get;set;}
				
				public string ManagerLastName {get;set;}
				
				public string OrganizationNode {get;set;}
				
				public int? RecursionLevel {get;set;}
				
						}
	}

 
  namespace CompileTimeStoredProcedures.Query.dbo
  { 
   
	  public partial class uspGetWhereUsedProductID : IDbQuery {
	 
	  	public uspGetWhereUsedProductID ( 
			int startProductID,
DateTime checkDate
		)
		{
			_startProductID = startProductID;
_checkDate = checkDate;
		}  
		
			public String Query {get{return "uspGetWhereUsedProductID";}}
			private readonly int _startProductID;
private readonly DateTime _checkDate;
	
			public int StartProductID{get {return _startProductID;}}
public DateTime CheckDate{get {return _checkDate;}}


			public IEnumerable<StoredProcedureParameterTypeAndValue> SqlParameters 
			{
				get 
				{
					 
					
													yield return new StoredProcedureParameterTypeAndValue {Value = _startProductID, ParameterName = "@StartProductID"};
															yield return new StoredProcedureParameterTypeAndValue {Value = _checkDate, ParameterName = "@CheckDate"};
														
					
				}

			}
	
		}
	}

	namespace CompileTimeStoredProcedures.Result.dbo
	{ 

		public partial class uspGetWhereUsedProductID_Result {

		public uspGetWhereUsedProductID_Result (System.Data.IDataReader reader)
		{
									BOMLevel = (Int16?)reader[7 -1] ;
						//the object is the ordinal position of the column.
						//-1 because of 0 based array in C#.


											ComponentDesc = (string)reader[3 -1] ;
						//the object is the ordinal position of the column.
						//-1 because of 0 based array in C#.


											ComponentID = (int?)reader[2 -1] ;
						//the object is the ordinal position of the column.
						//-1 because of 0 based array in C#.


											ListPrice = (Single?)reader[6 -1] ;
						//the object is the ordinal position of the column.
						//-1 because of 0 based array in C#.


											ProductAssemblyID = (int?)reader[1 -1] ;
						//the object is the ordinal position of the column.
						//-1 because of 0 based array in C#.


											RecursionLevel = (int?)reader[8 -1] ;
						//the object is the ordinal position of the column.
						//-1 because of 0 based array in C#.


											StandardCost = (Single?)reader[5 -1] ;
						//the object is the ordinal position of the column.
						//-1 because of 0 based array in C#.


											TotalQuantity = (Decimal?)reader[4 -1] ;
						//the object is the ordinal position of the column.
						//-1 because of 0 based array in C#.


							}



		public Int16? BOMLevel {get;set;}
				
				public string ComponentDesc {get;set;}
				
				public int? ComponentID {get;set;}
				
				public Single? ListPrice {get;set;}
				
				public int? ProductAssemblyID {get;set;}
				
				public int? RecursionLevel {get;set;}
				
				public Single? StandardCost {get;set;}
				
				public Decimal? TotalQuantity {get;set;}
				
						}
	}

 
  namespace CompileTimeStoredProcedures.Query.HumanResources
  { 
   
	  public partial class uspUpdateEmployeeHireInfo : IDbQuery {
	 
	  	public uspUpdateEmployeeHireInfo ( 
			int businessEntityID,
string jobTitle,
DateTime hireDate,
DateTime rateChangeDate,
Single rate,
byte payFrequency,
Boolean currentFlag
		)
		{
			_businessEntityID = businessEntityID;
_jobTitle = jobTitle;
_hireDate = hireDate;
_rateChangeDate = rateChangeDate;
_rate = rate;
_payFrequency = payFrequency;
_currentFlag = currentFlag;
		}  
		
			public String Query {get{return "uspUpdateEmployeeHireInfo";}}
			private readonly int _businessEntityID;
private readonly string _jobTitle;
private readonly DateTime _hireDate;
private readonly DateTime _rateChangeDate;
private readonly Single _rate;
private readonly byte _payFrequency;
private readonly Boolean _currentFlag;
	
			public int BusinessEntityID{get {return _businessEntityID;}}
public string JobTitle{get {return _jobTitle;}}
public DateTime HireDate{get {return _hireDate;}}
public DateTime RateChangeDate{get {return _rateChangeDate;}}
public Single Rate{get {return _rate;}}
public byte PayFrequency{get {return _payFrequency;}}
public Boolean CurrentFlag{get {return _currentFlag;}}


			public IEnumerable<StoredProcedureParameterTypeAndValue> SqlParameters 
			{
				get 
				{
					 
					
													yield return new StoredProcedureParameterTypeAndValue {Value = _businessEntityID, ParameterName = "@BusinessEntityID"};
															yield return new StoredProcedureParameterTypeAndValue {Value = _jobTitle, ParameterName = "@JobTitle"};
															yield return new StoredProcedureParameterTypeAndValue {Value = _hireDate, ParameterName = "@HireDate"};
															yield return new StoredProcedureParameterTypeAndValue {Value = _rateChangeDate, ParameterName = "@RateChangeDate"};
															yield return new StoredProcedureParameterTypeAndValue {Value = _rate, ParameterName = "@Rate"};
															yield return new StoredProcedureParameterTypeAndValue {Value = _payFrequency, ParameterName = "@PayFrequency"};
															yield return new StoredProcedureParameterTypeAndValue {Value = _currentFlag, ParameterName = "@CurrentFlag"};
														
					
				}

			}
	
		}
	}

	namespace CompileTimeStoredProcedures.Result.HumanResources
	{ 

		public partial class uspUpdateEmployeeHireInfo_Result {

		public uspUpdateEmployeeHireInfo_Result (System.Data.IDataReader reader)
		{
					}



				}
	}

 
  namespace CompileTimeStoredProcedures.Query.HumanResources
  { 
   
	  public partial class uspUpdateEmployeeLogin : IDbQuery {
	 
	  	public uspUpdateEmployeeLogin ( 
			int businessEntityID,
string organizationNode,
string loginID,
string jobTitle,
DateTime hireDate,
Boolean currentFlag
		)
		{
			_businessEntityID = businessEntityID;
_organizationNode = organizationNode;
_loginID = loginID;
_jobTitle = jobTitle;
_hireDate = hireDate;
_currentFlag = currentFlag;
		}  
		
			public String Query {get{return "uspUpdateEmployeeLogin";}}
			private readonly int _businessEntityID;
private readonly string _organizationNode;
private readonly string _loginID;
private readonly string _jobTitle;
private readonly DateTime _hireDate;
private readonly Boolean _currentFlag;
	
			public int BusinessEntityID{get {return _businessEntityID;}}
public string OrganizationNode{get {return _organizationNode;}}
public string LoginID{get {return _loginID;}}
public string JobTitle{get {return _jobTitle;}}
public DateTime HireDate{get {return _hireDate;}}
public Boolean CurrentFlag{get {return _currentFlag;}}


			public IEnumerable<StoredProcedureParameterTypeAndValue> SqlParameters 
			{
				get 
				{
					 
					
													yield return new StoredProcedureParameterTypeAndValue {Value = _businessEntityID, ParameterName = "@BusinessEntityID"};
															yield return new StoredProcedureParameterTypeAndValue {Value = _organizationNode, ParameterName = "@OrganizationNode"};
															yield return new StoredProcedureParameterTypeAndValue {Value = _loginID, ParameterName = "@LoginID"};
															yield return new StoredProcedureParameterTypeAndValue {Value = _jobTitle, ParameterName = "@JobTitle"};
															yield return new StoredProcedureParameterTypeAndValue {Value = _hireDate, ParameterName = "@HireDate"};
															yield return new StoredProcedureParameterTypeAndValue {Value = _currentFlag, ParameterName = "@CurrentFlag"};
														
					
				}

			}
	
		}
	}

	namespace CompileTimeStoredProcedures.Result.HumanResources
	{ 

		public partial class uspUpdateEmployeeLogin_Result {

		public uspUpdateEmployeeLogin_Result (System.Data.IDataReader reader)
		{
					}



				}
	}

 
  namespace CompileTimeStoredProcedures.Query.dbo
  { 
   
	  public partial class uspPrintError : IDbQuery {
	 
	  	public uspPrintError ( 
			
		)
		{
			
		}  
		
			public String Query {get{return "uspPrintError";}}
			
	
			


			public IEnumerable<StoredProcedureParameterTypeAndValue> SqlParameters 
			{
				get 
				{
					 
					return new StoredProcedureParameterTypeAndValue[0];
												
					
				}

			}
	
		}
	}

	namespace CompileTimeStoredProcedures.Result.dbo
	{ 

		public partial class uspPrintError_Result {

		public uspPrintError_Result (System.Data.IDataReader reader)
		{
					}



				}
	}

 
  namespace CompileTimeStoredProcedures.Query.HumanResources
  { 
   
	  public partial class uspUpdateEmployeePersonalInfo : IDbQuery {
	 
	  	public uspUpdateEmployeePersonalInfo ( 
			int businessEntityID,
string nationalIDNumber,
DateTime birthDate,
string maritalStatus,
string gender
		)
		{
			_businessEntityID = businessEntityID;
_nationalIDNumber = nationalIDNumber;
_birthDate = birthDate;
_maritalStatus = maritalStatus;
_gender = gender;
		}  
		
			public String Query {get{return "uspUpdateEmployeePersonalInfo";}}
			private readonly int _businessEntityID;
private readonly string _nationalIDNumber;
private readonly DateTime _birthDate;
private readonly string _maritalStatus;
private readonly string _gender;
	
			public int BusinessEntityID{get {return _businessEntityID;}}
public string NationalIDNumber{get {return _nationalIDNumber;}}
public DateTime BirthDate{get {return _birthDate;}}
public string MaritalStatus{get {return _maritalStatus;}}
public string Gender{get {return _gender;}}


			public IEnumerable<StoredProcedureParameterTypeAndValue> SqlParameters 
			{
				get 
				{
					 
					
													yield return new StoredProcedureParameterTypeAndValue {Value = _businessEntityID, ParameterName = "@BusinessEntityID"};
															yield return new StoredProcedureParameterTypeAndValue {Value = _nationalIDNumber, ParameterName = "@NationalIDNumber"};
															yield return new StoredProcedureParameterTypeAndValue {Value = _birthDate, ParameterName = "@BirthDate"};
															yield return new StoredProcedureParameterTypeAndValue {Value = _maritalStatus, ParameterName = "@MaritalStatus"};
															yield return new StoredProcedureParameterTypeAndValue {Value = _gender, ParameterName = "@Gender"};
														
					
				}

			}
	
		}
	}

	namespace CompileTimeStoredProcedures.Result.HumanResources
	{ 

		public partial class uspUpdateEmployeePersonalInfo_Result {

		public uspUpdateEmployeePersonalInfo_Result (System.Data.IDataReader reader)
		{
					}



				}
	}

 
  namespace CompileTimeStoredProcedures.Query.dbo
  { 
   
	  public partial class uspLogError : IDbQuery {
	 
	  	public uspLogError ( 
			int? errorLogID
		)
		{
			_errorLogID = errorLogID;
		}  
		
			public String Query {get{return "uspLogError";}}
			private readonly int? _errorLogID;
	
			public int? ErrorLogID{get {return _errorLogID;}}


			public IEnumerable<StoredProcedureParameterTypeAndValue> SqlParameters 
			{
				get 
				{
					 
					
					if(!_errorLogID.HasValue)							{
								yield return new StoredProcedureParameterTypeAndValue {Value = _errorLogID, ParameterName = "@ErrorLogID"};

							}							
					
				}

			}
	
		}
	}

	namespace CompileTimeStoredProcedures.Result.dbo
	{ 

		public partial class uspLogError_Result {

		public uspLogError_Result (System.Data.IDataReader reader)
		{
					}



				}
	}

 
  namespace CompileTimeStoredProcedures.Query.dbo
  { 
   
	  public partial class uspSearchCandidateResumes : IDbQuery {
	 
	  	public uspSearchCandidateResumes ( 
			string searchString,
Boolean? useInflectional,
Boolean? useThesaurus,
int? language
		)
		{
			_searchString = searchString;
_useInflectional = useInflectional;
_useThesaurus = useThesaurus;
_language = language;
		}  
		
			public String Query {get{return "uspSearchCandidateResumes";}}
			private readonly string _searchString;
private readonly Boolean? _useInflectional;
private readonly Boolean? _useThesaurus;
private readonly int? _language;
	
			public string searchString{get {return _searchString;}}
public Boolean? useInflectional{get {return _useInflectional;}}
public Boolean? useThesaurus{get {return _useThesaurus;}}
public int? language{get {return _language;}}


			public IEnumerable<StoredProcedureParameterTypeAndValue> SqlParameters 
			{
				get 
				{
					 
					
													yield return new StoredProcedureParameterTypeAndValue {Value = _searchString, ParameterName = "@searchString"};
							if(!_useInflectional.HasValue)							{
								yield return new StoredProcedureParameterTypeAndValue {Value = _useInflectional, ParameterName = "@useInflectional"};

							}if(!_useThesaurus.HasValue)							{
								yield return new StoredProcedureParameterTypeAndValue {Value = _useThesaurus, ParameterName = "@useThesaurus"};

							}if(!_language.HasValue)							{
								yield return new StoredProcedureParameterTypeAndValue {Value = _language, ParameterName = "@language"};

							}							
					
				}

			}
	
		}
	}

	namespace CompileTimeStoredProcedures.Result.dbo
	{ 

		public partial class uspSearchCandidateResumes_Result {

		public uspSearchCandidateResumes_Result (System.Data.IDataReader reader)
		{
									JobCandidateID = (int)reader[1 -1] ;
						//the object is the ordinal position of the column.
						//-1 because of 0 based array in C#.


											RANK = (int?)reader[2 -1] ;
						//the object is the ordinal position of the column.
						//-1 because of 0 based array in C#.


							}



		public int JobCandidateID {get;set;}
				
				public int? RANK {get;set;}
				
						}
	}

