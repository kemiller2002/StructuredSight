USE [Scheduler]
GO
/****** Object:  Table [dbo].[JobStep]    Script Date: 3/15/2015 4:55:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JobStep](
	[JobStepId] [int] NOT NULL,
	[JobId] [int] NOT NULL,
	[JobTemplateStepId] [int] NULL,
 CONSTRAINT [PK_JobStep] PRIMARY KEY CLUSTERED 
(
	[JobStepId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[JobStep]  WITH CHECK ADD  CONSTRAINT [FK_JobStep_Job] FOREIGN KEY([JobId])
REFERENCES [dbo].[Job] ([JobId])
GO
ALTER TABLE [dbo].[JobStep] CHECK CONSTRAINT [FK_JobStep_Job]
GO
ALTER TABLE [dbo].[JobStep]  WITH CHECK ADD  CONSTRAINT [FK_JobStep_JobTemplateStep] FOREIGN KEY([JobTemplateStepId])
REFERENCES [Scheduler].[JobTemplateStep] ([JobTemplateStepId])
GO
ALTER TABLE [dbo].[JobStep] CHECK CONSTRAINT [FK_JobStep_JobTemplateStep]
GO
