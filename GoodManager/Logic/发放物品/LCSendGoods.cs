using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using  GoodManager.Entry.LendingInfoDetail_物品详情_;
using GoodManager.DBUtils.DBLendingInfoDetail;
using TF.WebPlatForm.Logic;
using System.Data;
namespace GoodManager.Logic.发放物品
{
    public class LCSendGoods
    {
    
      #region 1.5.3发放物品
        DBLendingInfoDetail db = new DBLendingInfoDetail(ConData.WebSiteConnectionString);
        /// <summary>
        /// 领用人的guid
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable GetTrainuid(string num)
        {
            return db.GetTrainmanGuid(num);
        }
        /// <summary>
        /// 领用人的guid
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable GetLender(string num)
        {
            return db.GetLender(num);
        }
       public Get_OutSendGoods Send(string data)
       {
           Get_OutSendGoods json = new Get_OutSendGoods();
           try
           {
               Get_InSendGoods input = Newtonsoft.Json.JsonConvert.DeserializeObject<Get_InSendGoods>(data);
              
               foreach (LendingInfoDetail l in input.lendingDetailList)
               {
                   if (db.CheckLendAble(l, input.WorkShopGUID))
                   {
                       json.resultStr = "提交失败：" + l.strLendingTypeAlias + " " + l.strLendingExInfo + "已经出借，无法再次借出!";
                       throw new ArgumentOutOfRangeException(l.strLendingTypeAlias + " " + l.strLendingExInfo + "已经出借，无法再次借出!");
                   }
                   if (input.UsesGoodsRange)
                   {
                       if (!db.IsGoodInRange(l.nLendingType, l.strLendingExInfo, input.WorkShopGUID))
                       {
                           json.resultStr = "提交失败：" + l.strLendingTypeAlias + " " + l.strLendingExInfo + "物品编码不在指定的编码范围内,请检查!";
                           throw new ArgumentOutOfRangeException(l.strLendingTypeAlias + " " + l.strLendingExInfo + "物品编码不在指定的编码范围内,请检查!");
                       }
                   }
               }
               db.SendLendingInfo(input.TrainmanGUID, input.remark, input.lendingDetailList);
               json.result = "0";
               json.resultStr = "返回成功";
           }
           catch (Exception ex)
           {
               json.result = "1";
              // json.resultStr = "提交失败：" + ex.Message;
           }
           return json;
       }
       #endregion
    }
}
