using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoodManager.Entry.LendingManager_物品编码_;
using GoodManager.DBUtils.DBcodeRange;
using TF.WebPlatForm.Logic;
namespace GoodManager.Logic.编码范围
{
   public class LCCodeRange
    {



        #region 1.5.11获取编码范围

       DBLendingManager db = new DBLendingManager(ConData.WebSiteConnectionString);
       public LendingManager GetObj(string strguid)
       {
           try
           {
               LendingManager obj = db.GetGoodsCodeRange(strguid);
               return obj;
           }
           catch
           {
               return null;
           }
       }
       
        public Get_OutGetGoodsCodeRange Get(string data)
        {
            Get_OutGetGoodsCodeRange json = new Get_OutGetGoodsCodeRange();
            try
            {
                Get_InGetGoodsCodeRange input = Newtonsoft.Json.JsonConvert.DeserializeObject<Get_InGetGoodsCodeRange>(data);
            
                codeRangeArrayResult cr = new codeRangeArrayResult();
                cr.codeRangeArray = db.GetGoodsCodeRange(input.WorkShopGUID, input.lendingType);
                json.data = cr;
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

        #region 1.5.12增加编号范围

       
        public Get_OutInsertGoodsCodeRange Add(string data)
        {

            Get_InInsertGoodsCodeRange model = null;
            Get_OutInsertGoodsCodeRange json = new Get_OutInsertGoodsCodeRange();
            try
            {
                model = Newtonsoft.Json.JsonConvert.DeserializeObject<Get_InInsertGoodsCodeRange>(data);
           
                if (db.InsertGoodsCodeRange(model.codeRangeEntity))
                {
                    json.result = "0";
                    json.resultStr = "返回成功，成功插入一条数据！";
                }
                else
                {
                    json.result = "1";
                    json.resultStr = "返回失败，请查找原因！";
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

        #region 1.5.13修改编号范围


        public Get_OutInsertGoodsCodeRange Update(string data)
        {

            Get_InInsertGoodsCodeRange model = null;
            Get_OutInsertGoodsCodeRange json = new Get_OutInsertGoodsCodeRange();
            try
            {
                model = Newtonsoft.Json.JsonConvert.DeserializeObject<Get_InInsertGoodsCodeRange>(data);
               
                if (db.UpdateGoodsCodeRange(model.codeRangeEntity))
                {
                    json.result = "0";
                    json.resultStr = "返回成功，成功修改一条数据！";
                }
                else
                {
                    json.result = "1";
                    json.resultStr = "返回失败，请查找原因！";
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

        #region 1.5.14删除编号范围
 

        
        public Get_OutDeleteGoodsCodeRange Delete(string data)
        {

            Get_InDeleteGoodsCodeRange model = null;
            Get_OutDeleteGoodsCodeRange json = new Get_OutDeleteGoodsCodeRange();
            try
            {
                model = Newtonsoft.Json.JsonConvert.DeserializeObject<Get_InDeleteGoodsCodeRange>(data);
             
                if (db.DeleteGoodsCodeRange(model.rangeGUID))
                {
                    json.result = "0";
                    json.resultStr = "返回成功，成功删除一条数据！";
                }
                else
                {
                    json.result = "0";
                    json.resultStr = "执行成功，返回0条数据！";
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

    }
}
