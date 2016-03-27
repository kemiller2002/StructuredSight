CREATE TABLE [dbo].Employees
(
	[Id] INT NOT NULL PRIMARY KEY
	,FirstName VARCHAR(100) NOT NULL
	,LastName VARCHAR(100) NOT NULL
	,PhoneNumber VARCHAR(10) NULL
	,SocialSecurityNumber SSN NOT NULL
)
