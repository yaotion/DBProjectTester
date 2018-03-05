/****** Object:  Table [dbo].[TAB_Org_WorkShop]    Script Date: 05/10/2017 10:15:10 ******/
DELETE FROM [dbo].[TAB_Org_WorkShop]
GO
/****** Object:  Table [dbo].[TAB_System_LendingType]    Script Date: 05/10/2017 10:15:11 ******/
DELETE FROM [dbo].[TAB_System_LendingType]
GO
/****** Object:  Table [dbo].[TAB_System_ReturnStateType]    Script Date: 05/10/2017 10:15:11 ******/
DELETE FROM [dbo].[TAB_System_ReturnStateType]
GO
/****** Object:  Table [dbo].[TAB_System_Verify]    Script Date: 05/10/2017 10:15:11 ******/
DELETE FROM [dbo].[TAB_System_Verify]
GO
/****** Object:  Table [dbo].[TAB_System_Verify]    Script Date: 05/10/2017 10:15:11 ******/
INSERT [dbo].[TAB_System_Verify] ([nVerifyID], [strVerifyName]) VALUES (0, N'工号')
INSERT [dbo].[TAB_System_Verify] ([nVerifyID], [strVerifyName]) VALUES (1, N'指纹')
/****** Object:  Table [dbo].[TAB_System_ReturnStateType]    Script Date: 05/10/2017 10:15:11 ******/
SET IDENTITY_INSERT [dbo].[TAB_System_ReturnStateType] ON
INSERT [dbo].[TAB_System_ReturnStateType] ([nid], [nReturnStateID], [strStateName]) VALUES (1, 0, N'未归还')
INSERT [dbo].[TAB_System_ReturnStateType] ([nid], [nReturnStateID], [strStateName]) VALUES (2, 1, N'部分归还')
INSERT [dbo].[TAB_System_ReturnStateType] ([nid], [nReturnStateID], [strStateName]) VALUES (3, 2, N'全部归还')
SET IDENTITY_INSERT [dbo].[TAB_System_ReturnStateType] OFF
/****** Object:  Table [dbo].[TAB_System_LendingType]    Script Date: 05/10/2017 10:15:11 ******/
SET IDENTITY_INSERT [dbo].[TAB_System_LendingType] ON
INSERT [dbo].[TAB_System_LendingType] ([nID], [nLendingTypeID], [strLendingTypeName], [strAlias]) VALUES (3, 1, N'IC卡', N'IC')
INSERT [dbo].[TAB_System_LendingType] ([nID], [nLendingTypeID], [strLendingTypeName], [strAlias]) VALUES (4, 0, N'电台', N'D')
SET IDENTITY_INSERT [dbo].[TAB_System_LendingType] OFF
/****** Object:  Table [dbo].[TAB_Org_WorkShop]    Script Date: 05/10/2017 10:15:10 ******/
SET IDENTITY_INSERT [dbo].[TAB_Org_WorkShop] ON
INSERT [dbo].[TAB_Org_WorkShop] ([nid], [strWorkShopGUID], [strAreaGUID], [strWorkShopName], [strWorkShopNumber], [nIsYunZhuan]) VALUES (10, N'3b50bf66-dabb-48c0-8b6d-05db80591090', N'7243004a-0be3-485d-b9d4-de794a4d22f5', N'唐山车间', N'1', 1)
SET IDENTITY_INSERT [dbo].[TAB_Org_WorkShop] OFF
