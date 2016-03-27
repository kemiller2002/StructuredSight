CREATE VIEW [dbo].[EmployeeJoinedName]

	AS SELECT 
		Id, FirstName + ' ' + LastName AS EmployeeName
	 FROM dbo.Employees
