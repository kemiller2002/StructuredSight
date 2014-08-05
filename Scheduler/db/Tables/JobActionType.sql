DROP TABLE Scheduler.JobAction 

GO


CREATE TABLE Scheduler.JobAction 
(
	JobActionId INT NOT NULL PRIMARY KEY 
	,JobActionName VARCHAR(50) NOT NULL
)

GO

INSERT INTO Scheduler.JobAction 
(
	JobActionId
	,JobActionName
)
VALUES
(
	1
	,'Command Line Interface'
)

GO
