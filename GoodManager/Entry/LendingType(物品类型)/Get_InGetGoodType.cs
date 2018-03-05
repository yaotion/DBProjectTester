using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoodManager.Entry.LendingType_物品类型_
{
   
    public class Get_InGetGoodType
    {
    }
    public class Get_OutGetGoodType
    {
        public string result = "";
        public string resultStr = "";
        public ResultsGetGoodType data;
    }

    public class ResultsGetGoodType
    {
        public List<LendingType> lendingTypeList;
    }
}
