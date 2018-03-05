CREATE TABLE [dbo].[TAB_LendingDetail](
	[nID] [int] IDENTITY(1,1) NOT NULL,
	[strGUID] [varchar](50) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[strLendingInfoGUID] [varchar](50) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[nLendingType] [int] NOT NULL,
	[strLendingExInfo] [int] NULL,
	[nReturnState] [int] NULL,
	[dtModifyTime] [datetime] NULL,
	[dtBorrowTime] [datetime] NULL,
	[dtGiveBackTime] [datetime] NULL,
	[nBorrowLoginType] [int] NULL,
	[nGiveBackLoginType] [int] NULL,
	[strBorrowTrainmanGUID] [varchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[strLenderGUID] [varchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[strGiveBackTrainmanGUID] [varchar](50) COLLATE Chinese_PRC_CI_AS NULL,
 CONSTRAINT [PK_TAB_LendingDetail] PRIMARY KEY CLUSTERED 
(
	[strGUID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)


