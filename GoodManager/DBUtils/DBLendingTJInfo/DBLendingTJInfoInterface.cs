using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoodManager.Entry.LendingTjInfo_物品统计_;
namespace GoodManager.DBUtils.DBLendingTJInfo
{
    interface DBLendingTJInfoInterface
    {
          List<LendingTjInfo> GetTongJiInfo(string strWorkShopGUID);
    }
}
