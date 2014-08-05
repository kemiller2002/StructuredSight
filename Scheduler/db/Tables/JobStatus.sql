CREATE TABLE Scheduler.JobStatus
(
	JobStatusId INT NOT NULL PRIMARY KEY
	,JobStatusName VARCHAR(20) NOT NULL
)

GO 

INSERT INTO Scheduler.JobStatus
(
	JobStatusId
	,JobStatusName
)
VALUES
(
	1,
	'Not Run'	
)

GO 


INSERT INTO Scheduler.JobStatus
(
	JobStatusId
	,JobStatusName
)
VALUES
(
	2,
	'In Progress'	
)

GO 


INSERT INTO Scheduler.JobStatus
(
	JobStatusId
	,JobStatusName
)
VALUES
(
	3,
	'Success'	
)

GO 


INSERT INTO Scheduler.JobStatus
(
	JobStatusId
	,JobStatusName
)
VALUES
(
	4,
	'Failure'	
)

GO 


INSERT INTO Scheduler.JobStatus
(
	JobStatusId
	,JobStatusName
)
VALUES
(
	5,
	'Aborted'	
)

