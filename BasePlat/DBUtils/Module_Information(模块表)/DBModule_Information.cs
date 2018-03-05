using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml.Linq;
using System.Data.SqlClient;
using ThinkFreely.DBUtility;
using TF.CommonUtility;
using System.Collections.Generic;
using TF.WebPlatForm.Entry;

namespace TF.WebPlatForm.DBUtils
{
	/// <summary>
	///类名: Module_InformationQueryCondition
	///说明: URL地址查询条件类
	/// </summary>
	public class Module_InformationQueryCondition
	{
		public int page = 0;
		public int rows = 0;
		//
		public int nID = 0;
		//URL地址
		public string strURL = "";
		//URL描述
		public string strUrlDescription = "";
		//上级ID
		public int nParentID = 0;
		//
		public int nsortid = 0;
		//
		public int _blank = 0;
		//图标样式
		public string strIconCss = "";

        public string sort = "";
        public string order = "";
		public void OutPut(out StringBuilder SqlCondition, out SqlParameter[] Params)
		{
			SqlCondition = new StringBuilder();
			SqlCondition.Append(nID != 0 ? " and nID = @nID" : "");
			SqlCondition.Append(strURL != "" ? " and strURL = @strURL" : "");
			SqlCondition.Append(strUrlDescription != "" ? " and strUrlDescription = @strUrlDescription" : "");
			SqlCondition.Append(nParentID != 0 ? " and nParentID = @nParentID" : "");
			SqlCondition.Append(nsortid != 0 ? " and nsortid = @nsortid" : "");
			SqlCondition.Append(_blank != 0 ? " and _blank = @_blank" : "");
			SqlCondition.Append(strIconCss != "" ? " and strIconCss = @strIconCss" : "");
			SqlParameter[] sqlParams ={
					new SqlParameter("nID",nID),
					new SqlParameter("strURL",strURL),
					new SqlParameter("strUrlDescription",strUrlDescription),
					new SqlParameter("nParentID",nParentID),
					new SqlParameter("nsortid",nsortid),
					new SqlParameter("_blank",_blank),
					new SqlParameter("strIconCss",strIconCss)};
			Params = sqlParams;
		}
	}
	/// <summary>
	///类名: DBModule_Information
	///说明: URL地址数据操作类
	/// </summary>
	public class DBModule_Information : DBOperator
	{
		public DBModule_Information(string ConnectionString) : base(ConnectionString) { }
		#region 增删改
		/// <summary>
		/// 添加数据
		/// </summary>
		public bool Add(Module_Information model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("insert into WebPlatForm_Module_Information");
			strSql.Append("(nID,strURL,strUrlDescription,nParentID,nsortid,_blank,strIconCss,nEnable)");
			strSql.Append("values(@nID,@strURL,@strUrlDescription,@nParentID,@nsortid,@_blank,@strIconCss,@nEnable)");
			SqlParameter[] parameters = {
					new SqlParameter("@nID", model.nID),
					new SqlParameter("@strURL", model.strURL),
					new SqlParameter("@strUrlDescription", model.strUrlDescription),
					new SqlParameter("@nParentID", model.nParentID),
					new SqlParameter("@nsortid", model.nsortid),
					new SqlParameter("@_blank", model._blank),
					new SqlParameter("@strIconCss", model.strIconCss),
					new SqlParameter("@nEnable", model.nEnable)};

			return SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, strSql.ToString(), parameters) >0;
		}
		/// <summary>
		/// 更新数据
		/// </summary>
		public bool Update(Module_Information model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("Update WebPlatForm_Module_Information set ");
			strSql.Append(" strURL = @strURL, ");
			strSql.Append(" strUrlDescription = @strUrlDescription, ");
			strSql.Append(" nsortid = @nsortid, ");
			strSql.Append(" _blank = @_blank, ");
			strSql.Append(" strIconCss = @strIconCss,");
            strSql.Append(" nParentID = @nParentID,");
            strSql.Append(" nEnable = @nEnable ");
            strSql.Append(" where nID = @nID ");

			SqlParameter[] parameters = {
					new SqlParameter("@nID", model.nID),
					new SqlParameter("@strURL", model.strURL),
					new SqlParameter("@strUrlDescription", model.strUrlDescription),
					new SqlParameter("@nsortid", model.nsortid),
					new SqlParameter("@_blank", model._blank),
                    new SqlParameter("@nParentID", model.nParentID),
					new SqlParameter("@strIconCss", model.strIconCss),
					new SqlParameter("@nEnable", model.nEnable)};

			return SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, strSql.ToString(), parameters) > 0;
		}
        /// <summary>
        /// 更新模块名称
        /// </summary>
        public bool UpdateUrlDescription(Module_Information model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Update WebPlatForm_Module_Information set ");
            strSql.Append(" strUrlDescription = @strUrlDescription, ");
            strSql.Append(" nEnable = @nEnable ");
            strSql.Append(" where nID = @nID ");

            SqlParameter[] parameters = {
					new SqlParameter("@nID", model.nID),
					new SqlParameter("@strUrlDescription", model.strUrlDescription),
					new SqlParameter("@nEnable", model.nEnable)};
            return SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, strSql.ToString(), parameters) > 0;
        }
        /// <summary>
        /// 更新启用状态
        /// </summary>
        public bool UpdateEnable(Module_Information model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Update WebPlatForm_Module_Information set ");
            strSql.Append(" nEnable = @nEnable ");
            strSql.Append(" where nID = @nID ");

            SqlParameter[] parameters = {
					new SqlParameter("@nID", model.nID),
					new SqlParameter("@nEnable", model.nEnable)};
            return SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, strSql.ToString(), parameters) > 0;
        }
		/// <summary>
		/// 删除数据
		/// </summary>
		public bool Delete(string strID)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("delete from WebPlatForm_Module_Information ");
            if (strID != "")
            {
                strSql.Append(" where nID = @nID ");
            }
			SqlParameter[] parameters = {
					new SqlParameter("nID",strID)};

			return SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, strSql.ToString(), parameters) > 0;
		}
		#endregion
		/// <summary>
		/// 检查数据是否存在
		/// </summary>
		public bool Exists(Module_Information _Module_Information)
		{
			StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) from WebPlatForm_Module_Information where nID=@nID");
			 SqlParameter[] parameters = {
					 new SqlParameter("nID",_Module_Information.nID)};

			return Convert.ToInt32(SqlHelper.ExecuteScalar(ConnectionString, CommandType.Text, strSql.ToString(), parameters)) > 0;
		}

        /// <summary>
        /// 检查数据是否存在
        /// </summary>
        public DataTable MaxID(int nParentID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select max(nsortid) as maxsortid,(select max(nID) from WebPlatForm_Module_Information)as maxnid from WebPlatForm_Module_Information where nParentID=@nParentID");
            SqlParameter[] parameters = {
					 new SqlParameter("nParentID",nParentID)};
            return SqlHelper.ExecuteDataset(ConnectionString, CommandType.Text, strSql.ToString(), parameters).Tables[0];
        }

		/// <summary>
		/// 获得数据DataTable
		/// </summary>
		public DataTable GetDataTable(Module_InformationQueryCondition QueryCondition)
		{
			SqlParameter[] sqlParams;
			StringBuilder strSqlOption = new StringBuilder();
			QueryCondition.OutPut(out strSqlOption, out sqlParams);
			StringBuilder strSql = new StringBuilder();
			if (QueryCondition.page == 0)
			{
				strSql.Append("select * ");
				strSql.Append(" FROM WebPlatForm_Module_Information where 1=1 " + strSqlOption.ToString());
                strSql.Append(" order by ");
                strSql.Append(QueryCondition.sort == "" ? " nID" : QueryCondition.sort);
                strSql.Append(QueryCondition.order == "" ? " desc" : " " + QueryCondition.order);
			}else
			{
				strSql.Append(@"select top "+QueryCondition.rows.ToString() + " * from WebPlatForm_Module_Information where 1 = 1 "+
				strSqlOption.ToString() + " and nID not in ( select top " + (QueryCondition.page - 1) * QueryCondition.rows +
				" nID from WebPlatForm_Module_Information where  1=1 " + strSqlOption.ToString());
                strSql.Append(" order by ");
                strSql.Append(QueryCondition.sort == "" ? " nID" : QueryCondition.sort);
                strSql.Append(QueryCondition.order == "" ? " desc" : " " + QueryCondition.order);
                strSql.Append(") order by ");
                strSql.Append(QueryCondition.sort == "" ? " nID" : QueryCondition.sort);
                strSql.Append(QueryCondition.order == "" ? " desc" : " " + QueryCondition.order);
			}
			return SqlHelper.ExecuteDataset(ConnectionString, CommandType.Text, strSql.ToString(), sqlParams).Tables[0];
		}
		/// <summary>
		/// 获得数据List
		/// </summary>
		public Module_InformationList GetDataList(Module_InformationQueryCondition QueryCondition)
		{
			SqlParameter[] sqlParams;
			StringBuilder strSqlOption = new StringBuilder();
			QueryCondition.OutPut(out strSqlOption, out sqlParams);
			StringBuilder strSql = new StringBuilder();
			if (QueryCondition.page == 0)
			{
				strSql.Append("select * ");
				strSql.Append(" FROM WebPlatForm_Module_Information where 1=1 " + strSqlOption.ToString());
                strSql.Append(QueryCondition.sort == "" ? " nID" : QueryCondition.sort);
                strSql.Append(QueryCondition.order == "" ? " desc" : " " + QueryCondition.order);
			}else
			{
				strSql.Append(@"select top "+QueryCondition.rows.ToString() + " * from WebPlatForm_Module_Information where 1 = 1 "+
				strSqlOption.ToString() + " and nID not in ( select top " + (QueryCondition.page - 1) * QueryCondition.rows +
				" nID from WebPlatForm_Module_Information where  1=1 " + strSqlOption.ToString());
                strSql.Append(" order by ");
                strSql.Append(QueryCondition.sort == "" ? " nID" : QueryCondition.sort);
                strSql.Append(QueryCondition.order == "" ? " desc" : " " + QueryCondition.order);
                strSql.Append(") order by ");
                strSql.Append(QueryCondition.sort == "" ? " nID" : QueryCondition.sort);
                strSql.Append(QueryCondition.order == "" ? " desc" : " " + QueryCondition.order);
			}
			DataTable dt = SqlHelper.ExecuteDataset(ConnectionString, CommandType.Text, strSql.ToString(), sqlParams).Tables[0];
			Module_InformationList list = new Module_InformationList();
			foreach (DataRow dr in dt.Rows)
			{
				Module_Information _Module_Information = new Module_Information();
				DataRowToModel(_Module_Information,dr);
				list.Add(_Module_Information);
			}
			return list;
		}
		/// <summary>
		/// 获得记录总数
		/// </summary>
		public int GetDataCount(Module_InformationQueryCondition QueryCondition)
		{
			SqlParameter[] sqlParams;
			StringBuilder strSqlOption = new StringBuilder();
			QueryCondition.OutPut(out strSqlOption, out sqlParams);
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select count(*) ");
			strSql.Append(" FROM WebPlatForm_Module_Information where 1=1" + strSqlOption.ToString());
			return ObjectConvertClass.static_ext_int(SqlHelper.ExecuteScalar(ConnectionString, CommandType.Text, strSql.ToString(), sqlParams));
		}
		/// <summary>
		/// 获得一个实体对象
		/// </summary>
		public Module_Information GetModel(Module_InformationQueryCondition QueryCondition)
		{
			SqlParameter[] sqlParams;
			StringBuilder strSqlOption = new StringBuilder();
			QueryCondition.OutPut(out strSqlOption, out sqlParams);
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select top 1 * ");
			strSql.Append(" FROM WebPlatForm_Module_Information where 1=1 " + strSqlOption.ToString());
			DataTable dt = SqlHelper.ExecuteDataset(ConnectionString, CommandType.Text, strSql.ToString(), sqlParams).Tables[0];
			Module_Information _Module_Information = null;
			if (dt.Rows.Count > 0)
			{
				_Module_Information = new Module_Information();
				DataRowToModel(_Module_Information,dt.Rows[0]);
			}
			return _Module_Information;
		}
		/// <summary>
		/// 读取DataRow数据到Model中
		/// </summary>
		private void DataRowToModel(Module_Information model,DataRow dr)
		{
			model.nID = ObjectConvertClass.static_ext_int(dr["nID"]);
			model.strURL = ObjectConvertClass.static_ext_string(dr["strURL"]);
			model.strUrlDescription = ObjectConvertClass.static_ext_string(dr["strUrlDescription"]);
			model.nParentID = ObjectConvertClass.static_ext_int(dr["nParentID"]);
			model.nsortid = ObjectConvertClass.static_ext_int(dr["nsortid"]);
			model._blank = ObjectConvertClass.static_ext_int(dr["_blank"]);
			model.strIconCss = ObjectConvertClass.static_ext_string(dr["strIconCss"]);
            model.nEnable = ObjectConvertClass.static_ext_int(dr["nEnable"]);
		}
	}
}
