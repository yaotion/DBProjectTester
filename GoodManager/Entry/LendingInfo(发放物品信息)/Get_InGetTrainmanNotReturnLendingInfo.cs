using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoodManager.Entry.LendingInfoDetail_物品详情_;
namespace GoodManager.Entry.LendingInfo_发放物品信息_
{
    
    public class Get_InGetTrainmanNotReturnLendingInfo
    {
        public string TrainmanGUID;
        public int  state;

    }
    public class Get_OutGetTrainmanNotReturnLendingInfo
    {
        public string result = "";
        public string resultStr = "";
        public LendingDetailList data;
    }
}
