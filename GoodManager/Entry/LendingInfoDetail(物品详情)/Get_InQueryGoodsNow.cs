using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoodManager.Entry.LendingInfoDetail_物品详情_
{
    public class Get_InQueryGoodsNow
    {
        public string WorkShopGUID;
        public int GoodType;
        public int GoodID;
        public int orderType;

    }
    public class Get_OutQueryGoodsNow
    {
        public string result = "";
        public string resultStr = "";
        public LendingDetailList data;
    }

   
}
