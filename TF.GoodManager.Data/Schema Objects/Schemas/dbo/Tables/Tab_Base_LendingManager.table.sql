CREATE TABLE [dbo].[Tab_Base_LendingManager](
	[nID] [int] IDENTITY(1,1) NOT NULL,
	[strGUID] [varchar](50) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[nLendingTypeID] [int] NOT NULL,
	[nStartCode] [int] NOT NULL,
	[nStopCode] [int] NOT NULL,
	[strExceptCodes] [varchar](200) COLLATE Chinese_PRC_CI_AS NULL,
	[strWorkShopGUID] [varchar](50) COLLATE Chinese_PRC_CI_AS NOT NULL,
 CONSTRAINT [PK_Tab_Base_LendingManager] PRIMARY KEY CLUSTERED 
(
	[nID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)


