using System;
using System.Collections.Generic;
using System.Linq;
 
using GoodManager.Entry.LendingManager_物品编码_;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ThinkFreely.DBUtility;
using CommonUtility.json解析;
using TF.WebPlatForm.DBUtils;
 
namespace GoodManager.DBUtils.DBcodeRange
{
    public class DBLendingManager : DBOperator, LendingManagerInterface
 {
        public DBLendingManager(string ConnectionString) : base(ConnectionString) { }
        #region GetGoodsCodeRange方法（1.5.11获取编码范围）
        public List<LendingManager> GetGoodsCodeRange(string WorkShopGUID, int lendingType)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select * from Tab_Base_LendingManager where strWorkShopGUID = '" + WorkShopGUID + "'");
            if (lendingType >-1)
            {
                strSql.Append(" and nLendingTypeID = " + lendingType + "");
            }
            return GetGoodsCodeRange_DTToList(SqlHelper.ExecuteDataset(ConnectionString, CommandType.Text, strSql.ToString()).Tables[0]);
        }
        public List<LendingManager> GetGoodsCodeRange_DTToList(DataTable dt)
        {
            List<LendingManager> modelList = new List<LendingManager>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                LendingManager model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = GetGoodsCodeRange_DRToModelDTToList(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }
        /// <summary>
        /// 获取单个实体
        /// </summary>
        /// <param name="strguid"></param>
        /// <returns></returns>
        public LendingManager GetGoodsCodeRange (string strguid)
        {
            LendingManager model = new LendingManager();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select * from Tab_Base_LendingManager where strGUID = '" + strguid + "'");
             
            DataTable mydt=  SqlHelper.ExecuteDataset(ConnectionString, CommandType.Text, strSql.ToString()).Tables[0] ;
            int rowsCount = mydt.Rows.Count;
            if (rowsCount > 0)
            {
               
                for (int n = 0; n < rowsCount; n++)
                {
                    model = GetGoodsCodeRange_DRToModelDTToList(mydt.Rows[n]);
                    break;
                    
                }
            }
            return model;
        }
        public LendingManager GetGoodsCodeRange_DRToModelDTToList(DataRow dr)
        {
            LendingManager model = new LendingManager();
            if (dr != null)
            {
                model.nID = ObjectConvertClass.static_ext_int(dr["nID"]);
                model.strGUID = ObjectConvertClass.static_ext_string(dr["strGUID"]);
                model.nLendingTypeID = ObjectConvertClass.static_ext_int(dr["nLendingTypeID"]);
                model.nStartCode = ObjectConvertClass.static_ext_int(dr["nStartCode"]);
                model.nStopCode = ObjectConvertClass.static_ext_int(dr["nStopCode"]);
                model.strExceptCodes = ObjectConvertClass.static_ext_string(dr["strExceptCodes"]);
                model.strWorkShopGUID = ObjectConvertClass.static_ext_string(dr["strWorkShopGUID"]);
            }
            return model;
        }
        #endregion


        #region InsertGoodsCodeRange（1.5.12增加编号范围）
        public   bool InsertGoodsCodeRange(LendingManager model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Tab_Base_LendingManager");
            strSql.Append("(strGUID,nLendingTypeID,nStartCode,nStopCode,strExceptCodes,strWorkShopGUID)");
            strSql.Append("values(@strGUID,@nLendingTypeID,@nStartCode,@nStopCode,@strExceptCodes,@strWorkShopGUID)");
            SqlParameter[] sqlParameters = new SqlParameter[] 
            {
                  new SqlParameter("@strGUID", model.strGUID),
                  new SqlParameter("@nLendingTypeID", model.nLendingTypeID),
                  new SqlParameter("@nStartCode", model.nStartCode),
                  new SqlParameter("@nStopCode", model.nStopCode),
                  new SqlParameter("@strExceptCodes", model.strExceptCodes),
                  new SqlParameter("@strWorkShopGUID", model.strWorkShopGUID)
            };
            return SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, strSql.ToString(), sqlParameters) > 0;
        }
        #endregion


        #region UpdateGoodsCodeRange（1.5.13修改编号范围）
        public bool UpdateGoodsCodeRange(LendingManager model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Update Tab_Base_LendingManager set ");
            strSql.Append(" nLendingTypeID = @nLendingTypeID, ");
            strSql.Append(" nStartCode = @nStartCode, ");
            strSql.Append(" nStopCode = @nStopCode, ");
            strSql.Append(" strExceptCodes = @strExceptCodes, ");
            strSql.Append(" strWorkShopGUID = @strWorkShopGUID ");
            strSql.Append(" where strGUID = @strGUID ");
            SqlParameter[] parameters = {
          new SqlParameter("@strGUID", model.strGUID),
          new SqlParameter("@nLendingTypeID", model.nLendingTypeID),
          new SqlParameter("@nStartCode", model.nStartCode),
          new SqlParameter("@nStopCode", model.nStopCode),
          new SqlParameter("@strExceptCodes", model.strExceptCodes),
          new SqlParameter("@strWorkShopGUID", model.strWorkShopGUID)};
            return SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, strSql.ToString(), parameters) > 0;
        }
        #endregion



        #region DeleteGoodsCodeRange（1.5.14删除编号范围）
        public bool DeleteGoodsCodeRange(string rangeGUID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Tab_Base_LendingManager ");
            strSql.Append(" where strGUID = @strGUID ");
            SqlParameter[] sqlParameters = {
                 new SqlParameter("strGUID",rangeGUID)
                                           };
            return SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, strSql.ToString(), sqlParameters) > 0;
        }
        #endregion
        public bool IsGoodInRange(int nLendingType, int strLendingExInfo, string WorkShopGUID)
        {

            string strsql = "select top 1 * from Tab_Base_LendingManager where strWorkShopGUID = '" + WorkShopGUID + "' and ";
            strsql += " nLendingTypeID = " + nLendingType + " and " + strLendingExInfo + " between nStartCode and nStopCode ";
            return SqlHelper.ExecuteDataset(ConnectionString, CommandType.Text, strsql.ToString()).Tables[0].Rows.Count > 0;

        }
    }
}
