CREATE PROCEDURE [dbo].[SelectEmployeeByPhoneNumber]
	@phoneNumber PhoneNumber
AS
	SELECT * FROM Employees where PhoneNumber = PhoneNumber
	