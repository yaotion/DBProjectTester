﻿CREATE TABLE [dbo].[TAB_System_Verify](
	[nVerifyID] [int] NOT NULL,
	[strVerifyName] [varchar](50) COLLATE Chinese_PRC_CI_AS NULL,
 CONSTRAINT [PK_TAB_System_Verify] PRIMARY KEY CLUSTERED 
(
	[nVerifyID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)

