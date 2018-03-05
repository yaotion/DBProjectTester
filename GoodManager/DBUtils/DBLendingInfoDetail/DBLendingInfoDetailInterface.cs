using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using  GoodManager.Entry.LendingInfoDetail_物品详情_;
using GoodManager.Entry.GoodsDetailQueryParam_物品详细参数_;
namespace GoodManager.DBUtils.DBLendingInfoDetail
{
   public interface DBLendingInfoDetailInterface
    {
         bool CheckLendAble(LendingInfoDetail lifd, string strWorkShop);
         bool IsGoodInRange(int nLendingType, int strLendingExInfo, string WorkShopGUID);
         void SendLendingInfo(string TrainmanGUID, string remark, List<LendingInfoDetail> lifd);
         bool CheckReturnAble(string TrainmanGUID, LendingInfoDetail lifd);
         List<LendingInfoDetail> QueryGoodsNow(string WorkShopGUID, int GoodType, int GoodID, int orderType);
         List<LendingInfoDetail> QueryDetails(GoodsDetailQueryParam queryParam);
         List<LendingInfoDetail> GetTrainmanNotReturnLendingInfo(string TrainmanGUID, int state);
    }
}
