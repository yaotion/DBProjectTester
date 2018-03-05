CREATE TABLE [dbo].[TAB_System_ReturnStateType](
	[nid] [int] IDENTITY(1,1) NOT NULL,
	[nReturnStateID] [int] NOT NULL,
	[strStateName] [varchar](50) COLLATE Chinese_PRC_CI_AS NOT NULL,
 CONSTRAINT [PK_TAB_System_ReturnStateType] PRIMARY KEY CLUSTERED 
(
	[nReturnStateID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)


