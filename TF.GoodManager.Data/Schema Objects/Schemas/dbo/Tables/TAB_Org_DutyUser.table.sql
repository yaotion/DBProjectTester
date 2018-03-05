CREATE TABLE [dbo].[TAB_Org_DutyUser](
	[nid] [int] IDENTITY(1,1) NOT NULL,
	[strDutyGUID] [varchar](50) COLLATE Chinese_PRC_CI_AS NOT NULL CONSTRAINT [DF__TAB_Org_D__strDu__7E6CC920]  DEFAULT (newid()),
	[strDutyNumber] [varchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[strDutyName] [varchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[strPassword] [varchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[nDeleteState] [int] NULL CONSTRAINT [DF__TAB_Org_D__nDele__7F60ED59]  DEFAULT ((0)),
	[strAreaGUID] [varchar](50) COLLATE Chinese_PRC_CI_AS NULL CONSTRAINT [DF_TAB_Org_DutyUser_nRoleID]  DEFAULT ((0)),
	[nRoleID] [int] NULL,
	[dtCreateTime] [datetime] NULL CONSTRAINT [DF_TAB_Org_DutyUser_dtCreateTime]  DEFAULT (getdate()),
	[strTokenID] [varchar](64) COLLATE Chinese_PRC_CI_AS NULL,
	[dtTokenTime] [datetime] NULL,
	[dtLoginTime] [datetime] NULL,
	[strWorkShopGUID] [varchar](50) COLLATE Chinese_PRC_CI_AS NULL,
 CONSTRAINT [PK_TAB_ORG_DUTYUSER] PRIMARY KEY CLUSTERED 
(
	[strDutyGUID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)


