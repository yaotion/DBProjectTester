CREATE TABLE [dbo].[TAB_System_LendingType](
	[nID] [int] IDENTITY(1,1) NOT NULL,
	[nLendingTypeID] [int] NOT NULL,
	[strLendingTypeName] [varchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[strAlias] [varchar](10) COLLATE Chinese_PRC_CI_AS NULL,
 CONSTRAINT [PK_TAB_System_LendingType] PRIMARY KEY CLUSTERED 
(
	[nID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)


