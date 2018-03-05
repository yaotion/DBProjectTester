using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoodManager.Entry.LendingType_物品类型_;
using GoodManager.DBUtils;
using TF.WebPlatForm.Logic;
namespace GoodManager.Logic.物品类型
{
   public class LCGoodType
    {

   
     #region 1.5.1获取物品类型）
       DBGoodType db = new DBGoodType(ConData.WebSiteConnectionString);

       public Get_OutGetGoodType GetGoodType(string data)
        {
            Get_OutGetGoodType json = new Get_OutGetGoodType();
            try
            {
               // Get_InGetGoodType input = Newtonsoft.Json.JsonConvert.DeserializeObject<Get_InGetGoodType>(data);
              

                ResultsGetGoodType RGT=new ResultsGetGoodType();
                RGT.lendingTypeList= db.GetGoodType();
                json.data = RGT;
                json.result = "0";
                json.resultStr = "返回成功";
            }
            catch (Exception ex)
            {
                json.result = "1";
                json.resultStr = "提交失败：" + ex.Message;
            }
            return json;
        }
        #endregion
    }
}
