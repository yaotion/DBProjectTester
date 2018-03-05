using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using ThinkFreely.DBUtility;
using System.Data;
using System.Web;
using TF.CommonUtility;

namespace TF.WebPlatForm.DBUtils
{
    /// <summary>
    ///Module 的摘要说明
    /// </summary>
    public class Module:DBOperator
    {
        public Module(string ConnectionString)
            : base(ConnectionString)
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        public DataTable GetModuleRole(int nRoleID, int nParentID)
        {
            DataTable dt = new DataTable();
            StringBuilder strSqlOption = new StringBuilder();
            strSqlOption.Append(nParentID!=0?" and nParentID=@nParentID":"");
            strSqlOption.Append(nRoleID != 0 ? " and nRoleID=@nRoleID" : "");
            strSqlOption.Append(" and nEnable=1");
            string strSql = "select distinct nID,nModuleID,strURL,strUrlDescription,nParentID,nRoleID,strName,strParentURLDescription,strGrandUrlDescription,nsortid,_blank,strIconCss from VIEW_WebPlatForm_Role where 1=1" + strSqlOption.ToString() + " order by nsortid";
            SqlParameter[] sqlParams = {
                                           new SqlParameter("@nRoleID",nRoleID),
                                           new SqlParameter("@nParentID",nParentID)
                                       };
            dt = SqlHelper.ExecuteDataset(ConnectionString, CommandType.Text, strSql, sqlParams).Tables[0];
            return dt;
        }
        /// <summary>
        /// 获取角色权限
        /// </summary>
        /// <param name="nRoleID"></param>
        /// <param name="nParentID"></param>
        /// <returns></returns>
        public DataTable GetModuleRole(int nRoleID)
        {
            DataTable dt = new DataTable();
            StringBuilder strSqlOption = new StringBuilder();
            strSqlOption.Append(nRoleID != 0 ? " and (nRoleID=@nRoleID or nModuleID=2)" : "");
            strSqlOption.Append(" and nEnable=1");
            string strSql = "select distinct nID,nModuleID,strURL,strUrlDescription,nParentID,nRoleID,strName,strParentURLDescription,strGrandUrlDescription,nsortid,_blank,strIconCss from VIEW_WebPlatForm_Role where 1=1" + strSqlOption.ToString() + " order by nsortid";
            SqlParameter[] sqlParams = {
                                           new SqlParameter("@nRoleID",nRoleID)
                                       };
            dt = SqlHelper.ExecuteDataset(ConnectionString, CommandType.Text, strSql, sqlParams).Tables[0];
            return dt;
        }
        /// <summary>
        /// 获取登录后转向页面
        /// </summary>
        /// <returns></returns>
        public string GetLoginReturnUrl(string strRoleID)
        {
            string strSql = string.Format("select top 1 strURL from VIEW_WebPlatForm_Role where nRoleID={0} and strURL <>'' order by nsortid desc",
                strRoleID);
            return TF.CommonUtility.ObjectConvertClass.static_ext_string(SqlHelper.ExecuteScalar(ConnectionString, CommandType.Text, strSql));
        }
    }
}
