CREATE TABLE Scheduler.IntervalType
(
	IntervalTypeId INT NOT NULL PRIMARY KEY
	,IntervalName VARCHAR(20) NOT NULL
)

GO

INSERT INTO Scheduler.IntervalType
(
	IntervalTypeId
	,IntervalName
)
VALUES
(
	1
	,'Duration'
)

GO

INSERT INTO Scheduler.IntervalType
(
	IntervalTypeId
	,IntervalName
)
VALUES
(
	2
	,'Specified Time'
)
