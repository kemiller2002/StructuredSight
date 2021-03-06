USE [Scheduler]
GO
/****** Object:  Table [dbo].[UpdateLogs]    Script Date: 3/15/2015 4:55:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UpdateLogs](
	[UpdateLogId] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [varchar](50) NOT NULL,
	[Major] [int] NOT NULL,
	[Minor] [int] NOT NULL,
	[Patch] [int] NOT NULL,
	[DateApplied] [datetime2](2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UpdateLogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[UpdateLogs] ADD  DEFAULT (getutcdate()) FOR [DateApplied]
GO
