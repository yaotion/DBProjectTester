using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoodManager.Entry.LendingInfoDetail_物品详情_
{
    public class Get_InSendGoods
    {
        public string TrainmanGUID;
        public string remark;
        public string WorkShopGUID;
        public bool UsesGoodsRange;
        public List<LendingInfoDetail> lendingDetailList;
    }
    public class Get_OutSendGoods
    {
        public string result = "";
        public string resultStr = "";
    }
}
