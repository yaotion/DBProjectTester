using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.SqlServer.Dac;
using System.IO;
using System.Data.SqlClient;
using Microsoft.SqlServer.Management.Common;
 
using Microsoft.SqlServer.Management.Sdk.Sfc;
using Microsoft.SqlServer.Management.Smo;
namespace DbUnitTest2000
{
    public partial class DbView : Form
    {
        public DbView()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnlocal_Click(object sender, EventArgs e)
        {
          
            this.openFileDialog1.Filter = "数据库文件(*.DACPAC)|*.dacpac";
            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                this.dbtxtlocal.Text = openFileDialog1.FileName;
                if (!string.IsNullOrEmpty(this.dbtxtlocal.Text))
                {
                    viewDataShace(this.dbtxtlocal.Text);
                }
            }
            updateTree();
        }
        public List<mymodel> lmst = new List<mymodel>();
        List<TabInfoClass> stab = new List<TabInfoClass>();
        private void viewDataShace(string filename)
        {
            Stream fs = null;
         
            try
            {
                string dacfile = filename;
                fs = File.Open(dacfile, FileMode.OpenOrCreate) as Stream;
             
                Microsoft.SqlServer.Dac.Model.ModelLoadOptions mlo = new Microsoft.SqlServer.Dac.Model.ModelLoadOptions();
                mlo.ModelStorageType = DacSchemaModelStorageType.Memory;
                var model = Microsoft.SqlServer.Dac.Model.TSqlModel.LoadFromDacpac(fs, mlo);
                if (fs != null)
                {
                    fs.Close();
                    fs.Dispose();
                }
                this.localtree.Nodes.Clear();
                lmst.Clear();
                List<TabInfoClass> lstemp = null;
                foreach (var s in new Microsoft.SqlServer.Dac.Model.ModelTypeClass[] { Microsoft.SqlServer.Dac.Model.ModelSchema.Table, Microsoft.SqlServer.Dac.Model.ModelSchema.View, Microsoft.SqlServer.Dac.Model.ModelSchema.Procedure })
                {
                    Application.DoEvents();//var allTables = model.GetObjects(DacQueryScopes.All, ModelSchema.Table);
                    var allTables = model.GetObjects(Microsoft.SqlServer.Dac.Model.DacQueryScopes.UserDefined, s);
                    var tableScripts = from t in allTables
                                      
                                       select t;
                   lstemp = new List<TabInfoClass>();
                //  Microsoft.SqlServer.Dac.Model.TSqlObject tob = new Microsoft.SqlServer.Dac.Model.TSqlObject();
          
               // Microsoft.SqlServer.TransactSql.ScriptDom.TSqlScript
                    // Microsoft.SqlServer.Dac.Model.TSqlObjectOptions
                   // Microsoft.SqlServer.Dac.TSqlModelUtils 
 
             // tableScripts.OrderBy<Microsoft.SqlServer.Dac.Model.TSqlObject, Microsoft.SqlServer.Dac.Model.ObjectIdentifier>(t=>t.Name);
                    foreach (var x in tableScripts)
                    {
                    
                        
                        string on = x.ObjectType.Name;//类型
                        string nm = x.Name.Parts[1];//名字
                        string jb = x.GetScript();
                        
                        mymodel mym = new mymodel();
                        mym.tab = nm;
                        mym.sql = jb;
                        lmst.Add(mym);
                        TabInfoClass tabc = new TabInfoClass();
                        tabc.TableName = nm;
                        tabc.FiledName = new List<fileds>();
                      //  List<TreeNode> lst = new List<TreeNode>();
                        foreach (var c in x.GetChildren())
                        {
                            Application.DoEvents();
                            try { 
                            string field = c.Name.Parts[2].ToString();
                          
                            string valtype = c.GetReferenced(Microsoft.SqlServer.Dac.Model.Column.DataType).First().Name.Parts[0];
                          
                           
                            fileds fds = new fileds();
                            fds.Fname = field;
                            fds.Ftype = valtype;
                            tabc.FiledName.Add(fds);
                                }catch(Exception  error)
                            {
                                continue;
                            }
                                

                        }
                        lstemp.Add(tabc);
                        stab.Add(tabc);
                    }
                       var sortedList =
               (from a in lstemp
                orderby a.TableName 
                select a).ToList();
                   
                       for (int i = 0; i <= sortedList.Count - 1; i++)
                     {
                         TreeNode[] treearray = new TreeNode[sortedList[i].FiledName.Count];
                        
                         var fList =
            (from a in sortedList[i].FiledName
             orderby a.Fname
             select a).ToList();
                         for (int j = 0; j < fList.Count; j++)
                         {

                             Application.DoEvents();
                             treearray[j] = new TreeNode();
                             treearray[j].Text = fList[j].Fname;
                             treearray[j].ImageKey = "add";
                            
                         }

                         TreeNode tn = new TreeNode(sortedList[i].TableName, treearray);    
                         this.localtree.Nodes.Add(tn);
                     }

                }
            }
            catch (Exception error)
            {
                if (fs != null)
                {
                    fs.Close();
                    fs.Dispose();
                }
                MessageBox.Show(error.Message);
            }
             
        }
        private void checkUpdate()
        {
            if (this.remotree.Nodes.Count <= 0)
            {
                for (int m = 0; m < this.localtree.Nodes.Count; m++)
                {

                    if (this.localtree.Nodes[m].Parent == null)
                    {
                         
                            this.localtree.Nodes[m].ImageKey = "add";
                         

                    }
                    else
                    {
                        this.localtree.Nodes[m].ImageKey = "add";

                    }

                }
            }

        }
        public List<mymodel> lmst2 = new List<mymodel>();
        List<TabInfoClass> dtab = new List<TabInfoClass>();
        private void viewDataShace2(string filename)
        {
            Stream fs = null;
          
            try
            {
                string dacfile = filename;
                fs = File.Open(dacfile, FileMode.OpenOrCreate) as Stream;
              
                Microsoft.SqlServer.Dac.Model.ModelLoadOptions mlo = new Microsoft.SqlServer.Dac.Model.ModelLoadOptions();
                mlo.ModelStorageType = DacSchemaModelStorageType.Memory;
                var model = Microsoft.SqlServer.Dac.Model.TSqlModel.LoadFromDacpac(fs, mlo);
                if (fs != null)
                {
                    fs.Close();
                    fs.Dispose();
                }
                this.remotree.Nodes.Clear();
                lmst2.Clear();
                List<TabInfoClass> lstemp = null;
                foreach (var s in new Microsoft.SqlServer.Dac.Model.ModelTypeClass[] { Microsoft.SqlServer.Dac.Model.ModelSchema.Table, Microsoft.SqlServer.Dac.Model.ModelSchema.View, Microsoft.SqlServer.Dac.Model.ModelSchema.Procedure })
                {
                    Application.DoEvents();//var allTables = model.GetObjects(DacQueryScopes.All, ModelSchema.Table);
                    var allTables = model.GetObjects(Microsoft.SqlServer.Dac.Model.DacQueryScopes.UserDefined, s);
                    var tableScripts = from t in allTables
                                     
                                       select t;
                    lstemp = new List<TabInfoClass>();
                   
                     
                    foreach (var x in tableScripts)
                    {

                        Application.DoEvents();
                        string on = x.ObjectType.Name;//类型
                        string nm = x.Name.Parts[1];//名字
                        string jb = x.GetScript();
                        mymodel mym = new mymodel();
                        mym.tab = nm;
                        mym.sql = jb;
                        lmst2.Add(mym);
                        TabInfoClass tabc = new TabInfoClass();
                        tabc.TableName = nm;
                        tabc.FiledName = new List<fileds>();
                        foreach (var c in x.GetChildren())
                        {
                            Application.DoEvents();
                            try
                            {
                                string field = c.Name.Parts[2].ToString();
                                string valtype = c.GetReferenced(Microsoft.SqlServer.Dac.Model.Column.DataType).First().Name.Parts[0];
                                fileds fds = new fileds();
                                fds.Fname = field;
                                fds.Ftype = valtype;
                                tabc.FiledName.Add(fds);
                            }
                            catch (Exception error)
                            {
                                continue;
                            }
                        }
                        lstemp.Add(tabc);
                        dtab .Add(tabc);
                    }
                    CreateRemotree(lstemp);
                   


                }
            }
            catch (Exception error)
            {
                if (fs != null)
                {
                    fs.Close();
                    fs.Dispose();
                }
                MessageBox.Show(error.Message);
            }
        }
        private void CreateRemotree(List<TabInfoClass> lstemp)
        {
            var sortedList =
              (from a in lstemp
               orderby a.TableName
               select a).ToList();
            

            for (int i = 0; i <= sortedList.Count - 1; i++)
            {
                TreeNode[] treearray = new TreeNode[sortedList[i].FiledName.Count];
                var fList =
   (from a in sortedList[i].FiledName
    orderby a.Fname
    select a).ToList();
                for (int j = 0; j < fList.Count; j++)
                {

                    Application.DoEvents();
                    treearray[j] = new TreeNode();
                    treearray[j].Text = fList[j].Fname;
                    treearray[j].ImageKey = "add";

                }

                TreeNode tn = new TreeNode(sortedList[i].TableName, treearray);
                this.remotree.Nodes.Add(tn);
            }
        }

        private void localtree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (this.localtree.SelectedNode.Parent == null)
            {
                //string ret = ah.GetMethodInfo(this.lablpath.Text, this.dlltree.SelectedNode.Parent.Text, this.dlltree.SelectedNode.Text);
                this.localtxtsql.Clear();
                for (int i = 0; i < lmst.Count;i++ )
                {
                    int ind = this.localtree.SelectedNode.Text.IndexOf("[");
                    if(ind<0)
                    { 
                if(lmst[i].tab==this.localtree.SelectedNode.Text)
                { 
                    this.localtxtsql.AppendText(lmst[i].sql);
                    break;
                }
                    }else
                    {//有[
                       // MessageBox.Show(this.localtree.SelectedNode.Text.Substring(0, ind));
                        if (lmst[i].tab == this.localtree.SelectedNode.Text.Substring(0,ind)) 
                        {
                            this.localtxtsql.AppendText(lmst[i].sql);
                            break;
                        }

                    }
                }
            }
        }

        private void btnremot_Click(object sender, EventArgs e)
        {
            DbSet db = new DbSet();
            db.OnString += new oneventConnstr(Query_OnShowString);
            
            db.ShowDialog();
        }
        private void Query_OnShowString(string ip)
        {

            this.remotxt.Text = ip;
        }
        private List<string> GetDatatbNames(SqlConnection conn,string sql)
        {

            SqlCommand comm = new SqlCommand(sql, conn);

            List<string> dbNames = new List<string>();

            try
            {

                conn.Open();

                SqlDataReader reader = comm.ExecuteReader();

                while (reader.Read())
                {

                    dbNames.Add(reader["name"].ToString());

                }
                reader.Close();
                reader.Dispose();





            }

            catch (Exception error)
            {

                Console.WriteLine("connect dbfailed");
                MessageBox.Show(error.Message);
                //throw (new Exception("connect db failed"));

            }

            finally
            {

                if (conn != null)
                {

                    conn.Close();

                    conn.Dispose();

                }

            }
            return dbNames;





        }
        private bool zipdata()
        {
            bool ret = false;
            try
            {
                string str = this.remotxt.Text;// "Data Source=192.168.1.166;Initial Catalog=master;User ID=sa;Password=Think123";

                DACExtracter DC = new DACExtracter();
                DC.ExtractDAC(str, "D:\\DP");
                ret = true;
            }
            catch
            {
                ret = false;
            }
            return ret;
        }

        private void remotxt_TextChanged(object sender, EventArgs e)
        {
           // DataTable mydt = null;// GetDataTableNames();

            this.remotree.Nodes.Clear();
          bool ret=  zipdata();
            if(ret)
            { 
              if (!string.IsNullOrEmpty(DACExtracter.filem))
              viewDataShace2(DACExtracter.filem);
            }
            updateTree();

          //  SqlConnection sqlcnn = new SqlConnection(this.remotxt.Text);

          //  string sql = "SELECT * FROM " + sqlcnn.Database + "..SysObjects Where XType='U'  ORDER BY Name ";//
          //    //SELECT Name FROM SysColumns WHERE id=Object_Id('TableName') 
          //List<string> mytab=    GetDatatbNames(sqlcnn, sql);
         
          //  for(int i=0;i<mytab.Count;i++)
          //  {
          //      Application.DoEvents();
          //      List<string> zdlst = new List<string>();
          //      if(string.IsNullOrEmpty(sqlcnn.ConnectionString))
          //          sqlcnn = new SqlConnection(this.remotxt.Text);
          //      List<string> lstzd = GetDatatbNames(sqlcnn, "SELECT * FROM SysColumns WHERE id=Object_Id('"+mytab[i]+"')");

          //      TreeNode[] treearray = new TreeNode[lstzd.Count];
          //      for (int jj = 0; jj < lstzd.Count; jj++)
          //      {
          //          Application.DoEvents();
          //          treearray[jj] = new TreeNode();
          //          treearray[jj].Text = lstzd[jj] ;
          //          treearray[jj].Tag =(i+jj).ToString();

          //      }
          //      TreeNode tn = new TreeNode(mytab[i], treearray);

          //      this.remotree.Nodes.Add(tn);
          //  }

              //mydt = ExcuteQuery(this.remotxt.Text, sql);
            //              string sql = @"
            //   select  
            //      [表名]=c.Name, 
            //     [表说明]=isnull(f.[value],''),  
            //      [列序号]=a.Column_id,  
            //     [列名]=a.Name,  
            //     [列说明]=isnull(e.[value],''),  
            //     [数据库类型]=b.Name,    
            //    [类型]= case when b.Name = 'image' then 'byte[]'
            //                 when b.Name in('image','uniqueidentifier','ntext','varchar','ntext','nchar','nvarchar','text','char') then 'string'
            //                 when b.Name in('tinyint','smallint','int','bigint') then 'int'
            //                 when b.Name in('datetime','smalldatetime') then 'DateTime'
            //                  when b.Name in('float','decimal','numeric','money','real','smallmoney') then 'decimal'
            //                  when b.Name ='bit' then 'bool' else b.name end ,
            //    [标识]= case when is_identity=1 then '是' else '' end,  
            //     [主键]= case when exists(select 1 from sys.objects x join sys.indexes y on x.Type=N'PK' and x.Name=y.Name  
            //                        join sysindexkeys z on z.ID=a.Object_id and z.indid=y.index_id and z.Colid=a.Column_id)  
            //                     then '是' else '' end,      
            //     [字节数]=case when a.[max_length]=-1 and b.Name!='xml' then 'max/2G'  
            //                   when b.Name='xml' then '2^31-1字节/2G' 
            //                  else rtrim(a.[max_length]) end,  
            //     [长度]=case when ColumnProperty(a.object_id,a.Name,'Precision')=-1 then '2^31-1' 
            //                 else rtrim(ColumnProperty(a.object_id,a.Name,'Precision')) end,  
            //      [小数位]=isnull(ColumnProperty(a.object_id,a.Name,'Scale'),0),  
            //      [是否为空]=case when a.is_nullable=1 then '是' else '' end,      
            //      [默认值]=isnull(d.text,'')      
            //  from  
            //     sys.columns a  
            // left join 
            //     sys.types b on a.user_type_id=b.user_type_id  
            //  inner join 
            //     sys.objects c on a.object_id=c.object_id and c.Type='U' 
            // left join 
            //     syscomments d on a.default_object_id=d.ID  
            // left join 
            //     sys.extended_properties e on e.major_id=c.object_id and e.minor_id=a.Column_id and e.class=1   
            //  left join 
            //      sys.extended_properties f on f.major_id=c.object_id and f.minor_id=0 and f.class=1 ";
        }
        void  updateTree()
        {


            if (this.remotree.Nodes.Count > 0)
            {

                if (this.localtree.Nodes.Count <=0)
                {
                    //或者左边全缺失 
                    return;

                }
                else 
                {
                    this.localtree.Nodes.Clear();
                    //先合并
                    // 先找到缺失表，然后找缺失项目的索引
                   
                    //先循环目标的表名
                   //循环源表，如果目标表多的话，源表增加并提示缺 
                    //如果目标表存在的话，循环表的字段，如果目标表存在，源表不存在则提示缺，如果目标表不存在，源表存在则表示更新
                    List<string> sarray = new List<string>();
                    List<string> darray = new List<string>();
                    var vstab =
          (from a in stab
           orderby a.TableName
           select a).ToList();
                    var vdtab =
        (from a in dtab
         orderby a.TableName
         select a).ToList();
                    foreach(var s in vstab)
                    {
                        sarray.Add(s.TableName);
                    }
                    foreach (var s in vdtab)
                    {
                        darray.Add(s.TableName);
                    }
                    List<string> alltab = sarray.Union(darray).ToList<string>();
                    
                    List<string> chatab = sarray.Except(darray).ToList<string>();
                    //查询出所有的差异字段
                    for (int m = 0; m < alltab.Count; m++)
                    {

                        TreeNode tn = new TreeNode(); ;
                        for(int n=0;n<vstab.Count;n++)
                        {
                            if(vstab[n].TableName.ToLower()==alltab[m].ToLower())
                       
                            {
                                //比较2个表中的字段差异

                               

                                TreeNode[] treearray=new TreeNode[vstab[n].FiledName.Count];
                                for (int jj = 0; jj < vstab[n].FiledName.Count; jj++)
                                        {
                                            Application.DoEvents();
                                            treearray[jj] = new TreeNode();
                                             treearray[jj].Text = vstab[n].FiledName[jj].Fname;
                  

                                           }

                                 tn = new TreeNode(alltab[m], treearray);
                                 tn.ImageKey = "up";
                                 break;
                                 
                            }else
                            {
                                foreach (string x in darray)
                                {
                                    if (!string.IsNullOrEmpty(x) && x.ToLower() == alltab[m].ToLower())
                                    { 
                                        tn = new TreeNode(alltab[m]);
                                       tn.ImageKey = "del";
                                     break;
                                     }
                                }
                            }
                         }
                        this.localtree.Nodes.Add(tn);

                    }
                  

                        //for (int i = 0; i < this.remotree.Nodes.Count; i++)
                        //{
                        //    if (this.remotree.Nodes[i].Parent == null && this.localtree.Nodes[i].Parent == null)
                        //    {


                        //        int ind = this.localtree.Nodes[i].Text.IndexOf("[");
                        //        if (ind < 0)
                        //        {
                        //            if (this.remotree.Nodes[i].Text == this.localtree.Nodes[i].Text)
                        //            {

                        //                this.localtree.Nodes[i].ImageKey = "over";
                        //            }
                        //            else
                        //            {
                        //                this.localtree.Nodes[i].ImageKey = "up";
                        //            }
                        //        }
                        //        else
                        //        {
                        //            string temp = this.localtree.Nodes[i].Text.Substring(0, ind);
                        //            if (this.remotree.Nodes[i].Text == temp)
                        //            {

                        //                this.localtree.Nodes[i].ImageKey = "over";
                        //            }
                        //            else
                        //            {
                        //                //  this.localtree.Nodes[i].Text = temp + "[新增]";
                        //                this.localtree.Nodes[i].ImageKey = "up";
                        //            }

                        //        }


                        //    }


                        //}
                }


            }else
            {
                checkUpdate();
            }
        }
        private DataTable GetDataTableNames()
        {
            SqlConnection sqlconn = new SqlConnection(this.remotxt.Text);
            sqlconn.Open();
            DataTable dt = sqlconn.GetSchema("tables", null);
            
           
            
          return dt;
        }
          public   DataTable ExcuteQuery(string connectionString, string cmdText, List<SqlParameter> pars = null)
          {
             using (SqlConnection conn = new SqlConnection(connectionString))
             {
                 conn.Open();
                 using (SqlCommand cmd = new SqlCommand(cmdText, conn))
                {
                      if (pars != null && pars.Count > 0) cmd.Parameters.AddRange(pars.ToArray());
                      using (SqlDataAdapter adp = new SqlDataAdapter(cmd))
                     {
                          DataTable dt = new DataTable();
                         adp.Fill(dt);
                          return dt;
                      }
                   }
               }
           }

          private void remotree_AfterSelect(object sender, TreeViewEventArgs e)
          {
              //if (this.remotree.SelectedNode.Parent == null)
              //{
              //    try { 
              //    GenerateSqlServerDDL(this.remotree.SelectedNode.Text);
              //        }catch(Exception ERROR)
              //    {
              //        MessageBox.Show(ERROR.Message);

              //    }
              //}
              if (this.remotree.SelectedNode.Parent == null)
              {
                  //string ret = ah.GetMethodInfo(this.lablpath.Text, this.dlltree.SelectedNode.Parent.Text, this.dlltree.SelectedNode.Text);
                  this.remotxtsql.Clear();
                  for (int i = 0; i < lmst2.Count; i++)
                  {

                      if (lmst2[i].tab == this.remotree.SelectedNode.Text)
                          this.remotxtsql.AppendText(lmst2[i].sql);
                  }
              }
          }
          private void ScriptOption()
          {
              //scriptOption.ContinueScriptingOnError = true;
              //scriptOption.IncludeIfNotExists = true;
              //scriptOption.NoCollation = true;
              //scriptOption.ScriptDrops = false;
              //scriptOption.ContinueScriptingOnError = true;
              ////scriptOption.DriAllConstraints = true;
              //scriptOption.WithDependencies = false;
              //scriptOption.DriForeignKeys = true;
              //scriptOption.DriPrimaryKey = true;
              //scriptOption.DriDefaults = true;
              //scriptOption.DriChecks = true;
              //scriptOption.DriUniqueKeys = true;
              //scriptOption.Triggers = true;
              //scriptOption.ExtendedProperties = true;
              //scriptOption.NoIdentities = false;
          }

          /// <summary>
          /// 生成数据库类型为SqlServer指定表的DDL
          /// </summary>
          private void GenerateSqlServerDDL(string TAB)
          {
              //对于已经生成过的就不用再次生成了，节约资源。
              if (!string.IsNullOrEmpty(this.remotxtsql.Text) && remotxtsql.Text.Trim().Length > 10)
              {
                  return;
              }

              ScriptOption();
              ServerConnection sqlConnection = null;
              try
              {
                  StringBuilder sbOutPut = new StringBuilder();

                  if (this.remotxt.Text.Contains("integrated security")==false) //Windows身份验证
                  {
                      sqlConnection = new ServerConnection(this.remotxt.Text);
                  }
                  else        //SqlServer身份验证
                  {
                      string[] linkDataArray = this.remotxt.Text.Split(';');
                      string userName = string.Empty;
                      string pwd = string.Empty;
                      foreach (string str in linkDataArray)
                      {
                          if (str.ToLower().Replace(" ", "").Contains("userid="))
                          {
                              userName = str.Split('=')[1];
                          }

                          if (str.ToLower().Replace(" ", "").Contains("password"))
                          {
                              pwd = str.Split('=')[1];
                          }
                      }

                      sqlConnection = new ServerConnection(this.remotxt.Text, userName, pwd);
                  }
                  //Microsoft.SqlServer.Management.Sdk.Sfc.SqlStoreConnection sqlStoreConnection = new Microsoft.SqlServer.Management.Sdk.Sfc.SqlStoreConnection(sqlConnection);
                   
              
               Server sqlServer = new Server(sqlConnection);



               Table table = sqlServer.Databases[sqlConnection.DatabaseName].Tables[TAB];
                
                
                  string ids;
                  //编写表的脚本
                  sbOutPut = new StringBuilder();
                  sbOutPut.AppendLine();
                  ScriptingOptions scriptOption = new ScriptingOptions();
                  scriptOption.ContinueScriptingOnError = true;
                  scriptOption.IncludeIfNotExists = true;
                  scriptOption.NoCollation = true;
                  scriptOption.ScriptDrops = false;
                  scriptOption.ContinueScriptingOnError = true;
                  //scriptOption.DriAllConstraints = true;
                  scriptOption.WithDependencies = false;
                  scriptOption.DriForeignKeys = true;
                  scriptOption.DriPrimaryKey = true;
                  scriptOption.DriDefaults = true;
                  scriptOption.DriChecks = true;
                  scriptOption.DriUniqueKeys = true;
                  scriptOption.Triggers = true;
                  scriptOption.ExtendedProperties = true;
                  scriptOption.NoIdentities = false;
                  System.Collections.Specialized.StringCollection sCollection = table.Script(scriptOption);

                  foreach (String str in sCollection)
                  {
                      //此处修正smo的bug
                      if (str.Contains("ADD  DEFAULT") && str.Contains("') AND type = 'D'"))
                      {
                          ids = str.Substring(str.IndexOf("OBJECT_ID(N'") + "OBJECT_ID(N'".Length, str.IndexOf("') AND type = 'D'") - str.IndexOf("OBJECT_ID(N'") - "OBJECT_ID(N'".Length);
                          sbOutPut.AppendLine(str.Insert(str.IndexOf("ADD  DEFAULT") + 4, "CONSTRAINT " + ids));
                      }
                      else
                          sbOutPut.AppendLine(str);

                      //sbOutPut.AppendLine("GO");
                  }

                  //生成存储过程
                //  this.textEditorDDL.SetCodeEditorContent("SQL", sbOutPut.ToString());
                 // this.textEditorDDL.SaveFileName = this.TableName + ".sql";
                  //sbOutPut = new StringBuilder();
                  this.remotxtsql.Clear();
                  this.remotxtsql.AppendText(sbOutPut.ToString());
              }
              catch (Exception ex)
              {
                  //LogHelper.WriteException(ex);
              }
              finally
              {
                  sqlConnection.Disconnect();
              }
          }

          private void dbtxtlocal_TextChanged(object sender, EventArgs e)
          {

          }

          private void DbView_Load(object sender, EventArgs e)
          {
        
              initImage();
          }
        private  void  initImage()
          {

              ImageList imglst = new ImageList();
              Image addimg = Image.FromFile(Application.StartupPath + "\\img\\新增.bmp");
              Image upimg = Image.FromFile(Application.StartupPath + "\\img\\进入.ico");
            Image delimg = Image.FromFile(Application.StartupPath + "\\img\\删除.bmp");
            Image overimg = Image.FromFile(Application.StartupPath + "\\img\\完成.png");
            imglst.Images.Add("add", addimg);
            imglst.Images.Add("up", upimg);
            imglst.Images.Add("del", delimg);
            imglst.Images.Add("over", overimg);
            this.localtree.ImageList = imglst;
          }

        private void btnbj_Click(object sender, EventArgs e)
        {
            compare("", "");
        }
        private bool compare(string source,string destring)
        {
            bool ret=false;
            try { 
            Microsoft.SqlServer.Dac.Compare.SchemaComparisonResult cr;

            Microsoft.SqlServer.Dac.Compare.SchemaDifference sd;

            Microsoft.SqlServer.Dac.Compare.SchemaCompareDacpacEndpoint sdpc = new Microsoft.SqlServer.Dac.Compare.SchemaCompareDacpacEndpoint("D:\\Database1.dacpac");
            Microsoft.SqlServer.Dac.Compare.SchemaCompareDacpacEndpoint ddpc = new Microsoft.SqlServer.Dac.Compare.SchemaCompareDacpacEndpoint("D:\\dp\\Database1.dacpac");
            Microsoft.SqlServer.Dac.Compare.SchemaCompareEndpoint sal = sdpc as Microsoft.SqlServer.Dac.Compare.SchemaCompareEndpoint;
            Microsoft.SqlServer.Dac.Compare.SchemaCompareEndpoint dsal = ddpc as Microsoft.SqlServer.Dac.Compare.SchemaCompareEndpoint;
            Microsoft.SqlServer.Dac.Compare.SchemaComparison sdb = new Microsoft.SqlServer.Dac.Compare.SchemaComparison(sal, dsal);

            cr = sdb.Compare();
            IEnumerable<Microsoft.SqlServer.Dac.Compare.SchemaDifference> lists = cr.Differences;
            foreach (var o in lists)
            {
                sd = o;
                
            }
                 ret=true;
                }catch(Exception error)
            {
                     ret=false;
                MessageBox.Show(error.Message);
            }
            return ret;
        }
 
    }
   public struct mymodel
    {
        public string tab;
        public string sql;

    }
}
