using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoodManager.Entry.LendingInfo_发放物品信息_;
using    GoodManager.DBUtils.DBLendingInfo;
using TF.WebPlatForm.Logic;
using GoodManager.Entry.LendingInfoDetail_物品详情_;
using GoodManager.DBUtils.DBLendingInfoDetail;
 
namespace GoodManager.Logic.查询发放记录
{
    public class LCQuerySendRecord
    {

        #region 1.5.5查询发放记录

        public Get_OutQueryRecord QueryRecord(string data)
        {
            Get_OutQueryRecord json = new Get_OutQueryRecord();
            try
            {
                Get_InQueryRecord input = Newtonsoft.Json.JsonConvert.DeserializeObject<Get_InQueryRecord>(data);

                RlendingInfoList R = new RlendingInfoList();
                DBLendingInfo db = new DBLendingInfo(ConData.WebSiteConnectionString);

                R.lendingInfoList = db.QueryRecord(input.queryParam);
                json.data = R;
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


        #region 1.5.7查询发放明细



        public Get_OutQueryDetails QueryDetails(string data)
        {
            Get_OutQueryDetails json = new Get_OutQueryDetails();
            try
            {
                Get_InQueryDetails input = Newtonsoft.Json.JsonConvert.DeserializeObject<Get_InQueryDetails>(data);
                DBLendingInfoDetail db = new DBLendingInfoDetail(ConData.WebSiteConnectionString);
                LendingDetailList l = new LendingDetailList();
                l.lendingDetailList = db.QueryDetails(input.queryParam);
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


        #region 1.5.6查询物品最新情况已借出则显示借出情况，已归还仅显示物品情况


        public Get_OutQueryGoodsNow QueryGoodsNow(string data)
        {
            Get_OutQueryGoodsNow json = new Get_OutQueryGoodsNow();
            try
            {
                Get_InQueryGoodsNow input = Newtonsoft.Json.JsonConvert.DeserializeObject<Get_InQueryGoodsNow>(data);
                DBLendingInfoDetail db = new DBLendingInfoDetail(ConData.WebSiteConnectionString);
                LendingDetailList l = new LendingDetailList();
                l.lendingDetailList = db.QueryGoodsNow(input.WorkShopGUID, input.GoodType, input.GoodID, input.orderType);
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
