using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using  GoodManager.Entry.LendingInfo_发放物品信息_;
using GoodManager.Entry.GoodsQueryParam_物品查询参数_;
namespace GoodManager.DBUtils.DBLendingInfo
{
    public interface DBLendingInfoInterface
    {
          List<LendingInfo> QueryRecord(GoodsQueryParam GoodsQueryParam);
          bool IsHaveNotReturnGoods(string TrainmanGUID);
          void DeleteGoods(int LendingType, string LendingExInfo, string WorkShopGUID);
    }
}
