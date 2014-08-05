DROP TABLE Scheduler.JobTemplate

GO

CREATE TABLE Scheduler.JobTemplate
(
	JobTemplateId INT NOT NULL PRIMARY KEY
	,JobTemplateName VARCHAR(100) NOT NULL
	,JobTemplateDescription VARCHAR(200) NOT NULL
)

