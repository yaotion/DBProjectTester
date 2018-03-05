using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoodManager.Entry.LendingInfo_发放物品信息_;
using GoodManager.Entry.LendingInfoDetail_物品详情_;
using GoodManager.DBUtils.DBLendingInfoDetail;
using GoodManager.DBUtils.DBLendingInfoDetail;
using TF.WebPlatForm.Logic;
namespace GoodManager.Logic.归还物品
{
    public class LCGiveBackLendingInfo
    {
        #region 1.5.4归还物品
        DBLendingInfoDetail db = new DBLendingInfoDetail(ConData.WebSiteConnectionString);
   
        public Get_OutGiveBackLendingInfo Recieve(string data)
        {
            Get_OutGiveBackLendingInfo json = new Get_OutGiveBackLendingInfo();
            try
            {
                Get_InGiveBackLendingInfo input = Newtonsoft.Json.JsonConvert.DeserializeObject<Get_InGiveBackLendingInfo>(data);
              
                foreach (LendingInfoDetail l in input.lendingDetailList)
                {
                    if (!db.CheckReturnAble(input.TrainmanGUID, l))
                    {
                        json.resultStr = "提交失败：未找到" + l.strLendingTypeAlias + " " + l.strLendingExInfo + "的借用记录!";
                        throw new ArgumentOutOfRangeException("未找到" + l.strLendingTypeAlias + " " + l.strLendingExInfo + "的借用记录!");
                    }
                }

                db.GiveBackDetail(input.lendingDetailList);

                foreach (LendingInfoDetail l in input.lendingDetailList)
                {
                    db.UpdateLendingInfoRemark(l.strLendingInfoGUID, input.remark);

                }
                json.result = "0";
                json.resultStr = "返回成功";
            }
            catch (Exception ex)
            {
                json.result = "1";
                //json.resultStr = "提交失败：" ; 
            }
            return json;
        }
        #endregion
    }
    
}
