USE [Scheduler]
GO
/****** Object:  Table [Scheduler].[JobTemplate]    Script Date: 3/15/2015 4:55:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Scheduler].[JobTemplate](
	[JobTemplateId] [int] NOT NULL,
	[JobTemplateName] [varchar](100) NOT NULL,
	[JobTemplateDescription] [varchar](200) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[JobTemplateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
