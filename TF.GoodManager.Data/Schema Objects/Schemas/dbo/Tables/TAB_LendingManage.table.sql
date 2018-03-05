CREATE TABLE [dbo].[TAB_LendingManage](
	[nID] [int] IDENTITY(1,1) NOT NULL,
	[strGUID] [varchar](50) COLLATE Chinese_PRC_CI_AS NOT NULL CONSTRAINT [DF_TAB_LendingManage_strGUID]  DEFAULT (newid()),
	[nReturnState] [int] NULL,
	[strBorrowTrainmanGUID] [varchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[nBorrowLoginType] [int] NULL CONSTRAINT [DF_TAB_LendingManage_nBorrowLoginType]  DEFAULT ((-1)),
	[dtBorrowTime] [datetime] NULL,
	[strLenderGUID] [varchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[strGiveBackTrainmanGUID] [varchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[nGiveBackLoginType] [int] NULL CONSTRAINT [DF_TAB_LendingManage_nGiveBackLoginType]  DEFAULT ((-1)),
	[dtGiveBackTime] [datetime] NULL,
	[strRemark] [varchar](200) COLLATE Chinese_PRC_CI_AS NULL,
	[dtModifyTime] [datetime] NULL,
 CONSTRAINT [PK_TAB_LendingManage] PRIMARY KEY CLUSTERED 
(
	[strGUID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)


