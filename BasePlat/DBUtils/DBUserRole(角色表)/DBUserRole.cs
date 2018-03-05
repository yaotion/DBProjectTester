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
	//类名: UserRoleQueryCondition
	//说明: 用户角色查询条件类
	/// <summary>
	public class UserRoleQueryCondition
	{
		public int page = 0;
		public int rows = 0;
		//
		public int? nID = null;
		//
		public string strName = "";
		public void OutPut(out StringBuilder SqlCondition, out SqlParameter[] Params)
		{
			SqlCondition = new StringBuilder();
			SqlCondition.Append(nID != null ? " and nID = @nID" : "");
			SqlCondition.Append(strName != "" ? " and strName = @strName" : "");
			SqlParameter[] sqlParams ={
					new SqlParameter("nID",nID),
					new SqlParameter("strName",strName)};
			Params = sqlParams;
		}
	}
	/// <summary>
	//类名: DBUserRole
	//说明: 用户角色数据操作类
	/// <summary>
	public class DBUserRole : DBOperator
	{
		public DBUserRole(string ConnectionString) : base(ConnectionString) { }
		#region 增删改
		/// <summary>
		/// 添加数据
		/// <summary>
		public bool Add(UserRole model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("insert into WebPlatForm_UserRole");
			strSql.Append("(strName)");
			strSql.Append("values(@strName)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@strName", model.strName)};

			return SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, strSql.ToString(), parameters) > 0;
		}
		/// <summary>
		/// 更新数据
		/// <summary>
		public bool Update(UserRole model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("Update WebPlatForm_UserRole set ");
			strSql.Append(" strName = @strName ");
            strSql.Append(" where nID = @nID ");

			SqlParameter[] parameters = {
					new SqlParameter("@nID", model.nID),
					new SqlParameter("@strName", model.strName)};

			return SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, strSql.ToString(), parameters) > 0;
		}
		/// <summary>
		/// 删除数据
		/// <summary>
		public bool Delete(string strID)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("delete from WebPlatForm_UserRole ");
            strSql.Append(" where nID = @nID ");
			SqlParameter[] parameters = {
					new SqlParameter("nID",strID)};

			return SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, strSql.ToString(), parameters) > 0;
		}
		#endregion
		/// <summary>
		/// 检查数据是否存在
		/// <summary>
		public bool Exists(UserRole _UserRole)
		{
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) from WebPlatForm_UserRole where strName=@strName");
            strSql.Append(_UserRole.nID != 0 ? " and nID<>@nID" : "");
            SqlParameter[] parameters = {
					new SqlParameter("strName",_UserRole.strName),
                    new SqlParameter("nID",_UserRole.nID)
                                        };
            return Convert.ToInt32(SqlHelper.ExecuteScalar(ConnectionString, CommandType.Text, strSql.ToString(), parameters)) > 0;
		}
		/// <summary>
		/// 获得数据DataTable
		/// <summary>
		public DataTable GetDataTable(UserRoleQueryCondition QueryCondition)
		{
			SqlParameter[] sqlParams;
			StringBuilder strSqlOption = new StringBuilder();
			QueryCondition.OutPut(out strSqlOption, out sqlParams);
			StringBuilder strSql = new StringBuilder();
			if (QueryCondition.page == 0)
			{
				strSql.Append("select * ");
				strSql.Append(" FROM WebPlatForm_UserRole where 1=1 " + strSqlOption.ToString());
			}else
			{
				strSql.Append(@"select top "+QueryCondition.rows.ToString() + " * from WebPlatForm_UserRole where 1 = 1 "+
				strSqlOption.ToString() + " and nID not in ( select top " + (QueryCondition.page - 1) * QueryCondition.rows +
				" nID from WebPlatForm_UserRole where  1=1 " + strSqlOption.ToString() + " order by nID desc) order by nID desc");
			}
			return SqlHelper.ExecuteDataset(ConnectionString, CommandType.Text, strSql.ToString(), sqlParams).Tables[0];
		}
		/// <summary>
		/// 获得数据List
		/// <summary>
		public List<UserRole> GetDataList(UserRoleQueryCondition QueryCondition)
		{
			SqlParameter[] sqlParams;
			StringBuilder strSqlOption = new StringBuilder();
			QueryCondition.OutPut(out strSqlOption, out sqlParams);
			StringBuilder strSql = new StringBuilder();
			if (QueryCondition.page == 0)
			{
				strSql.Append("select * ");
				strSql.Append(" FROM WebPlatForm_UserRole where 1=1 " + strSqlOption.ToString());
			}else
			{
				strSql.Append(@"select top "+QueryCondition.rows.ToString() + " * from WebPlatForm_UserRole where 1 = 1 "+
				strSqlOption.ToString() + " and nID not in ( select top " + (QueryCondition.page - 1) * QueryCondition.rows +
				" nID from WebPlatForm_UserRole where  1=1 " + strSqlOption.ToString() + " order by nID desc) order by nID desc");
			}
			DataTable dt = SqlHelper.ExecuteDataset(ConnectionString, CommandType.Text, strSql.ToString(), sqlParams).Tables[0];
			List<UserRole> list = new List<UserRole>();
			foreach (DataRow dr in dt.Rows)
			{
				UserRole _UserRole = new UserRole();
				DataRowToModel(_UserRole,dr);
				list.Add(_UserRole);
			}
			return list;
		}
		/// <summary>
		/// 获得记录总数
		/// <summary>
		public int GetDataCount(UserRoleQueryCondition QueryCondition)
		{
			SqlParameter[] sqlParams;
			StringBuilder strSqlOption = new StringBuilder();
			QueryCondition.OutPut(out strSqlOption, out sqlParams);
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select count(*) ");
			strSql.Append(" FROM WebPlatForm_UserRole where 1=1" + strSqlOption.ToString());
			return ObjectConvertClass.static_ext_int(SqlHelper.ExecuteScalar(ConnectionString, CommandType.Text, strSql.ToString(), sqlParams));
		}
		/// <summary>
		/// 获得一个实体对象
		/// <summary>
		public UserRole GetModel(UserRoleQueryCondition QueryCondition)
		{
			SqlParameter[] sqlParams;
			StringBuilder strSqlOption = new StringBuilder();
			QueryCondition.OutPut(out strSqlOption, out sqlParams);
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select top 1 * ");
			strSql.Append(" FROM WebPlatForm_UserRole where 1=1 " + strSqlOption.ToString());
			DataTable dt = SqlHelper.ExecuteDataset(ConnectionString, CommandType.Text, strSql.ToString(), sqlParams).Tables[0];
			UserRole _UserRole = null;
			if (dt.Rows.Count > 0)
			{
				_UserRole = new UserRole();
				DataRowToModel(_UserRole,dt.Rows[0]);
			}
			return _UserRole;
		}
		/// <summary>
		/// 读取DataRow数据到Model中
		/// <summary>
		private void DataRowToModel(UserRole model,DataRow dr)
		{
			model.nID = ObjectConvertClass.static_ext_int(dr["nID"]);
			model.strName = ObjectConvertClass.static_ext_string(dr["strName"]);
		}
	}
}
