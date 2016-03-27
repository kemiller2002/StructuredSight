CREATE FUNCTION [dbo].[EmployeeNameLength]
(
	@FirstName VARCHAR(100),
	@LastName VARCHAR(100)
)
RETURNS INT
AS
BEGIN
	RETURN LEN(FirstName + ' ' + LastName)
END
