using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Data.SqlClient;
using ThinkFreely.DBUtility;
using TF.CommonUtility;
using TF.WebPlatForm.Entry;
using System.Text;

namespace TF.WebPlatForm.DBUtils
{


    /// <summary>
    /// 类名:WebPlatForm_Module_Relation
    /// 描述:WebPlatForm_Module_Relation查询条件类
    /// </summary>	

    public class DBTAB_Module_RelationQuery
    {
        public int page = 0;
        public int rows = 0;
        public int nID = 0;
        public int nModuleID = 0;
        public int nRoleID = 0;
        public string charRoleMark = "";
        public int nTabIndex = 0;
        public void OutPut(out StringBuilder SqlCondition, out SqlParameter[] Params)
        {
            SqlCondition = new StringBuilder();
            SqlCondition.Append(nID != 0 ? " and nID = @nID" : "");
            SqlCondition.Append(nModuleID != 0 ? " and nModuleID = @nModuleID" : "");
            SqlCondition.Append(nRoleID != 0 ? " and nRoleID = @nRoleID" : "");
            SqlCondition.Append(charRoleMark != "" ? " and charRoleMark = @charRoleMark" : "");
            SqlCondition.Append(nTabIndex != 0 ? " and nTabIndex = @nTabIndex" : "");
            SqlParameter[] sqlParams ={
             					new SqlParameter("nID",nID),
							new SqlParameter("nModuleID",nModuleID),
							new SqlParameter("nRoleID",nRoleID),
							new SqlParameter("charRoleMark",charRoleMark),
							new SqlParameter("nTabIndex",nTabIndex)
                                     };
            Params = sqlParams;
        }
    }
    /// <summary>
    /// 类名:WebPlatForm_Module_Relation
    /// 描述:WebPlatForm_Module_Relation数据操作类
    /// </summary>	

    public class DBTAB_Module_Relation : DBOperator
    {
        public DBTAB_Module_Relation(string ConnectionString) : base(ConnectionString) { }
        #region 增删改
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(WebPlatForm_Module_Relation model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into WebPlatForm_Module_Relation(");
            strSql.Append("nModuleID,nRoleID,nTabIndex");
            strSql.Append(") values (");
            strSql.Append("@nModuleID,@nRoleID,0");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@nModuleID", SqlDbType.Int,4) ,            
                        new SqlParameter("@nRoleID", SqlDbType.Int,4) ,                
                        new SqlParameter("@nTabIndex", SqlDbType.Int,4)             
              
            };

            parameters[0].Value = model.nModuleID;
            parameters[1].Value = model.nRoleID;
            parameters[2].Value = model.nTabIndex;
            return SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, strSql.ToString(), parameters) > 0;
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(WebPlatForm_Module_Relation model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update WebPlatForm_Module_Relation set ");
            strSql.Append(" nModuleID = @nModuleID , ");
            strSql.Append(" nRoleID = @nRoleID , ");
            strSql.Append(" nTabIndex = @nTabIndex  ");
            strSql.Append(" where nID=@nID ");

            SqlParameter[] parameters = {
			            new SqlParameter("@nID", SqlDbType.Int,4) ,            
                        new SqlParameter("@nModuleID", SqlDbType.Int,4) ,            
                        new SqlParameter("@nRoleID", SqlDbType.Int,4) ,                      
                        new SqlParameter("@nTabIndex", SqlDbType.Int,4)             
              
            };

            parameters[0].Value = model.nID;
            parameters[1].Value = model.nModuleID;
            parameters[2].Value = model.nRoleID;
            parameters[3].Value = model.nTabIndex;
            return SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, strSql.ToString(), parameters) > 0;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string strID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from WebPlatForm_Module_Relation ");
            strSql.Append(" where nID=@strID");
            SqlParameter[] parameters = {
					new SqlParameter("strID",strID)};

            return SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, strSql.ToString(), parameters) > 0;
        }

        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteForRoleID(int RoleID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from WebPlatForm_Module_Relation where nRoleID=@nRoleID");
            SqlParameter[] parameters = {
					new SqlParameter("nRoleID",RoleID)};
            return SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, strSql.ToString(), parameters) > 0;
        }
        /// <summary>
        /// 检查数据是否存在
        /// </summary>
        public bool Exists(WebPlatForm_Module_Relation model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) from WebPlatForm_Module_Relation where nRoleID=@nRoleID and nModuleID=@nModuleID");
            SqlParameter[] parameters = {
					new SqlParameter("nRoleID",model.nRoleID),
                    new SqlParameter("nModuleID",model.nModuleID)
                                        };
            return Convert.ToInt32(SqlHelper.ExecuteScalar(ConnectionString, CommandType.Text, strSql.ToString(), parameters)) > 0;

        }
        #endregion

        #region 扩展方法
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public WebPlatForm_Module_Relation GetModel(string ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *");
            strSql.Append("  from WebPlatForm_Module_Relation  where nID=@ID");

            SqlParameter[] sqlParams = {
			new SqlParameter("ID",ID)          
                                       };
            WebPlatForm_Module_Relation model = new WebPlatForm_Module_Relation();

            DataSet ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.Text, strSql.ToString(), sqlParams);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["nID"].ToString() != "")
                {
                    model.nID = int.Parse(ds.Tables[0].Rows[0]["nID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["nModuleID"].ToString() != "")
                {
                    model.nModuleID = int.Parse(ds.Tables[0].Rows[0]["nModuleID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["nRoleID"].ToString() != "")
                {
                    model.nRoleID = int.Parse(ds.Tables[0].Rows[0]["nRoleID"].ToString());
                }
                model.charRoleMark = ds.Tables[0].Rows[0]["charRoleMark"].ToString();
                if (ds.Tables[0].Rows[0]["nTabIndex"].ToString() != "")
                {
                    model.nTabIndex = int.Parse(ds.Tables[0].Rows[0]["nTabIndex"].ToString());
                }

                return model;
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 获取所有数据
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public DataTable GetData(DBTAB_Module_RelationQuery TAB_Module_RelationQuery)
        {
            SqlParameter[] sqlParams;
            StringBuilder strSqlOption = new StringBuilder();
            TAB_Module_RelationQuery.OutPut(out strSqlOption, out sqlParams);
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM WebPlatForm_Module_Relation where 1=1" + strSqlOption.ToString());

            return SqlHelper.ExecuteDataset(ConnectionString, CommandType.Text, strSql.ToString(), sqlParams).Tables[0];
        }
        /// <summary>
        /// 获取数据总数
        /// </summary>
        /// <param name="jcid"></param>
        /// <returns></returns>
        public int GetDataCount(DBTAB_Module_RelationQuery TAB_Module_RelationQuery)
        {
            SqlParameter[] sqlParams;
            StringBuilder strSqlOption = new StringBuilder();
            TAB_Module_RelationQuery.OutPut(out strSqlOption, out sqlParams);
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) ");
            strSql.Append(" FROM WebPlatForm_Module_Relation where 1=1" + strSqlOption.ToString());
            return ObjectConvertClass.static_ext_int(SqlHelper.ExecuteScalar(ConnectionString, CommandType.Text, strSql.ToString(), sqlParams));
        }

        /// <summary>
        /// 获取分页数据
        /// </summary>
        public DataTable GetPaginationData(DBTAB_Module_RelationQuery TAB_Module_RelationQuery)
        {
            StringBuilder strSqlOption = new StringBuilder();
            StringBuilder strSql = new StringBuilder();
            SqlParameter[] sqlParams;
            TAB_Module_RelationQuery.OutPut(out strSqlOption, out sqlParams);
            strSql.Append(@"select top " + TAB_Module_RelationQuery.rows.ToString() + " * from WebPlatForm_Module_Relation  where  1=1 " + strSqlOption.ToString() + " and nID not in ( select top " + (TAB_Module_RelationQuery.page - 1) * TAB_Module_RelationQuery.rows + " nID from WebPlatForm_Module_Relation where  1=1 " + strSqlOption.ToString() + " order by nID desc) order by nID desc");

            return SqlHelper.ExecuteDataset(ConnectionString, CommandType.Text, strSql.ToString(), sqlParams).Tables[0];
        }
        #endregion

    }
}

