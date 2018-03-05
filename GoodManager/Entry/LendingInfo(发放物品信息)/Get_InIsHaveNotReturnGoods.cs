using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoodManager.Entry.LendingInfo_发放物品信息_
{
     
    public class Get_InIsHaveNotReturnGoods
    {
        public string TrainmanGUID;

    }
    public class Get_OutIsHaveNotReturnGoods
    {
        public string result = "";
        public string resultStr = "";
        public Results data;
    }

    public class Results
    {
        public bool result;
    }
}
