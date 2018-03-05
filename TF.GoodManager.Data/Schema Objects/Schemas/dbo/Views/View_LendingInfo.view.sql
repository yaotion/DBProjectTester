﻿CREATE VIEW [dbo].[View_LendingInfo] (	[strStateName],
	[strGiveBackLoginTypeName],
	[strRemark],
	[strBorrowLoginTypeName],
	[strGiveBackTrainmanNumber],
	[strLenderName],
	[strGiveBackTrainmanName],
	[strLenderNumber],
	[strBorrowTrainmanName],
	[strBorrowTrainmanNumber],
	[strGiveBackTrainmanGUID],
	[strBorrowTrainmanGUID],
	[strLenderGUID],
	[strGUID],
	[nReturnState],
	[strLendingDetail],
	[strLendingInfoGUID],
	[dtModifyTime],
	[dtGiveBackTime],
	[nBorrowLoginType],
	[dtBorrowTime],
	[nGiveBackLoginType],
	[strWorkShopGUID])
 AS 
SELECT dbo.TAB_System_ReturnStateType.strStateName, 
      dbo.VIEW_Lendings.strGiveBackLoginTypeName, dbo.VIEW_Lendings.strRemark, 
      dbo.VIEW_Lendings.strBorrowLoginTypeName, 
      dbo.VIEW_Lendings.strGiveBackTrainmanNumber, 
      dbo.VIEW_Lendings.strLenderName, 
      dbo.VIEW_Lendings.strGiveBackTrainmanName, 
      dbo.VIEW_Lendings.strLenderNumber, dbo.VIEW_Lendings.strBorrowTrainmanName, 
      dbo.VIEW_Lendings.strBorrowTrainmanNumber, 
      dbo.VIEW_Lendings.strGiveBackTrainmanGUID, 
      dbo.VIEW_Lendings.strBorrowTrainmanGUID, dbo.VIEW_Lendings.strLenderGUID, 
      dbo.VIEW_Lendings.strGUID, dbo.VIEW_Lendings.nReturnState, 
      dbo.VIEW_Lendings.strLendingDetail, dbo.VIEW_Lendings.strLendingInfoGUID, 
      dbo.VIEW_Lendings.dtModifyTime, dbo.VIEW_Lendings.dtGiveBackTime, 
      dbo.VIEW_Lendings.nBorrowLoginType, dbo.VIEW_Lendings.dtBorrowTime, 
      dbo.VIEW_Lendings.nGiveBackLoginType, 
      dbo.VIEW_Lendings.strWorkShopGUID
FROM dbo.VIEW_Lendings LEFT OUTER JOIN
      dbo.TAB_System_ReturnStateType ON 
      dbo.VIEW_Lendings.nReturnState = dbo.TAB_System_ReturnStateType.nReturnStateID

