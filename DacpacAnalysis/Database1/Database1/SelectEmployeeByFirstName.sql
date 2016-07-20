CREATE PROCEDURE [dbo].[SelectEmployeeByFirstName]
	@FirstName int
AS
	SELECT * FROM Employees where FirstName = @firstName
