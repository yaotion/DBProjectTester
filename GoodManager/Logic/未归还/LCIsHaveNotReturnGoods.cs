using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoodManager.Entry.LendingInfo_发放物品信息_;
using GoodManager.DBUtils.DBLendingInfo;
using TF.WebPlatForm.Logic;
using GoodManager.Entry.LendingInfoDetail_物品详情_;
using GoodManager.DBUtils.DBLendingInfoDetail;
namespace GoodManager.Logic.未归还
{
    public class LCIsHaveNotReturnGoods
    {
        #region 1.5.9判断指定人员是否有未归还的物品
      
        public Get_OutIsHaveNotReturnGoods IsHaveNotReturnGoods(string data)
        {
            Get_OutIsHaveNotReturnGoods json = new Get_OutIsHaveNotReturnGoods();
            try
            {
                Get_InIsHaveNotReturnGoods input = Newtonsoft.Json.JsonConvert.DeserializeObject<Get_InIsHaveNotReturnGoods>(data);
                DBLendingInfo db = new DBLendingInfo(ConData .WebSiteConnectionString);
                Results r = new Results();
                r.result = db.IsHaveNotReturnGoods(input.TrainmanGUID);
                if (r.result)
                {
                    json.data = r;
                    json.result = "0";
                    json.resultStr = "返回成功";
                }
                else
                {
                    json.result = "1";
                    json.resultStr = "提交失败："  ;
                }
            }
            catch (Exception ex)
            {
                json.result = "1";
                json.resultStr = "提交失败：" + ex.Message;
            }
            return json;
        }
        #endregion

        #region 1.5.10获得指定人员未归还物品列表
       

        public Get_OutGetTrainmanNotReturnLendingInfo GetTrainmanNotReturnLendingInfo(string data)
        {
            Get_OutGetTrainmanNotReturnLendingInfo json = new Get_OutGetTrainmanNotReturnLendingInfo();
            try
            {
                Get_InGetTrainmanNotReturnLendingInfo input = Newtonsoft.Json.JsonConvert.DeserializeObject<Get_InGetTrainmanNotReturnLendingInfo>(data);
              
                LendingDetailList l = new LendingDetailList();
                DBLendingInfoDetail db = new DBLendingInfoDetail(ConData.WebSiteConnectionString);
                l.lendingDetailList = db.GetTrainmanNotReturnLendingInfo(input.TrainmanGUID, input.state);
                json.data = l;
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
