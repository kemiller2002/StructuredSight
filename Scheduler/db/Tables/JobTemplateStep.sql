DROP TABLE Scheduler.JobTemplateStep

GO

CREATE TABLE Scheduler.JobTemplateStep
(
	JobTemplateStepId INT NOT NULL  PRIMARY KEY 
	,JobTemplateId INT NOT NULL  REFERENCES Scheduler.JobTemplate (JobTemplateId)
	,JobTemplateAction VARCHAR(5000) NOT NULL
	,JobActionId INT NOT NULL REFERENCES Scheduler.JobAction(JobActionId)
)
