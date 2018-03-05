using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoodManager.Entry.LendingManager_物品编码_;
namespace GoodManager.DBUtils.DBcodeRange
{
    public interface LendingManagerInterface 
    {
        bool InsertGoodsCodeRange(LendingManager model);
        bool DeleteGoodsCodeRange(string rangeGUID);
        bool UpdateGoodsCodeRange(LendingManager model);
          bool IsGoodInRange(int nLendingType, int strLendingExInfo, string WorkShopGUID);
          LendingManager GetGoodsCodeRange(string strguid);
          List<LendingManager> GetGoodsCodeRange(string WorkShopGUID, int lendingType);
    }
}
