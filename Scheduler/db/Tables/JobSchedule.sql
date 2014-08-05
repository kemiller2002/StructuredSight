DROP TABLE Scheduler.JobSchedule 

GO

CREATE TABLE Scheduler.JobSchedule 
(
	JobScheduleId INT NOT NULL PRIMARY KEY
	,JobTemplateId INT NOT NULL REFERENCES Scheduler.JobTemplate(JobTemplateId)
	,IntervalTypeId INT NOT NULL REFERENCES Scheduler.IntervalType(IntervalTypeId)
	,JobStartDateTime DATETIME NULL
	,JobRunTimeGMT TIME
	,JobRunIntervalInMinutes INT 
	,Sunday BIT NOT NULL DEFAULT(0)
	,Monday BIT NOT NULL DEFAULT(0)
	,Tuesday BIT NOT NULL DEFAULT(0)
	,Wednesday BIT NOT NULL DEFAULT(0)
	,Thursday BIT NOT NULL DEFAULT(0)
	,Friday BIT NOT NULL DEFAULT(0)
	,Saturday BIT NOT NULL DEFAULT(0)
)
