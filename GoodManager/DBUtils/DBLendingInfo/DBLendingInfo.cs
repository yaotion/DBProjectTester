using System;
using System.Collections.Generic;
using System.Linq;
using TF.WebPlatForm.Logic;
using GoodManager.Entry.LendingInfo_发放物品信息_;
using GoodManager.Entry.GoodsQueryParam_物品查询参数_;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ThinkFreely.DBUtility;
using CommonUtility.json解析;
using TF.WebPlatForm.DBUtils;
namespace GoodManager.DBUtils.DBLendingInfo
{
    public class DBLendingInfo : DBOperator
 {
     public DBLendingInfo(string ConnectionString) : base(ConnectionString) { }
   
        #region QueryRecord方法（1.5.5查询发放记录）
        public List<LendingInfo> QueryRecord(GoodsQueryParam GoodsQueryParam)
        {
            string strSqlWhere = " where 1=1 ";
            if (GoodsQueryParam.dtBeginTime != null && GoodsQueryParam.dtEndTime != null)
            {
                strSqlWhere += " and dtBorrowTime>='" + GoodsQueryParam.dtBeginTime + "' and dtBorrowTime<='" + GoodsQueryParam.dtEndTime + "'";
            }
            if (GoodsQueryParam.nReturnState > -1)
            {
                strSqlWhere += " and (nReturnState = " + GoodsQueryParam.nReturnState + ") ";
            }
            if (GoodsQueryParam.nLendingType > -1)
            {
                strSqlWhere += " and (" + GoodsQueryParam.nLendingType + " in (select nLendingType from TAB_LendingDetail where strLendingInfoGUID = View_LendingInfo.strGUID) )";
            }

            if (GoodsQueryParam.strTrainmanNumber != null && GoodsQueryParam.strTrainmanNumber.ToString() != "")
            {
                strSqlWhere += " and (strBorrowTrainmanNumber = '" + GoodsQueryParam.strTrainmanNumber + "') ";
            }

            if (GoodsQueryParam.strTrainmanName != null && GoodsQueryParam.strTrainmanName.ToString() != "")
            {
                strSqlWhere += " and (strBorrowTrainmanName = '" + GoodsQueryParam.strTrainmanName + "') ";
            }
            if (GoodsQueryParam.strWorkShopGUID != null && GoodsQueryParam.strWorkShopGUID.ToString() != "")
            {
                strSqlWhere += " and (strWorkShopGUID = '" + GoodsQueryParam.strWorkShopGUID + "') ";
            }
            if (GoodsQueryParam.nLendingNumber > -1)
            {
                strSqlWhere += " and (strGUID in (select strLendingInfoGUID from TAB_LendingDetail where strLendingExInfo = " + GoodsQueryParam.nLendingNumber + ") ) ";
            }
            string strSql = "Select * from View_LendingInfo " + strSqlWhere + " order by dtBorrowTime desc";
            return QueryRecord_DTToList(SqlHelper.ExecuteDataset(ConnectionString, CommandType.Text, strSql.ToString()).Tables[0]);
        }
        public List<LendingInfo> QueryRecord_DTToList(DataTable dt)
        {
            List<LendingInfo> modelList = new List<LendingInfo>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                LendingInfo model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = QueryRecord_DRToModelDTToList(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }
        public LendingInfo QueryRecord_DRToModelDTToList(DataRow dr)
        {
            LendingInfo model = new LendingInfo();
            if (dr != null)
            {
                model.strStateName = ObjectConvertClass.static_ext_string(dr["strStateName"]);
                model.strGiveBackLoginName = ObjectConvertClass.static_ext_string(dr["strGiveBackLoginTypeName"]);
                model.strRemark = ObjectConvertClass.static_ext_string(dr["strRemark"]);
                model.strBorrowLoginName = ObjectConvertClass.static_ext_string(dr["strBorrowLoginTypeName"]);
                model.strGiveBackTrainmanNumber = ObjectConvertClass.static_ext_string(dr["strGiveBackTrainmanNumber"]);
                model.strLenderName = ObjectConvertClass.static_ext_string(dr["strLenderName"]);
                model.strGiveBackTrainmanName = ObjectConvertClass.static_ext_string(dr["strGiveBackTrainmanName"]);
                model.strLenderNumber = ObjectConvertClass.static_ext_string(dr["strLenderNumber"]);
                model.strBorrowTrainmanName = ObjectConvertClass.static_ext_string(dr["strBorrowTrainmanName"]);
                model.strBorrowTrainmanNumber = ObjectConvertClass.static_ext_string(dr["strBorrowTrainmanNumber"]);
                model.strGiveBackTrainmanGUID = ObjectConvertClass.static_ext_string(dr["strGiveBackTrainmanGUID"]);
                model.strBorrowTrainmanGUID = ObjectConvertClass.static_ext_string(dr["strBorrowTrainmanGUID"]);
                model.strLenderGUID = ObjectConvertClass.static_ext_string(dr["strLenderGUID"]);
                model.strGUID = ObjectConvertClass.static_ext_string(dr["strGUID"]);
                model.nReturnState = ObjectConvertClass.static_ext_int(dr["nReturnState"]);
                model.strDetails = ObjectConvertClass.static_ext_string(dr["strLendingDetail"]);
                model.strLendingInfoGUID = ObjectConvertClass.static_ext_string(dr["strLendingInfoGUID"]);
                model.dtModifyTime = ObjectConvertClass.static_ext_date(dr["dtModifyTime"]);
                model.dtGiveBackTime = ObjectConvertClass.static_ext_date(dr["dtGiveBackTime"]);
                model.nBorrowLoginType = ObjectConvertClass.static_ext_int(dr["nBorrowLoginType"]);
                model.dtBorrowTime = ObjectConvertClass.static_ext_date(dr["dtBorrowTime"]);
                model.nGiveBackLoginType = ObjectConvertClass.static_ext_int(dr["nGiveBackLoginType"]);
                model.strWorkShopGUID = ObjectConvertClass.static_ext_string(dr["strWorkShopGUID"]);
            }
            return model;
        }
        #endregion
        #region IsHaveNotReturnGoods （1.5.9判断指定人员是否有未归还的物品）
        public bool IsHaveNotReturnGoods(string TrainmanGUID)
        {
            string strSQL = "select * from View_LendingInfo where strBorrowTrainmanGUID='" + TrainmanGUID + "'  and nReturnState = 0 ";
            return SqlHelper.ExecuteDataset(ConnectionString, CommandType.Text, strSQL.ToString()).Tables[0].Rows.Count > 0;

        }
        #endregion
        #region  删除物品及物品相关的发放归还记录
        public void DeleteGoods(int LendingType, string LendingExInfo, string WorkShopGUID)
        {
            string sql = @"delete from TAB_LendingManage where strGUID in (
                    select strLendingInfoGUID from View_LendingInfoDetail where  nLendingType = @LendingType and 
                    strLendingExInfo = @LendingExInfo and strWorkShopGUID = @WorkShopGUID)";

            SqlParameter[] param = { new SqlParameter("LendingType",LendingType),
                                        new SqlParameter("LendingExInfo",LendingExInfo),
                                        new SqlParameter("WorkShopGUID",WorkShopGUID)};


            SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, sql, param);


            sql = @"delete from TAB_LendingDetail where strGUID in  (
                    select strGUID from View_LendingInfoDetail where  nLendingType = @LendingType and 
                    strLendingExInfo = @LendingExInfo and strWorkShopGUID = @WorkShopGUID)";

            SqlParameter[] paramDetail = { new SqlParameter("LendingType",LendingType),
                                        new SqlParameter("LendingExInfo",LendingExInfo),
                                        new SqlParameter("WorkShopGUID",WorkShopGUID)};


            SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, sql, paramDetail);
        }
        #endregion
    }
}
