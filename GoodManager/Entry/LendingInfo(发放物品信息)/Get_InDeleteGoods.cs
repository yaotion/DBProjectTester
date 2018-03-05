using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoodManager.Entry.LendingInfo_发放物品信息_
{
    public class Get_InDeleteGoods
    {
        public int LendingType;
        public string LendingExInfo;
        public string WorkShopGUID;
    }

    public class Get_OutDeleteGoods
    {
        public string result = "";
        public string resultStr = "";
        public object data;
    }
}
