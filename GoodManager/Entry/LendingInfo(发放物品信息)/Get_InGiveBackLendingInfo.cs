using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoodManager.Entry.LendingInfoDetail_物品详情_;
namespace GoodManager.Entry.LendingInfo_发放物品信息_
{
    public class Get_InGiveBackLendingInfo
    {
        public string TrainmanGUID;
        public string remark;
        public List<LendingInfoDetail> lendingDetailList;
    }
    public class Get_OutGiveBackLendingInfo
    {
        public string result = "";
        public string resultStr = "";
    }
}
