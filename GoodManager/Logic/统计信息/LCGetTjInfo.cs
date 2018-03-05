using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoodManager.Entry.LendingTjInfo_物品统计_;
using TF.WebPlatForm.Logic;
using GoodManager.DBUtils.DBLendingTJInfo;
namespace GoodManager.Logic.统计信息
{
    public class LCGetTjInfo
    {
        #region 1.5.8获取统计信息

        public Get_OutGetTongJiInfo GetTongJiInfo(string data)
        {
            Get_OutGetTongJiInfo json = new Get_OutGetTongJiInfo();
            try
            {
                Get_InGetTongJiInfo input = Newtonsoft.Json.JsonConvert.DeserializeObject<Get_InGetTongJiInfo>(data);
                DBLendingTjInfo db = new DBLendingTjInfo(ConData .WebSiteConnectionString);
                LendingTjInfos l = new LendingTjInfos();
                l.lendingTjList = db.GetTongJiInfo(input.WorkShopGUID);
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
        /// <summary>
        /// 车间名称
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetWorkName(string id)
        {
            DBLendingTjInfo db = new DBLendingTjInfo(ConData.WebSiteConnectionString);
            return db.GetWorkname(id);
        }
        #endregion
    }
   
}
