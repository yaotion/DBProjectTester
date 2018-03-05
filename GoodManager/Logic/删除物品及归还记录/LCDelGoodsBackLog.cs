using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoodManager.Entry.LendingInfo_发放物品信息_;
using GoodManager.DBUtils.DBLendingInfo;
using TF.WebPlatForm.Logic;
namespace GoodManager.Logic.删除物品及归还记录
{
   public class LCDelGoodsBackLog
    {
   
    #region "删除物品及物品相关的发放归还记录"
       DBLendingInfo db = new DBLendingInfo(ConData.WebSiteConnectionString);

       public Get_OutDeleteGoods DeleteGoods(string data)
       {
           
           Get_OutDeleteGoods result = new Get_OutDeleteGoods();

           try
           {
               Get_InDeleteGoods input = Newtonsoft.Json.JsonConvert.DeserializeObject<Get_InDeleteGoods>(data);
               db.DeleteGoods(input.LendingType, input.LendingExInfo, input.WorkShopGUID);
               result.result = "0";
               result.resultStr = "ok";
           }
           catch (Exception ex)
           {
               result.result = "1";
               result.resultStr = ex.Message.ToString();
           }
          
           return result;
       }

       #endregion
    }
}
