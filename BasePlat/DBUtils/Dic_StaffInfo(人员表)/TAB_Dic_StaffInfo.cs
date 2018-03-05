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
    /// 类名:WebPlatForm_Dic_StaffInfo
    /// 描述:人员信息表查询条件类
    /// </summary>	

    public class DBDic_StaffInfoQuery
    {
        public int page = 0;
        public int rows = 0;

        public string strID = "";
        public string strNumber = "";
        public string strName = "";
        public string strDuty = "";
        public string strPassword = "";
        public string strPictureFileName = "";
        public void OutPut(out StringBuilder SqlCondition, out SqlParameter[] Params)
        {
            SqlCondition = new StringBuilder();

            SqlCondition.Append(strID != "" ? " and strID = @strID" : "");

            SqlCondition.Append(strNumber != "" ? " and strNumber = @strNumber" : "");

            SqlCondition.Append(strName != "" ? " and strName like @strName" : "");

            SqlCondition.Append(strDuty != "" ? " and strDuty = @strDuty" : "");

            SqlCondition.Append(strPassword != "" ? " and strPassword = @strPassword" : "");

            SqlCondition.Append(strPictureFileName != "" ? " and strPictureFileName = @strPictureFileName" : "");
            SqlParameter[] sqlParams ={
							new SqlParameter("@strID",strID),
							new SqlParameter("@strNumber",strNumber),
							new SqlParameter("@strName","%"+strName+"%"),
							new SqlParameter("@strDuty",strDuty),
							new SqlParameter("@strPassword",strPassword),
							new SqlParameter("@strPictureFileName",strPictureFileName)
                                     };
            Params = sqlParams;
        }
    }
    /// <summary>
    /// 类名:WebPlatForm_Dic_StaffInfo
    /// 描述:人员信息表数据操作类
    /// </summary>	

    public class DBDic_StaffInfo : DBOperator
    {
        public DBDic_StaffInfo(string ConnectionString) : base(ConnectionString) { }
        #region 增删改
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Dic_StaffInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into WebPlatForm_Dic_StaffInfo(");
            strSql.Append("strNumber,strName,strDuty,strPassword,strPictureFileName,nRoleID");
            strSql.Append(") values (");
            strSql.Append("@strNumber,@strName,@strDuty,@strPassword,@strPictureFileName,@nRoleID");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {          
                        new SqlParameter("@strNumber",model.strNumber) ,            
                        new SqlParameter("@strName",model.strName) ,            
                        new SqlParameter("@strDuty", model.strDuty) ,            
                        new SqlParameter("@strPassword", model.strPassword) ,            
                        new SqlParameter("@strPictureFileName", model.strPictureFileName),            
                        new SqlParameter("@nRoleID", model.nRoleID)     
              
            };
            return SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, strSql.ToString(), parameters) > 0;
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Dic_StaffInfo model)
        {
            StringBuilder strSql=new StringBuilder();
			strSql.Append("update WebPlatForm_Dic_StaffInfo set ");
			                                                
            strSql.Append(" strTokenID = @strTokenID , ");                                    
            strSql.Append(" nRoleID = @nRoleID , ");                                    
            strSql.Append(" strID = @strID , ");                                    
            strSql.Append(" strNumber = @strNumber , ");                                    
            strSql.Append(" strName = @strName , ");                                    
            strSql.Append(" strDuty = @strDuty , ");                                    
            strSql.Append(" strPassword = @strPassword , ");                                    
            strSql.Append(" strPictureFileName = @strPictureFileName , ");                                    
            strSql.Append(" dtTokenTime = @dtTokenTime , ");                                    
            strSql.Append(" dtLoginTime = @dtLoginTime");
			strSql.Append(" where strID=@strID  ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@nID", SqlDbType.Int,4) ,            
                        new SqlParameter("@strTokenID", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@nRoleID", SqlDbType.Int,4) ,            
                        new SqlParameter("@strID", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@strNumber", SqlDbType.VarChar,10) ,            
                        new SqlParameter("@strName", SqlDbType.VarChar,10) ,            
                        new SqlParameter("@strDuty", SqlDbType.VarChar,10) ,            
                        new SqlParameter("@strPassword", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@strPictureFileName", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@dtTokenTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@dtLoginTime", SqlDbType.DateTime)             
              
            };
						            
            parameters[0].Value = model.nID;                        
            parameters[1].Value = model.strTokenID;                        
            parameters[2].Value = model.nRoleID;                        
            parameters[3].Value = model.strID;                        
            parameters[4].Value = model.strNumber;                        
            parameters[5].Value = model.strName;                        
            parameters[6].Value = model.strDuty;                        
            parameters[7].Value = model.strPassword;                        
            parameters[8].Value = model.strPictureFileName;                        
            parameters[9].Value = model.dtTokenTime;                        
            parameters[10].Value = model.dtLoginTime;
            return SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, strSql.ToString(),parameters) > 0;
        }

        /// <summary>
        /// 更新人员信息
        /// </summary>
        public bool UpdateTrainManInfo(Dic_StaffInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update WebPlatForm_Dic_StaffInfo set ");
            strSql.Append(" strNumber = @strNumber , ");
            strSql.Append(" strName = @strName , ");
            strSql.Append(" nRoleID = @nRoleID,");
            strSql.Append(" strDuty = @strDuty");
            strSql.Append(" where strID=@strID ");

            SqlParameter[] parameters = {
			            new SqlParameter("@strID", SqlDbType.VarChar,50) ,                        
                        new SqlParameter("@strNumber", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@strName", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@nRoleID", SqlDbType.Int,4),
                        new SqlParameter("@strDuty", SqlDbType.VarChar,50)
            };

            parameters[0].Value = model.strID;
            parameters[1].Value = model.strNumber;
            parameters[2].Value = model.strName;
            parameters[3].Value = model.nRoleID;
            parameters[4].Value = model.strDuty;
            return SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, strSql.ToString(), parameters) > 0;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdatePassword(Dic_StaffInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update WebPlatForm_Dic_StaffInfo set ");
            strSql.Append(" strPassword = @strPassword ");
            strSql.Append(" where strNumber = @strNumber ");

            SqlParameter[] parameters = {                      
                        new SqlParameter("@strNumber", model.strNumber) ,                        
                        new SqlParameter("@strPassword", model.strPassword)
            };
            return SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, strSql.ToString(), parameters) > 0;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string strID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from WebPlatForm_Dic_StaffInfo ");
            strSql.Append(" where strID=@strID");
            SqlParameter[] parameters = {
					new SqlParameter("strID",strID)};

            return SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, strSql.ToString(), parameters) > 0;
        }

        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteList(string nIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from WebPlatForm_Dic_StaffInfo ");
            strSql.Append(" where ID in (" + nIDlist + ")  ");

            return SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, strSql.ToString()) > 0;
        }
        /// <summary>
        /// 检查数据是否存在
        /// </summary>
        public bool Exists(Dic_StaffInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) from WebPlatForm_Dic_StaffInfo where strNumber=@strNumber");
            if (model.strID != "")
            {
                strSql.Append(" and strID<>@strID");
            }
            SqlParameter[] parameters = {
                                            new SqlParameter("strNumber",model.strNumber),
					new SqlParameter("strID",model.strID)};
            return Convert.ToInt32(SqlHelper.ExecuteScalar(ConnectionString, CommandType.Text, strSql.ToString(), parameters)) > 0;

        }
        #endregion

        #region 扩展方法
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Dic_StaffInfo GetModel(DBDic_StaffInfoQuery Query)
        {
            SqlParameter[] sqlParams;
            StringBuilder strSqlOption = new StringBuilder();
            Query.OutPut(out strSqlOption, out sqlParams);
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *");
            strSql.Append("  from WebPlatForm_Dic_StaffInfo  where 1=1 " + strSqlOption);
            Dic_StaffInfo model = new Dic_StaffInfo();

            DataSet ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.Text, strSql.ToString(), sqlParams);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["nID"].ToString() != "")
                {
                    model.nID = int.Parse(ds.Tables[0].Rows[0]["nID"].ToString());
                }
                model.strID = ds.Tables[0].Rows[0]["strID"].ToString();
                model.strNumber = ds.Tables[0].Rows[0]["strNumber"].ToString();
                model.strName = ds.Tables[0].Rows[0]["strName"].ToString();
                model.strDuty = ds.Tables[0].Rows[0]["strDuty"].ToString();
                model.strPassword = ds.Tables[0].Rows[0]["strPassword"].ToString();
                model.strPictureFileName = ds.Tables[0].Rows[0]["strPictureFileName"].ToString();

                model.dtTokenTime = ObjectConvertClass.static_ext_Date(ds.Tables[0].Rows[0]["dtTokenTime"]);
                model.dtLoginTime = ObjectConvertClass.static_ext_Date(ds.Tables[0].Rows[0]["dtLoginTime"]);
                model.strTokenID = ObjectConvertClass.static_ext_string(ds.Tables[0].Rows[0]["strTokenID"]);
                model.nRoleID = ObjectConvertClass.static_ext_int(ds.Tables[0].Rows[0]["nRoleID"]);
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 工号得到一个对象实体
        /// </summary>
        public Dic_StaffInfo GetModelByNumber(string strNumber)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *");
            strSql.Append("  from WebPlatForm_Dic_StaffInfo  where strNumber=@strNumber");

            SqlParameter[] sqlParams = {
			new SqlParameter("strNumber",strNumber)          
                                       };
            Dic_StaffInfo model = new Dic_StaffInfo();

            DataSet ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.Text, strSql.ToString(), sqlParams);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["nID"].ToString() != "")
                {
                    model.nID = int.Parse(ds.Tables[0].Rows[0]["nID"].ToString());
                }
                model.strID = ds.Tables[0].Rows[0]["strID"].ToString();
                model.strNumber = ds.Tables[0].Rows[0]["strNumber"].ToString();
                model.strName = ds.Tables[0].Rows[0]["strName"].ToString();
                model.strDuty = ds.Tables[0].Rows[0]["strDuty"].ToString();
                model.strPassword = ds.Tables[0].Rows[0]["strPassword"].ToString();
                model.strPictureFileName = ds.Tables[0].Rows[0]["strPictureFileName"].ToString();

                model.dtTokenTime = ObjectConvertClass.static_ext_Date(ds.Tables[0].Rows[0]["dtTokenTime"]);
                model.dtLoginTime = ObjectConvertClass.static_ext_Date(ds.Tables[0].Rows[0]["dtLoginTime"]);
                model.strTokenID = ObjectConvertClass.static_ext_string(ds.Tables[0].Rows[0]["strTokenID"]);
                model.nRoleID = ObjectConvertClass.static_ext_int(ds.Tables[0].Rows[0]["nRoleID"]);
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
        public DataTable GetData(DBDic_StaffInfoQuery TAB_Dic_StaffInfoQuery)
        {
            SqlParameter[] sqlParams;
            StringBuilder strSqlOption = new StringBuilder();
            TAB_Dic_StaffInfoQuery.OutPut(out strSqlOption, out sqlParams);
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM VIEW_WebPlatForm_StaffInfo where 1=1" + strSqlOption.ToString());

            return SqlHelper.ExecuteDataset(ConnectionString, CommandType.Text, strSql.ToString(), sqlParams).Tables[0];
        }
        /// <summary>
        /// 获取数据总数
        /// </summary>
        /// <param name="jcid"></param>
        /// <returns></returns>
        public int GetDataCount(DBDic_StaffInfoQuery TAB_Dic_StaffInfoQuery)
        {
            SqlParameter[] sqlParams;
            StringBuilder strSqlOption = new StringBuilder();
            TAB_Dic_StaffInfoQuery.OutPut(out strSqlOption, out sqlParams);
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) ");
            strSql.Append(" FROM VIEW_WebPlatForm_StaffInfo where 1=1" + strSqlOption.ToString());
            return ObjectConvertClass.static_ext_int(SqlHelper.ExecuteScalar(ConnectionString, CommandType.Text, strSql.ToString(), sqlParams));
        }

        /// <summary>
        /// 获取分页数据
        /// </summary>
        public DataTable GetPaginationData(DBDic_StaffInfoQuery TAB_Dic_StaffInfoQuery)
        {
            StringBuilder strSqlOption = new StringBuilder();
            StringBuilder strSql = new StringBuilder();
            SqlParameter[] sqlParams;
            TAB_Dic_StaffInfoQuery.OutPut(out strSqlOption, out sqlParams);
            strSql.Append(@"select top " + TAB_Dic_StaffInfoQuery.rows.ToString() + " * from VIEW_WebPlatForm_StaffInfo  where  1=1 " + strSqlOption.ToString() + " and nID not in ( select top " + (TAB_Dic_StaffInfoQuery.page - 1) * TAB_Dic_StaffInfoQuery.rows + " nID from VIEW_WebPlatForm_StaffInfo where  1=1 " + strSqlOption.ToString() + " order by nID desc) order by nID desc");

            return SqlHelper.ExecuteDataset(ConnectionString, CommandType.Text, strSql.ToString(), sqlParams).Tables[0];
        }

        //根据TokenID查询用户信息
        public Dic_StaffInfo UserInfoByTL(string TokenID, long TokenSecond, long LoginSecond)
        {
            string strCondition = " where strTokenID = @TokenID";
            if (TokenSecond > -1)
            {
                strCondition += " and dateadd(ss,@TokenSecond,dtTokenTime) >= getdate()";
            }
            if (LoginSecond > -1)
            {
                strCondition += " and dateadd(ss,@LoginSecond,dtLoginTime) >= getdate()";
            }
            SqlParameter[] sqlParams = {
                                              new SqlParameter("TokenID",TokenID),
                                              new SqlParameter("TokenSecond",TokenSecond),
                                              new SqlParameter("LoginSecond",LoginSecond)
                                          };
            string strSql = "select top 1 * from WebPlatForm_Dic_StaffInfo" + strCondition;
            DataTable dt = SqlHelper.ExecuteDataset(ConnectionString, CommandType.Text, strSql, sqlParams).Tables[0];
            Dic_StaffInfo UserInfo = new Dic_StaffInfo();
            if (dt.Rows.Count > 0)
            {
                return SetValue(UserInfo, dt.Rows[0]);
            }
            return UserInfo;

        }

        //根据工号、姓名、密码查询用户信息
        public Dic_StaffInfo UserInfo(string UserNum, string UserName, string pwd)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from WebPlatForm_Dic_StaffInfo where 1=1");
            strSql.Append(UserNum != "" ? " and strNumber = @UserNum" : "");
            strSql.Append(UserName != "" ? " and strName = @UserName" : "");
            strSql.Append(pwd != "" ? " and strPassword = @pwd" : "");
            SqlParameter[] sqlParams = {
                                           new SqlParameter("UserNum",UserNum),
                                           new SqlParameter("UserName",UserName),
                                           new SqlParameter("pwd",pwd)
                                       };
            DataTable dt = SqlHelper.ExecuteDataset(ConnectionString, CommandType.Text, strSql.ToString(), sqlParams).Tables[0];
            Dic_StaffInfo UserInfo = new Dic_StaffInfo();
            if (dt.Rows.Count > 0)
            {
                return SetValue(UserInfo, dt.Rows[0]);
            }
            return UserInfo;
        }

        /// <summary>
        /// 设置属性
        /// </summary>
        /// <param name="model"></param>
        /// <param name="dr"></param>
        /// <returns></returns>
        public Dic_StaffInfo SetValue(Dic_StaffInfo model, DataRow dr)
        {
            if (dr != null)
            {
                model.nID = ObjectConvertClass.static_ext_int(dr["nID"].ToString());
                model.strID = dr["strID"].ToString();
                model.strNumber = dr["strNumber"].ToString();
                model.strName = dr["strName"].ToString();
                model.strDuty = dr["strDuty"].ToString();
                model.strPassword = dr["strPassword"].ToString();
                model.strPictureFileName = dr["strPictureFileName"].ToString();

                model.dtTokenTime = ObjectConvertClass.static_ext_Date(dr["dtTokenTime"]);
                model.dtLoginTime = ObjectConvertClass.static_ext_Date(dr["dtLoginTime"]);
                model.strTokenID = ObjectConvertClass.static_ext_string(dr["strTokenID"]);
                model.nRoleID = ObjectConvertClass.static_ext_int(dr["nRoleID"]);
            }
            return model;
        }
        #endregion

    }
}

