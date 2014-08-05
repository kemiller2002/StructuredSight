DROP TABLE Scheduler.JobTemplateStep

GO

CREATE TABLE Scheduler.JobTemplateStep
(
	JobTemplateStepId NOT NULL INT
	JobTemplateId NOT NULL INT REFERENCES JobTemplate (JobTemplateId)
	JobTemplateAction VARCHAR(5000) NOT NULL
)
