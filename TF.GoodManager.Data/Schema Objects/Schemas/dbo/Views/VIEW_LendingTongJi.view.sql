CREATE VIEW [dbo].[VIEW_LendingTongJi] (	[nLendingType],
	[nTotalCount],
	[strWorkShopGUID],
	[nNoReturnCount],
	[strLendingTypeName],
	[strAlias])
 AS 
SELECT A.nLendingType, A.nTotalCount, A.strWorkShopGUID, B.nNoReturnCount, 
      dbo.TAB_System_LendingType.strLendingTypeName, 
      dbo.TAB_System_LendingType.strAlias
FROM (SELECT COUNT(DISTINCT strLendingExInfo) AS nTotalCount, nLendingType, 
              strWorkShopGUID
        FROM View_LendingInfoDetail
        GROUP BY strWorkShopGUID, nLendingType) A LEFT OUTER JOIN
          (SELECT COUNT(DISTINCT strLendingExInfo) AS nNoReturnCount, nLendingType, 
               strWorkShopGUID
         FROM View_LendingInfoDetail
         WHERE nReturnState = 0
         GROUP BY strWorkShopGUID, nLendingType) B ON 
      A.nLendingType = B.nLendingType AND 
      A.strWorkShopGUID = B.strWorkShopGUID LEFT OUTER JOIN
      dbo.TAB_System_LendingType ON 
      A.nLendingType = dbo.TAB_System_LendingType.nLendingTypeID


