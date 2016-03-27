CREATE PROCEDURE [dbo].[SelectEmployees]
	@Id INT = NULL
AS
	SELECT * FROM dbo.Employees
		WHERE @id = Id OR @Id IS NULL

