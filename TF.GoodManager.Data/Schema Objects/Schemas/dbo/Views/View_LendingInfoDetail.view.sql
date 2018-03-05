CREATE VIEW [dbo].[View_LendingInfoDetail] (	[strLendingInfoGUID],
	[nLendingType],
	[strLendingExInfo],
	[nReturnState],
	[dtModifyTime],
	[strGUID],
	[nID],
	[dtBorrowTime],
	[dtGiveBackTime],
	[nBorrowLoginType],
	[nGiveBackLoginType],
	[strLenderGUID],
	[strBorrowTrainmanGUID],
	[strGiveBackTrainmanGUID],
	[strBorrowTrainmanNumber],
	[strBorrowTrainmanName],
	[strLenderNumber],
	[strLenderName],
	[strGiveBackTrainmanNumber],
	[strGiveBackTrainmanName],
	[strBorrowLoginTypeName],
	[strGiveBackLoginTypeName],
	[strLendingTypeName],
	[strAlias],
	[strStateName],
	[nMinutes],
	[strWorkShopGUID])
 AS 
SELECT dbo.TAB_LendingDetail.strLendingInfoGUID, 
      dbo.TAB_LendingDetail.nLendingType, dbo.TAB_LendingDetail.strLendingExInfo, 
      dbo.TAB_LendingDetail.nReturnState, dbo.TAB_LendingDetail.dtModifyTime, 
      dbo.TAB_LendingDetail.strGUID, dbo.TAB_LendingDetail.nID, 
      dbo.TAB_LendingDetail.dtBorrowTime, dbo.TAB_LendingDetail.dtGiveBackTime, 
      dbo.TAB_LendingDetail.nBorrowLoginType, 
      dbo.TAB_LendingDetail.nGiveBackLoginType, dbo.TAB_LendingDetail.strLenderGUID, 
      dbo.TAB_LendingDetail.strBorrowTrainmanGUID, 
      dbo.TAB_LendingDetail.strGiveBackTrainmanGUID, 
      BorrowTrainman.strTrainmanNumber AS strBorrowTrainmanNumber, 
      BorrowTrainman.strTrainmanName AS strBorrowTrainmanName, 
      Lender.strTrainmanNumber AS strLenderNumber, 
      Lender.strTrainmanName AS strLenderName, 
      GiveBackTrainman.strTrainmanNumber AS strGiveBackTrainmanNumber, 
      GiveBackTrainman.strTrainmanName AS strGiveBackTrainmanName, 
      BorrowLoginType.strVerifyName AS strBorrowLoginTypeName, 
      GiveBackLoginType.strVerifyName AS strGiveBackLoginTypeName, 
      dbo.TAB_System_LendingType.strLendingTypeName, 
      dbo.TAB_System_LendingType.strAlias, 
      dbo.TAB_System_ReturnStateType.strStateName, DATEDIFF(mi, 
      dbo.TAB_LendingDetail.dtBorrowTime, GETDATE()) AS nMinutes, 
      BorrowTrainman.strWorkShopGUID
FROM dbo.TAB_System_Verify GiveBackLoginType RIGHT OUTER JOIN
      dbo.TAB_System_LendingType RIGHT OUTER JOIN
      dbo.TAB_LendingDetail LEFT OUTER JOIN
      dbo.TAB_System_ReturnStateType ON 
      dbo.TAB_LendingDetail.nReturnState = dbo.TAB_System_ReturnStateType.nReturnStateID
       ON 
      dbo.TAB_System_LendingType.nLendingTypeID = dbo.TAB_LendingDetail.nLendingType
       ON 
      GiveBackLoginType.nVerifyID = dbo.TAB_LendingDetail.nGiveBackLoginType LEFT OUTER
       JOIN
      dbo.TAB_System_Verify BorrowLoginType ON 
      dbo.TAB_LendingDetail.nBorrowLoginType = BorrowLoginType.nVerifyID LEFT OUTER JOIN
      dbo.TAB_Org_Trainman GiveBackTrainman ON 
      dbo.TAB_LendingDetail.strGiveBackTrainmanGUID = GiveBackTrainman.strTrainmanGUID
       LEFT OUTER JOIN
      dbo.TAB_Org_Trainman Lender ON 
      dbo.TAB_LendingDetail.strLenderGUID = Lender.strTrainmanGUID LEFT OUTER JOIN
      dbo.TAB_Org_Trainman BorrowTrainman ON 
      dbo.TAB_LendingDetail.strBorrowTrainmanGUID = BorrowTrainman.strTrainmanGUID


