CREATE VIEW [dbo].[VIEW_Lending_Last] (	[strLendingInfoGUID],
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
SELECT     strLendingInfoGUID, nLendingType, strLendingExInfo, nReturnState, dtModifyTime, strGUID, nID, dtBorrowTime, dtGiveBackTime, nBorrowLoginType, 
                      nGiveBackLoginType, strLenderGUID, strBorrowTrainmanGUID, strGiveBackTrainmanGUID, strBorrowTrainmanNumber, strBorrowTrainmanName, 
                      strLenderNumber, strLenderName, strGiveBackTrainmanNumber, strGiveBackTrainmanName, strBorrowLoginTypeName, strGiveBackLoginTypeName, 
                      strLendingTypeName, strAlias, strStateName, nMinutes, strWorkShopGUID
FROM         dbo.View_LendingInfoDetail
WHERE     (nID IN
                          (SELECT     MAX(nID) AS Expr1
                            FROM          dbo.View_LendingInfoDetail AS View_LendingInfoDetail_1
                            GROUP BY strWorkShopGUID, nLendingType, strLendingExInfo))


