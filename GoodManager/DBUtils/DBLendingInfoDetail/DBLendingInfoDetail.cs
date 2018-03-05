using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ThinkFreely.DBUtility;
using CommonUtility.json解析;
using TF.WebPlatForm.DBUtils;
using GoodManager.Entry.LendingInfoDetail_物品详情_;
using GoodManager.Entry.GoodsQueryParam_物品查询参数_;
using GoodManager.Entry.GoodsDetailQueryParam_物品详细参数_;
namespace GoodManager.DBUtils.DBLendingInfoDetail
{
    public class DBLendingInfoDetail : DBOperator
    {
        public DBLendingInfoDetail(string ConnectionString) : base(ConnectionString) { }

        #region （1.5.3发放物品）
        public bool CheckLendAble(LendingInfoDetail lifd, string strWorkShop)
        {
            if (lifd.strLendingExInfo == 0)
            {
                return true;
            }
            string strSQL = "select TAB_LendingDetail.nid,TAB_Org_Trainman.strWorkShopGUID ";
            strSQL += " from TAB_LendingDetail Left Join TAB_Org_Trainman On ";
            strSQL += " TAB_LendingDetail.strBorrowTrainmanGUID = Tab_Org_Trainman.strTrainmanGUID ";
            strSQL += " where strWorkShopGUID = '" + strWorkShop + "' and strLendingExInfo = " + lifd.strLendingExInfo + " and nReturnState = 0 and nLendingType = " + lifd.nLendingType + "";
            return SqlHelper.ExecuteDataset(ConnectionString, CommandType.Text, strSQL.ToString()).Tables[0].Rows.Count > 0;
        }
        /// <summary>
        /// 获取警员人的工作间号及id
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable  GetTrainmanGuid(string num)
        {
            string strSQL = "select strTrainmanGUID ,strWorkShopGUID ,strTrainmanName from  TAB_Org_Trainman where strTrainmanNumber='" + num + "' ";
            return SqlHelper.ExecuteDataset(ConnectionString, CommandType.Text, strSQL.ToString()).Tables[0] ;

        }
        public DataTable GetLender(string num)
        {
            string strSQL = "select strDutyGUID ,strDutyName from  TAB_Org_DutyUser where strDutyNumber='" + num + "' ";
            return SqlHelper.ExecuteDataset(ConnectionString, CommandType.Text, strSQL.ToString()).Tables[0];

        }
        /// <summary>
        /// 判断物品是否在借的范围
        /// </summary>
        /// <param name="nLendingType"></param>
        /// <param name="strLendingExInfo"></param>
        /// <param name="WorkShopGUID"></param>
        /// <returns></returns>
        public bool IsGoodInRange(int nLendingType, int strLendingExInfo, string WorkShopGUID)
        {

            string strsql = "select top 1 * from Tab_Base_LendingManager where strWorkShopGUID = '" + WorkShopGUID + "' and ";
            strsql += " nLendingTypeID = " + nLendingType + " and " + strLendingExInfo + " between nStartCode and nStopCode ";
            return SqlHelper.ExecuteDataset(ConnectionString, CommandType.Text, strsql.ToString()).Tables[0].Rows.Count > 0;

        }
        /// <summary>
        /// 判断是否有借 
        /// </summary>
        /// <param name="TrainmanGUID"></param>
        /// <param name="remark"></param>
        /// <param name="lifd"></param>
        public void SendLendingInfo(string TrainmanGUID, string remark, List<LendingInfoDetail> lifd)
        {
            string strSql = "select strGUID from View_LendingInfo where strBorrowTrainmanGUID = '" + TrainmanGUID + "' and nReturnState = 0";
            string strGUID = "";
            DataTable dt = SqlHelper.ExecuteDataset(ConnectionString, CommandType.Text, strSql.ToString()).Tables[0];
            if (dt.Rows.Count == 0)
            {
                strGUID = Guid.NewGuid().ToString();
                InsertLendingInfo(remark, strGUID);
            }
            else
            {
                strGUID = dt.Rows[0]["strGUID"].ToString();
            }
            foreach (LendingInfoDetail l in lifd)
            {
                l.strLendingInfoGUID = strGUID;
            }

            AddLendingDetails(lifd);

        }

        public void AddLendingDetails(List<LendingInfoDetail> lifd)
        {
            if (lifd.Count <= 0)
            {
                return;
            }

            foreach (LendingInfoDetail l in lifd)
            {
                string strSql = "insert into TAB_LendingDetail(strGUID,dtBorrowTime,nBorrowLoginType,strBorrowTrainmanGUID,strLenderGUID,strLendingInfoGUID,nLendingType,strLendingExInfo,nReturnState,dtModifyTime)";
                strSql += " values(@strGUID,@dtBorrowTime,@nBorrowLoginType,@strBorrowTrainmanGUID,@strLenderGUID,@strLendingInfoGUID,@nLendingType,@strLendingExInfo,@nReturnState,@dtModifyTime)";
                SqlParameter[] sqlParameters = new SqlParameter[]
                    {
                            new SqlParameter("@strGUID",l.strGUID),
                            new SqlParameter("@dtBorrowTime",l.dtBorrwoTime),
                            new SqlParameter("@nBorrowLoginType",l.nBorrowVerifyType),
                            new SqlParameter("@strBorrowTrainmanGUID",l.strTrainmanGUID),
                            new SqlParameter("@strLenderGUID",l.strLenderGUID),
                            new SqlParameter("@strLendingInfoGUID",l.strLendingInfoGUID),
                            new SqlParameter("@nLendingType",l.nLendingType),
                            new SqlParameter("strLendingExInfo",l.strLendingExInfo),
                            new SqlParameter("nReturnState",l.nReturnState),
                            new SqlParameter("dtModifyTime",l.dtModifyTime),
                    };
                SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, strSql, sqlParameters);
            }
        }

        public void InsertLendingInfo(string strRemark, string strGUID)
        {
            string strSql = "insert into TAB_LendingManage(strGUID,strRemark) values ('" + strGUID + "','" + strRemark + "')";
            SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, strSql);
        }

        #endregion

        #region （1.5.4归还物品）
        public bool CheckReturnAble(string TrainmanGUID, LendingInfoDetail lifd)
        {
            string strSQL = "select * from View_LendingInfoDetail where strBorrowTrainmanGUID =  ";
            strSQL += " '" + TrainmanGUID + "' and nReturnState = 0 and nLendingType = " + lifd.nLendingType + " and strLendingExInfo = " + lifd.strLendingExInfo + " ";
            DataTable dt = SqlHelper.ExecuteDataset(ConnectionString, CommandType.Text, strSQL.ToString()).Tables[0];

            if (dt.Rows.Count > 0)
            {
                lifd.strGUID = dt.Rows[0]["strGUID"].ToString();
                lifd.strLendingInfoGUID = dt.Rows[0]["strLendingInfoGUID"].ToString();
                return true;
            }
            else
            {
                return false;
            }
        }

        public void GiveBackDetail(List<LendingInfoDetail> lifd)
        {
            foreach (LendingInfoDetail l in lifd)
            {
                string UPDATE_SQL = "Update TAB_LendingDetail set dtModifyTime = '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "',nReturnState = 2 ";
                UPDATE_SQL += " ,dtGiveBackTime = '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' ";
                UPDATE_SQL += ",nGiveBackLoginType = " + l.nGiveBackVerifyType + ",strGiveBackTrainmanGUID ='" + l.strGiveBackTrainmanGUID + "' where strGUID = '" + l.strGUID + "'";
                SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, UPDATE_SQL);
            }
        }
        public void UpdateLendingInfoRemark(string strGUID, string remark)
        {
            string strSQL = "update TAB_LendingManage set  strRemark = '" + remark + "' where strGUID = '" + strGUID + "'";
            SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, strSQL);
        }
        #endregion

        #region QueryGoodsNow方法（1.5.6查询物品最新情况已借出则显示借出情况，已归还仅显示物品情况）
        public List<LendingInfoDetail> QueryGoodsNow(string WorkShopGUID, int GoodType, int GoodID, int orderType)
        {
            string strSqlWhere = " select * from VIEW_Lending_Last where 1=1 ";
            if (WorkShopGUID != null && WorkShopGUID != "")
            {
                strSqlWhere += " and strWorkShopGUID='" + WorkShopGUID + "'";
            }
            if (GoodType >= 0)
            {
                strSqlWhere += " and nLendingType = " + GoodType + " ";
            }
            if (GoodID != -1)
            {
                strSqlWhere += " and strLendingExInfo =" + GoodID + "";
            }

            if (orderType == 1)
            {
                strSqlWhere += " order by cast (strLendingExInfo as int) ";
            }
            else
            {
                strSqlWhere += "  order by nReturnState,dtBorrowTime  ";
            }


            return QueryGoodsNow_DTToList(SqlHelper.ExecuteDataset(ConnectionString, CommandType.Text, strSqlWhere.ToString()).Tables[0]);
        }
        public List<LendingInfoDetail> QueryGoodsNow_DTToList(DataTable dt)
        {
            List<LendingInfoDetail> modelList = new List<LendingInfoDetail>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                LendingInfoDetail model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = QueryGoodsNow_DRToModelDTToList(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }
        public LendingInfoDetail QueryGoodsNow_DRToModelDTToList(DataRow dr)
        {
            LendingInfoDetail model = new LendingInfoDetail();
            if (dr != null)
            {
                model.strLendingInfoGUID = ObjectConvertClass.static_ext_string(dr["strLendingInfoGUID"]);
                model.nLendingType = ObjectConvertClass.static_ext_int(dr["nLendingType"]);
                model.strLendingExInfo = ObjectConvertClass.static_ext_int(dr["strLendingExInfo"]);
                model.nReturnState = ObjectConvertClass.static_ext_int(dr["nReturnState"]);
                model.dtModifyTime = ObjectConvertClass.static_ext_date(dr["dtModifyTime"]);
                model.strGUID = ObjectConvertClass.static_ext_string(dr["strGUID"]);
                model.nID = ObjectConvertClass.static_ext_int(dr["nID"]);
                model.dtBorrwoTime = ObjectConvertClass.static_ext_date(dr["dtBorrowTime"]);
                model.dtGiveBackTime = ObjectConvertClass.static_ext_date(dr["dtGiveBackTime"]);
                model.nBorrowVerifyType = ObjectConvertClass.static_ext_int(dr["nBorrowLoginType"]);
                model.nGiveBackVerifyType = ObjectConvertClass.static_ext_int(dr["nGiveBackLoginType"]);
                model.strLenderGUID = ObjectConvertClass.static_ext_string(dr["strLenderGUID"]);
                model.strTrainmanGUID = ObjectConvertClass.static_ext_string(dr["strBorrowTrainmanGUID"]);
                model.strGiveBackTrainmanGUID = ObjectConvertClass.static_ext_string(dr["strGiveBackTrainmanGUID"]);
                model.strTrainmanNumber = ObjectConvertClass.static_ext_string(dr["strBorrowTrainmanNumber"]);
                model.strTrainmanName = ObjectConvertClass.static_ext_string(dr["strBorrowTrainmanName"]);
                model.strLenderNumber = ObjectConvertClass.static_ext_string(dr["strLenderNumber"]);
                model.strLenderName = ObjectConvertClass.static_ext_string(dr["strLenderName"]);
                model.strGiveBackTrainmanNumber = ObjectConvertClass.static_ext_string(dr["strGiveBackTrainmanNumber"]);
                model.strGiveBackTrainmanName = ObjectConvertClass.static_ext_string(dr["strGiveBackTrainmanName"]);
                model.strBorrowVerifyTypeName = ObjectConvertClass.static_ext_string(dr["strBorrowLoginTypeName"]);
                model.strGiveBackVerifyTypeName = ObjectConvertClass.static_ext_string(dr["strGiveBackLoginTypeName"]);
                model.strLendingTypeName = ObjectConvertClass.static_ext_string(dr["strLendingTypeName"]);
                model.strLendingTypeAlias = ObjectConvertClass.static_ext_string(dr["strAlias"]);
                model.strStateName = ObjectConvertClass.static_ext_string(dr["strStateName"]);
                model.nKeepMunites = ObjectConvertClass.static_ext_int(dr["nMinutes"]);
                model.strWorkShopGUID = ObjectConvertClass.static_ext_string(dr["strWorkShopGUID"]);
            }
            return model;
        }
        #endregion

        #region QueryDetails方法（1.5.7查询发放明细）
        public List<LendingInfoDetail> QueryDetails(GoodsDetailQueryParam queryParam)
        {
            string strSqlWhere = " select * from View_LendingInfoDetail where 1=1 and strWorkShopGUID = '" + queryParam.workShopGUID + "' ";
            if (queryParam.nReturnState != -1)
            {
                strSqlWhere += " and nReturnState =" + queryParam.nReturnState + "";
            }
            if (queryParam.nLendingType != -1)
            {
                strSqlWhere += " and nLendingType =" + queryParam.nLendingType + "";
            }
            if (queryParam.strTrainmanNumber != null && queryParam.strTrainmanNumber != "")
            {
                strSqlWhere += " and strBorrowTrainmanNumber =" + queryParam.strTrainmanNumber + "";
            }
            if (queryParam.strTrainmanName != null && queryParam.strTrainmanName != "")
            {
                strSqlWhere += " and strBorrowTrainmanName =" + queryParam.strTrainmanName + "";
            }
            if (queryParam.nBianHao != -1)
            {
                strSqlWhere += " and strLendingExInfo =" + queryParam.nBianHao + "";
            }
            if ((queryParam.strOrderField == null) || (queryParam.strOrderField == ""))
            {
                strSqlWhere += " order by dtBorrowTime Desc ";
            }
            else
            {
                strSqlWhere += " order by " + queryParam.strOrderField + " Desc";
            }
            return QueryDetails_DTToList(SqlHelper.ExecuteDataset(ConnectionString, CommandType.Text, strSqlWhere.ToString()).Tables[0]);
        }
        public List<LendingInfoDetail> QueryDetails_DTToList(DataTable dt)
        {
            List<LendingInfoDetail> modelList = new List<LendingInfoDetail>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                LendingInfoDetail model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = QueryDetails_DRToModelDTToList(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }
        public LendingInfoDetail QueryDetails_DRToModelDTToList(DataRow dr)
        {
            LendingInfoDetail model = new LendingInfoDetail();
            if (dr != null)
            {
                model.strLendingInfoGUID = ObjectConvertClass.static_ext_string(dr["strLendingInfoGUID"]);
                model.nLendingType = ObjectConvertClass.static_ext_int(dr["nLendingType"]);
                model.strLendingExInfo = ObjectConvertClass.static_ext_int(dr["strLendingExInfo"]);
                model.nReturnState = ObjectConvertClass.static_ext_int(dr["nReturnState"]);
                model.dtModifyTime = ObjectConvertClass.static_ext_date(dr["dtModifyTime"]);
                model.strGUID = ObjectConvertClass.static_ext_string(dr["strGUID"]);
                model.nID = ObjectConvertClass.static_ext_int(dr["nID"]);
                model.dtBorrwoTime = ObjectConvertClass.static_ext_date(dr["dtBorrowTime"]);
                model.dtGiveBackTime = ObjectConvertClass.static_ext_date(dr["dtGiveBackTime"]);
                model.nBorrowVerifyType = ObjectConvertClass.static_ext_int(dr["nBorrowLoginType"]);
                model.nGiveBackVerifyType = ObjectConvertClass.static_ext_int(dr["nGiveBackLoginType"]);
                model.strLenderGUID = ObjectConvertClass.static_ext_string(dr["strLenderGUID"]);
                model.strTrainmanGUID = ObjectConvertClass.static_ext_string(dr["strBorrowTrainmanGUID"]);
                model.strGiveBackTrainmanGUID = ObjectConvertClass.static_ext_string(dr["strGiveBackTrainmanGUID"]);
                model.strTrainmanNumber = ObjectConvertClass.static_ext_string(dr["strBorrowTrainmanNumber"]);
                model.strTrainmanName = ObjectConvertClass.static_ext_string(dr["strBorrowTrainmanName"]);
                model.strLenderNumber = ObjectConvertClass.static_ext_string(dr["strLenderNumber"]);
                model.strLenderName = ObjectConvertClass.static_ext_string(dr["strLenderName"]);
                model.strGiveBackTrainmanNumber = ObjectConvertClass.static_ext_string(dr["strGiveBackTrainmanNumber"]);
                model.strGiveBackTrainmanName = ObjectConvertClass.static_ext_string(dr["strGiveBackTrainmanName"]);
                model.strBorrowVerifyTypeName = ObjectConvertClass.static_ext_string(dr["strBorrowLoginTypeName"]);
                model.strGiveBackVerifyTypeName = ObjectConvertClass.static_ext_string(dr["strGiveBackLoginTypeName"]);
                model.strLendingTypeName = ObjectConvertClass.static_ext_string(dr["strLendingTypeName"]);
                model.strLendingTypeAlias = ObjectConvertClass.static_ext_string(dr["strAlias"]);
                model.strStateName = ObjectConvertClass.static_ext_string(dr["strStateName"]);
                model.nKeepMunites = ObjectConvertClass.static_ext_int(dr["nMinutes"]);
                model.strWorkShopGUID = ObjectConvertClass.static_ext_string(dr["strWorkShopGUID"]);
            }
            return model;
        }
        #endregion

        #region GetTrainmanNotReturnLendingInfo方法（1.5.10获得指定人员未归还物品列表）
        public List<LendingInfoDetail> GetTrainmanNotReturnLendingInfo(string TrainmanGUID,int state)
        {
            string strSqlWhere = "select strGUID from View_LendingInfo where strBorrowTrainmanGUID = '" + TrainmanGUID + "'  and nReturnState = "+state;
            DataTable dt = SqlHelper.ExecuteDataset(ConnectionString, CommandType.Text, strSqlWhere.ToString()).Tables[0];
            if (dt.Rows.Count > 0)
            {
                string strGUID = dt.Rows[0]["strGUID"].ToString();
                string strSql = "select * from View_LendingInfoDetail where strLendingInfoGUID = '" + strGUID + "'";
                return GetTrainmanNotReturnLendingInfo_DTToList(SqlHelper.ExecuteDataset(ConnectionString, CommandType.Text, strSql.ToString()).Tables[0]);
            }
            else
            {
                return new List<LendingInfoDetail>();
            }

        }
        public List<LendingInfoDetail> GetTrainmanNotReturnLendingInfo_DTToList(DataTable dt)
        {
            List<LendingInfoDetail> modelList = new List<LendingInfoDetail>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                LendingInfoDetail model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = GetTrainmanNotReturnLendingInfo_DRToModelDTToList(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }
        public LendingInfoDetail GetTrainmanNotReturnLendingInfo_DRToModelDTToList(DataRow dr)
        {
            LendingInfoDetail model = new LendingInfoDetail();
            if (dr != null)
            {
                model.strLendingInfoGUID = ObjectConvertClass.static_ext_string(dr["strLendingInfoGUID"]);
                model.nLendingType = ObjectConvertClass.static_ext_int(dr["nLendingType"]);
                model.strLendingExInfo = ObjectConvertClass.static_ext_int(dr["strLendingExInfo"]);
                model.nReturnState = ObjectConvertClass.static_ext_int(dr["nReturnState"]);
                model.dtModifyTime = ObjectConvertClass.static_ext_date(dr["dtModifyTime"]);
                model.strGUID = ObjectConvertClass.static_ext_string(dr["strGUID"]);
                model.nID = ObjectConvertClass.static_ext_int(dr["nID"]);
                model.dtBorrwoTime = ObjectConvertClass.static_ext_date(dr["dtBorrowTime"]);
                model.dtGiveBackTime = ObjectConvertClass.static_ext_date(dr["dtGiveBackTime"]);
                model.nBorrowVerifyType = ObjectConvertClass.static_ext_int(dr["nBorrowLoginType"]);
                model.nGiveBackVerifyType = ObjectConvertClass.static_ext_int(dr["nGiveBackLoginType"]);
                model.strLenderGUID = ObjectConvertClass.static_ext_string(dr["strLenderGUID"]);
                model.strTrainmanGUID = ObjectConvertClass.static_ext_string(dr["strBorrowTrainmanGUID"]);
                model.strGiveBackTrainmanGUID = ObjectConvertClass.static_ext_string(dr["strGiveBackTrainmanGUID"]);
                model.strTrainmanNumber = ObjectConvertClass.static_ext_string(dr["strBorrowTrainmanNumber"]);
                model.strTrainmanName = ObjectConvertClass.static_ext_string(dr["strBorrowTrainmanName"]);
                model.strLenderNumber = ObjectConvertClass.static_ext_string(dr["strLenderNumber"]);
                model.strLenderName = ObjectConvertClass.static_ext_string(dr["strLenderName"]);
                model.strGiveBackTrainmanNumber = ObjectConvertClass.static_ext_string(dr["strGiveBackTrainmanNumber"]);
                model.strGiveBackTrainmanName = ObjectConvertClass.static_ext_string(dr["strGiveBackTrainmanName"]);
                model.strBorrowVerifyTypeName = ObjectConvertClass.static_ext_string(dr["strBorrowLoginTypeName"]);
                model.strGiveBackVerifyTypeName = ObjectConvertClass.static_ext_string(dr["strGiveBackLoginTypeName"]);
                model.strLendingTypeName = ObjectConvertClass.static_ext_string(dr["strLendingTypeName"]);
                model.strLendingTypeAlias = ObjectConvertClass.static_ext_string(dr["strAlias"]);
                model.strStateName = ObjectConvertClass.static_ext_string(dr["strStateName"]);
                model.nKeepMunites = ObjectConvertClass.static_ext_int(dr["nMinutes"]);
                model.strWorkShopGUID = ObjectConvertClass.static_ext_string(dr["strWorkShopGUID"]);
            }
            return model;
        }
        #endregion
    }
}
