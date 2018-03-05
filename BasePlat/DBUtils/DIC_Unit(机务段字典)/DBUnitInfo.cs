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
	//����: UnitInfoQueryCondition
	//˵��: �������Ϣ��ѯ������
	/// <summary>
	public class UnitInfoQueryCondition
	{
		public int page = 0;
		public int rows = 0;
		//
		public int? nID = null;
		//
		public string strID = "";
		//�κ�
        public string UnitNumber = "";
		//���������
        public string UnitName = "";
		public void OutPut(out StringBuilder SqlCondition, out SqlParameter[] Params)
		{
			SqlCondition = new StringBuilder();
			SqlCondition.Append(nID != null ? " and nID = @nID" : "");
			SqlCondition.Append(strID != "" ? " and strID = @strID" : "");
			SqlCondition.Append(UnitNumber != "" ? " and UnitNumber = @UnitNumber" : "");
			SqlCondition.Append(UnitName != "" ? " and UnitName = @UnitName" : "");
			SqlParameter[] sqlParams ={
					new SqlParameter("nID",nID),
					new SqlParameter("strID",strID),
					new SqlParameter("UnitNumber",UnitNumber),
					new SqlParameter("UnitName",UnitName)};
			Params = sqlParams;
		}
	}
	/// <summary>
	//����: DBUnitInfo
	//˵��: �������Ϣ���ݲ�����
	/// <summary>
	public class DBDic_UnitInfo : DBOperator
	{
		public DBDic_UnitInfo(string ConnectionString) : base(ConnectionString) { }
		#region ��ɾ��
		/// <summary>
		/// �������
		/// <summary>
		public bool Add(Dic_UnitInfo model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("insert into TAB_Dic_UnitInfo");
			strSql.Append("(UnitNumber,UnitName)");
			strSql.Append("values(@UnitNumber,@UnitName)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@UnitNumber", model.UnitNumber),
					new SqlParameter("@UnitName", model.UnitName)};

			return SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, strSql.ToString(), parameters) > 0;
		}
		/// <summary>
		/// ��������
		/// <summary>
		public bool Update(Dic_UnitInfo model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("Update TAB_Dic_UnitInfo set ");
			strSql.Append(" UnitNumber = @UnitNumber, ");
			strSql.Append(" UnitName = @UnitName ");
            strSql.Append(" where nID = @nID ");

			SqlParameter[] parameters = {
					new SqlParameter("@nID", model.nID),
					new SqlParameter("@UnitNumber", model.UnitNumber),
					new SqlParameter("@UnitName", model.UnitName)};

			return SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, strSql.ToString(), parameters) > 0;
		}
		/// <summary>
		/// ɾ������
		/// <summary>
		public bool Delete(String strID)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("delete from TAB_Dic_UnitInfo ");
			strSql.Append(" where nID = @strID ");
			SqlParameter[] parameters = {
					new SqlParameter("strID",strID)};

			return SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, strSql.ToString(), parameters) > 0;
		}
		#endregion
		/// <summary>
		/// ��������Ƿ����
		/// <summary>
		public bool Exists(Dic_UnitInfo model)
		{
			StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) from TAB_Dic_UnitInfo where UnitNumber=@UnitNumber");
            if (model.nID != 0)
            {
                strSql.Append(" and nID<>@nID");
            }
			 SqlParameter[] parameters = {
                                             new SqlParameter("nID",model.nID),
					 new SqlParameter("UnitNumber",model.UnitNumber)};

			return ObjectConvertClass.static_ext_int(SqlHelper.ExecuteScalar(ConnectionString, CommandType.Text, strSql.ToString(), parameters)) > 0;
		}
		/// <summary>
		/// �������DataTable
		/// <summary>
		public DataTable GetDataTable(UnitInfoQueryCondition QueryCondition)
		{
			SqlParameter[] sqlParams;
			StringBuilder strSqlOption = new StringBuilder();
			QueryCondition.OutPut(out strSqlOption, out sqlParams);
			StringBuilder strSql = new StringBuilder();
			if (QueryCondition.page == 0)
			{
				strSql.Append("select * ");
				strSql.Append(" FROM TAB_Dic_UnitInfo where 1=1 " + strSqlOption.ToString());
			}else
			{
				strSql.Append(@"select top "+QueryCondition.rows.ToString() + " * from TAB_Dic_UnitInfo where 1 = 1 "+
				strSqlOption.ToString() + " and nID not in ( select top " + (QueryCondition.page - 1) * QueryCondition.rows +
				" nID from TAB_Dic_UnitInfo where  1=1 " + strSqlOption.ToString() + " order by nID desc) order by nID desc");
			}
			return SqlHelper.ExecuteDataset(ConnectionString, CommandType.Text, strSql.ToString(), sqlParams).Tables[0];
		}
		/// <summary>
		/// �������List
		/// <summary>
		public List<Dic_UnitInfo> GetDataList(UnitInfoQueryCondition QueryCondition)
		{
			SqlParameter[] sqlParams;
			StringBuilder strSqlOption = new StringBuilder();
			QueryCondition.OutPut(out strSqlOption, out sqlParams);
			StringBuilder strSql = new StringBuilder();
			if (QueryCondition.page == 0)
			{
				strSql.Append("select * ");
				strSql.Append(" FROM TAB_Dic_UnitInfo where 1=1 " + strSqlOption.ToString());
			}else
			{
				strSql.Append(@"select top "+QueryCondition.rows.ToString() + " * from TAB_Dic_UnitInfo where 1 = 1 "+
				strSqlOption.ToString() + " and nID not in ( select top " + (QueryCondition.page - 1) * QueryCondition.rows +
				" nID from TAB_Dic_UnitInfo where  1=1 " + strSqlOption.ToString() + " order by nID desc) order by nID desc");
			}
			DataTable dt = SqlHelper.ExecuteDataset(ConnectionString, CommandType.Text, strSql.ToString(), sqlParams).Tables[0];
			List<Dic_UnitInfo> list = new List<Dic_UnitInfo>();
			foreach (DataRow dr in dt.Rows)
			{
				Dic_UnitInfo _UnitInfo = new Dic_UnitInfo();
				DataRowToModel(_UnitInfo,dr);
				list.Add(_UnitInfo);
			}
			return list;
		}
		/// <summary>
		/// ��ü�¼����
		/// <summary>
		public int GetDataCount(UnitInfoQueryCondition QueryCondition)
		{
			SqlParameter[] sqlParams;
			StringBuilder strSqlOption = new StringBuilder();
			QueryCondition.OutPut(out strSqlOption, out sqlParams);
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select count(*) ");
			strSql.Append(" FROM TAB_Dic_UnitInfo where 1=1" + strSqlOption.ToString());
			return ObjectConvertClass.static_ext_int(SqlHelper.ExecuteScalar(ConnectionString, CommandType.Text, strSql.ToString(), sqlParams));
		}
		/// <summary>
		/// ���һ��ʵ�����
		/// <summary>
		public Dic_UnitInfo GetModel(UnitInfoQueryCondition QueryCondition)
		{
			SqlParameter[] sqlParams;
			StringBuilder strSqlOption = new StringBuilder();
			QueryCondition.OutPut(out strSqlOption, out sqlParams);
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select top 1 * ");
			strSql.Append(" FROM TAB_Dic_UnitInfo where 1=1 " + strSqlOption.ToString());
			DataTable dt = SqlHelper.ExecuteDataset(ConnectionString, CommandType.Text, strSql.ToString(), sqlParams).Tables[0];
			Dic_UnitInfo _UnitInfo = null;
			if (dt.Rows.Count > 0)
			{
				_UnitInfo = new Dic_UnitInfo();
				DataRowToModel(_UnitInfo,dt.Rows[0]);
			}
			return _UnitInfo;
		}
		/// <summary>
		/// ��ȡDataRow���ݵ�Model��
		/// <summary>
		private void DataRowToModel(Dic_UnitInfo model,DataRow dr)
		{
            model.nID = ObjectConvertClass.static_ext_int(dr["nID"]);
			model.strID = ObjectConvertClass.static_ext_string(dr["strID"]);
			model.UnitNumber = ObjectConvertClass.static_ext_string(dr["UnitNumber"]);
			model.UnitName = ObjectConvertClass.static_ext_string(dr["UnitName"]);
		}
	}
}
