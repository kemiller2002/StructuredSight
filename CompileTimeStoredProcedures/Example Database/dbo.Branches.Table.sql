USE [Scheduler]
GO
/****** Object:  Table [dbo].[Branches]    Script Date: 3/15/2015 4:55:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Branches](
	[BranchId] [int] NOT NULL,
	[Version_VersionId] [int] NOT NULL
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Branches]  WITH CHECK ADD FOREIGN KEY([Version_VersionId])
REFERENCES [dbo].[Versions] ([VersionId])
GO
