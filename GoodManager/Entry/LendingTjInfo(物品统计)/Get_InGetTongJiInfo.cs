using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoodManager.Entry.LendingTjInfo_物品统计_
{
 
   public class Get_InGetTongJiInfo
   {
       public string WorkShopGUID;

   }
   public class Get_OutGetTongJiInfo
   {
       public string result = "";
       public string resultStr = "";
       public LendingTjInfos data;
   }

   public class LendingTjInfos
   {
       public List<LendingTjInfo> lendingTjList;
   }
}
