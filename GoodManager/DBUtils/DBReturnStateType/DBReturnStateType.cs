using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoodManager.Entry.GoodStatus_物品状态类型_;
using ThinkFreely.DBUtility;
using System.Data;
using CommonUtility.json解析;
using TF.WebPlatForm.DBUtils;
namespace GoodManager.DBUtils
{
  public  class DBReturnStateType  : DBOperator
    {
        public DBReturnStateType(string ConnectionString) : base(ConnectionString) { }
 
        #region GetStateNames方法（1.5.2获取物品状态类型）
        public List<ReturnStateType> GetStateNames()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select * from TAB_System_ReturnStateType ");
            return GetStateNames_DTToList(SqlHelper.ExecuteDataset(ConnectionString, CommandType.Text, strSql.ToString()).Tables[0]);
        }
        public List<ReturnStateType> GetStateNames_DTToList(DataTable dt)
        {
            List<ReturnStateType> modelList = new List<ReturnStateType>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                ReturnStateType model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = GetStateNames_DRToModelDTToList(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }
        public ReturnStateType GetStateNames_DRToModelDTToList(DataRow dr)
        {
            ReturnStateType model = new ReturnStateType();
            if (dr != null)
            {
                model.nid = ObjectConvertClass.static_ext_int(dr["nid"]);
                model.nReturnStateID = ObjectConvertClass.static_ext_int(dr["nReturnStateID"]);
                model.strStateName = ObjectConvertClass.static_ext_string(dr["strStateName"]);
            }
            return model;
        }
        #endregion

    }
}
