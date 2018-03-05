using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoodManager.Entry.GoodsQueryParam_物品查询参数_;
namespace GoodManager.Entry.LendingInfo_发放物品信息_
{
    public class Get_InQueryRecord
    {
        public GoodsQueryParam queryParam;
    }
    public class Get_OutQueryRecord
    {
        public string result = "";
        public string resultStr = "";
        public RlendingInfoList data;
    }

    public class RlendingInfoList
    {
        public List<LendingInfo> lendingInfoList;
    }

}
