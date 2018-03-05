using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoodManager.Entry.LendingManager_物品编码_
{
    public class Get_OutGetGoodsCodeRange
    {
        public string result = "";
        public string resultStr = "";
        public codeRangeArrayResult data;
    }
    public class codeRangeArrayResult
    {
        public List<LendingManager> codeRangeArray;
    }
    public class Get_InInsertGoodsCodeRange
    {
        public LendingManager codeRangeEntity;
    }

    public class Get_OutInsertGoodsCodeRange
    {
        public string result = "";
        public string resultStr = "";
    }
}
