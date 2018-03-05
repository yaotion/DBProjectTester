using System;
using System.Collections.Generic;
using System.Linq;
 
using System.Text;
using System.Data;
using ThinkFreely.DBUtility;
using CommonUtility.json解析;
using TF.WebPlatForm.DBUtils;
 
using GoodManager.Entry.LendingTjInfo_物品统计_;
namespace GoodManager.DBUtils.DBLendingTJInfo
{

    public class DBLendingTjInfo  : DBOperator
    {
        public DBLendingTjInfo(string ConnectionString) : base(ConnectionString) { }

   
        #region GetTongJiInfo方法（1.5.8获取统计信息）
        public List<LendingTjInfo> GetTongJiInfo(string strWorkShopGUID)
        {
            string strSqlWhere = " select sum(nTotalCount) as  nTotalCount,sum(nNoReturnCount) as  nNoReturnCount  ,strLendingTypeName,strAlias,nLendingType from VIEW_LendingTongJi where  1=1";// 
            if(!string.IsNullOrEmpty(strWorkShopGUID))
           strSqlWhere+=" and strWorkShopGUID = '" + strWorkShopGUID + "' ";

            strSqlWhere += "   group by  strLendingTypeName,strAlias,nLendingType";
            return GetTongJiInfo_DTToList(SqlHelper.ExecuteDataset(ConnectionString, CommandType.Text, strSqlWhere.ToString()).Tables[0]);
        }
        public List<LendingTjInfo> GetTongJiInfo_DTToList(DataTable dt)
        {
            List<LendingTjInfo> modelList = new List<LendingTjInfo>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                LendingTjInfo model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = GetTongJiInfo_DRToModelDTToList(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }
        public LendingTjInfo GetTongJiInfo_DRToModelDTToList(DataRow dr)
        {
            LendingTjInfo model = new LendingTjInfo();
            if (dr != null)
            {
                model.nLendingType = ObjectConvertClass.static_ext_int(dr["nLendingType"]);
                model.nTotalCount = ObjectConvertClass.static_ext_int(dr["nTotalCount"]);
                model.nNoReturnCount = ObjectConvertClass.static_ext_int(dr["nNoReturnCount"]);
                model.strLendingTypeName = ObjectConvertClass.static_ext_string(dr["strLendingTypeName"]);
                model.strTypeAlias = ObjectConvertClass.static_ext_string(dr["strAlias"]);
            }
            return model;
        }
        /// <summary>
        /// 获取工作间名称
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetWorkname(string id)
        {
            string strSqlWhere = "select strWorkShopName from TAB_Org_WorkShop where strWorkShopGUID='" + id + "'";
            DataTable dt = SqlHelper.ExecuteDataset(ConnectionString, CommandType.Text, strSqlWhere.ToString()).Tables[0] ;
            if (dt != null && dt.Rows.Count > 0)
            {
                return dt.Rows[0][0].ToString();
            }
            else
            {
                return "";
            }
            
        }
        #endregion
    }
}
