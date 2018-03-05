using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using ThinkFreely.DBUtility;
using System.Data;
using TF.WebPlatForm.Logic;
namespace TF.WebPlatForm.DBUtils
{
    /// <summary>
    ///RoleInformation 角色类
    /// </summary>
    public class RoleInformation
    {
        public RoleInformation()
        {

        }
        public DataTable GetRoleInfor()
        {
            string strSql = "select * from TAB_Module_Role";
            return SqlHelper.ExecuteDataset(ConData.WebSiteConnectionString, CommandType.Text, strSql).Tables[0];
        }
        public int Add(string strRoleName)
        {
            string strSql = "insert into TAB_Module_Role(strRoleName) values (@RoleName);";

            int nRows = 0;
            SqlConnection conn = new SqlConnection(ConData.WebSiteConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            conn.Open();
            cmd.Parameters.AddWithValue("RoleName", strRoleName);
            cmd.CommandText = strSql;
            nRows = cmd.ExecuteNonQuery();
            if (nRows == 0)
            {
                conn.Close();
                return 0;
            }
            cmd.Parameters.Clear();
            cmd.CommandText = "select max(nid) from TAB_Module_Role;";
            string strRoleID = cmd.ExecuteScalar().ToString();
            if (string.IsNullOrEmpty(strRoleID))
            {
                return 0;
            }
            cmd.CommandText = "select * from WebPlatForm_Module_Information";
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            conn.Close();

            List<string> Sqls = new List<string>();
            foreach (DataRow row in dt.Rows)
            {
                string charRoleMark = "1111";
                string strParentID = row["nParentID"].ToString();
                 
               charRoleMark = "0000";//默认所有模块不可用(需要管理员予以分配)
                Sqls.Add(string.Format("insert into WebPlatForm_Module_Relation values ({0},{1},'{2}',0)"
                    , row["nID"].ToString(), strRoleID, charRoleMark));
            }
            nRows += SqlHelper.TransExe(Sqls);
            return nRows;
        }

        public string Delete(string strID)
        {
            string strSql = "select count(*) from TAB_System_DutyUser where nDeleteState=0 and nRoleID=" + strID;
            object obj = SqlHelper.ExecuteScalar(ConData.WebSiteConnectionString, CommandType.Text, strSql);
            int nResult = 0;
            if (obj.ToString() == "0")
            {
                strSql = "delete WebPlatForm_Module_Relation where nRoleID=" + strID;
                nResult = SqlHelper.ExecuteNonQuery(ConData.WebSiteConnectionString, CommandType.Text, strSql);
                strSql = "delete TAB_Module_Role where nID=" + strID;
                nResult += SqlHelper.ExecuteNonQuery(ConData.WebSiteConnectionString, CommandType.Text, strSql);
                return "";
            }
            else
            {
                return "该用户组中还含有" + obj.ToString() + "个用户,请先移除,然后再删除用户组";
            }

        }

        public int Update(string strID, string strRoleName)
        {
            string strSql = "update TAB_Module_Role set strRoleName=@RoleName where nID=@nID";
            SqlParameter[] SqlPs ={
                                     new SqlParameter("RoleName",strRoleName),
                                     new SqlParameter("nID",strID)
                                 };
            return SqlHelper.ExecuteNonQuery(ConData.WebSiteConnectionString, CommandType.Text, strSql, SqlPs);
        }

        public DataTable GetModuleRoleInfo(string RoleID)
        {

            string strSql = "select * from VIEW_WebPlatForm_Role where nRoleID=@RoleID and nParentID>1 and strURL is not null and strURL<>''";
            SqlParameter[] SqlParams ={
                                         new SqlParameter("RoleID",RoleID)
                                     };
            return SqlHelper.ExecuteDataset(ConData.WebSiteConnectionString, CommandType.Text, strSql, SqlParams).Tables[0];
        }
    }
}