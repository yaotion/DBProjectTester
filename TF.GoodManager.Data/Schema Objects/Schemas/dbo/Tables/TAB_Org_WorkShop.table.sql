CREATE TABLE [dbo].[TAB_Org_WorkShop](
	[nid] [int] IDENTITY(1,1) NOT NULL,
	[strWorkShopGUID] [varchar](50) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[strAreaGUID] [varchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[strWorkShopName] [varchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[strWorkShopNumber] [varchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[nIsYunZhuan] [int] NULL,
 CONSTRAINT [PK_TAB_Org_WorkShop] PRIMARY KEY CLUSTERED 
(
	[strWorkShopGUID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)


