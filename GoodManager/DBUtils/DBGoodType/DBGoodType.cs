using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ThinkFreely.DBUtility;
using CommonUtility.json解析;
using TF.WebPlatForm.DBUtils;
using GoodManager.Entry.LendingType_物品类型_;

namespace GoodManager.DBUtils
{
    public class DBGoodType : DBOperator
    {
        
        public DBGoodType(string ConnectionString) : base(ConnectionString) { }
        #region GetGoodType方法（1.5.1获取物品类型）
        public List<LendingType> GetGoodType()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select * from TAB_System_LendingType ");
            return GetGoodType_DTToList(SqlHelper.ExecuteDataset(ConnectionString, CommandType.Text, strSql.ToString()).Tables[0]);
        }
        public List<LendingType> GetGoodType_DTToList(DataTable dt)
        {
            List<LendingType> modelList = new List<LendingType>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                LendingType model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = GetGoodType_DRToModelDTToList(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }
        public LendingType GetGoodType_DRToModelDTToList(DataRow dr)
        {
            LendingType model = new LendingType();
            if (dr != null)
            {
                model.nID = ObjectConvertClass.static_ext_int(dr["nID"]);
                model.nLendingTypeID = ObjectConvertClass.static_ext_int(dr["nLendingTypeID"]);
                model.strLendingTypeName = ObjectConvertClass.static_ext_string(dr["strLendingTypeName"]);
                model.strAlias = ObjectConvertClass.static_ext_string(dr["strAlias"]);
            }
            return model;
        }
        #endregion
    }
}
