using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoodManager.Entry.GoodStatus_物品状态类型_;
using TF.WebPlatForm.Logic;
using GoodManager.DBUtils;
namespace GoodManager.Logic.物品状态
{
    public class LCGoodState
    {
        #region 1.5.2获取物品状态类型

        DBReturnStateType db = new DBReturnStateType(ConData.WebSiteConnectionString);
        public Get_OutGetStateNames GetStateNames(string data)
        {
            Get_OutGetStateNames json = new Get_OutGetStateNames();
            try
            {
               // Get_InGetStateNames input = Newtonsoft.Json.JsonConvert.DeserializeObject<Get_InGetStateNames>(data);
            
                ResultGetStateNames Rgs = new ResultGetStateNames();
                Rgs.returnStateList = db.GetStateNames();
                json.data = Rgs;
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
