CREATE VIEW [dbo].[VIEW_Lendings] (	[strGUID],
	[nReturnState],
	[strLendingDetail],
	[strLendingInfoGUID],
	[dtModifyTime],
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
	[strRemark],
	[strGiveBackLoginTypeName],
	[strWorkShopGUID])
 AS 
SELECT TOP 100 PERCENT dbo.TAB_LendingManage.strGUID, 
      dbo.GetLendingReturnState(dbo.TAB_LendingManage.strGUID) AS nReturnState, 
      RTRIM(dbo.LendingDetailsCombine(dbo.TAB_LendingManage.strGUID, 1)) 
      AS strLendingDetail, dbo.View_LendingInfoDetail.strLendingInfoGUID, 
      dbo.View_LendingInfoDetail.dtModifyTime, dbo.View_LendingInfoDetail.dtBorrowTime, 
      dbo.View_LendingInfoDetail.dtGiveBackTime, 
      dbo.View_LendingInfoDetail.nBorrowLoginType, 
      dbo.View_LendingInfoDetail.nGiveBackLoginType, 
      dbo.View_LendingInfoDetail.strLenderGUID, 
      dbo.View_LendingInfoDetail.strBorrowTrainmanGUID, 
      dbo.View_LendingInfoDetail.strGiveBackTrainmanGUID, 
      dbo.View_LendingInfoDetail.strBorrowTrainmanNumber, 
      dbo.View_LendingInfoDetail.strBorrowTrainmanName, 
      dbo.View_LendingInfoDetail.strLenderNumber, 
      dbo.View_LendingInfoDetail.strLenderName, 
      dbo.View_LendingInfoDetail.strGiveBackTrainmanNumber, 
      dbo.View_LendingInfoDetail.strGiveBackTrainmanName, 
      dbo.View_LendingInfoDetail.strBorrowLoginTypeName, 
      dbo.TAB_LendingManage.strRemark, 
      dbo.View_LendingInfoDetail.strGiveBackLoginTypeName, 
      dbo.View_LendingInfoDetail.strWorkShopGUID
FROM dbo.TAB_LendingManage INNER JOIN
      dbo.View_LendingInfoDetail ON 
      dbo.TAB_LendingManage.strGUID = dbo.View_LendingInfoDetail.strLendingInfoGUID
WHERE (dbo.View_LendingInfoDetail.strGUID =
          (SELECT TOP 1 strGUID
         FROM View_LendingInfoDetail
         WHERE strLendingInfoGUID = TAB_LendingManage.strGUID
         ORDER BY CONVERT(varchar(20), getdate(), 120) DESC))


