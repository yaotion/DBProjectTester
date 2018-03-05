using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoodManager.Entry.GoodStatus_物品状态类型_
{
    public class Get_InGetStateNames
    {
    }
    public class Get_OutGetStateNames
    {
        public string result = "";
        public string resultStr = "";
        public ResultGetStateNames data;
    }

    public class ResultGetStateNames
    {
        public List<ReturnStateType> returnStateList;
    }

}
