using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.IO;
using System.Xml;
using System.Data.SqlClient;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Dac;
using System.Collections;
using System.Text.RegularExpressions;
using System.Reflection;
using System.Resources;
 using Microsoft.SqlServer.Management;
 

 
 
namespace DbUnitTest2000
{
     //public delegate void EventOnShowStringHandler(string ip);
    public partial class FrmDbDeploy : Form
    {
        //public event EventOnShowStringHandler OnShowString;
        public static string pubstr = "";
        public FrmDbDeploy()
        {
            InitializeComponent();
            pubfolder = Application.StartupPath + "\\";
            currentDomain.AssemblyResolve += new ResolveEventHandler(MyResolveEventHandler);
        }
        AppDomain currentDomain = AppDomain.CurrentDomain;

        public static string pubfolder = "";
        public static Assembly MyResolveEventHandler(object sender, ResolveEventArgs args)
        {
            string strFielName = args.Name.Split(',')[0];
            MessageBox.Show(strFielName);
            return Assembly.LoadFrom(string.Format(pubfolder + "{0}.dll", strFielName));
        }
        private void btntest_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txbServer.Text))
            {

                MessageBox.Show("服务器信息不能为空", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(txbUserName.Text))
            {

                MessageBox.Show("数据库名不能为空", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(txbPwd.Text))
            {

                MessageBox.Show("密码信息不能为空", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string serverName = txbServer.Text.Trim();

            string dbName = txbDbName.Text.Trim();

            string userName = txbUserName.Text.Trim();

            string password = txbPwd.Text.Trim();

            bool isConnect = TestConnectionb(serverName, dbName, userName, password);//测试连接,此处调用其它类中的代码。
            if (isConnect == true)
            {
                MessageBox.Show("数据库连接测试成功。", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
                // MessageBox.Show("数据库连接测试成功");
            }
            else
            {
                MessageBox.Show("数据库连接测试失败。", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
                //MessageBox.Show("数据库连接测试失败!");

            }
        }
        /// <summary>
        /// 导入数据
        /// </summary>
        private void dodata()
        {
           // string newconfig = AppConfig.GetConnectionStringsConfig("MyCon");
            SqlConnection sqlconn = TestConnection(this.txbServer.Text, this.txbDbName.Text, this.txbUserName.Text, this.txbPwd.Text);
            CreateStructureAndData(sqlconn);

        }
        /// <summary>
        /// 测试连接
        /// </summary>
        /// <param name="serverName"></param>
        /// <param name="dbName"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        public SqlConnection TestConnection(string serverName, string dbName, string userName, string password)
        {
            string connectionString = GetConnectionString(serverName, dbName, userName, password);
            connectionString = AppConfig.GetConnectionStringsConfig("MyCon");
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                if (connection.State != System.Data.ConnectionState.Open)
                {
                    connection.Open();
                    //connection.Dispose();

                }

            }
            catch
            {
                CloseConnection(connection);
                //  throw new InstallException("安装失败!\n数据库配置有误,请正确配置信息！");
            }
            return connection;
        }
        /// <summary>
        /// 分隔SQL语句
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public string[] splitSql(string sql)
        {
            Regex regex = new Regex("^GO", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            string[] sqlList = regex.Split(sql.ToUpper());
            return sqlList;
        }

        public List<DictionaryEntry> ReadSQL(string filepath)
        {
            List<DictionaryEntry> deitem = new List<DictionaryEntry>();
            DirectoryInfo dif = new DirectoryInfo(filepath);
            if (dif.Exists)
            {
                FileInfo[] filelst = dif.GetFiles("*.sql");
                for (int i = 0; i < filelst.Length; i++)
                {

                    StreamReader sr = filelst[i].OpenText();
                    DictionaryEntry objde = new DictionaryEntry();
                    string nextLine;
                    StringBuilder sb = new System.Text.StringBuilder();
                    while ((nextLine = sr.ReadLine()) != null)
                    {
                        sb.Append(nextLine + Environment.NewLine);
                    }
                    sr.Close();
                    sr.Dispose();
                    objde.Key = filelst[i].Name;
                    objde.Value = sb.ToString();
                    deitem.Add(objde);

                }
            }
            return deitem;

        }
        /// <summary>
        /// 创建表结构及数据
        /// </summary>
        /// <param name="connection"></param>
        public void CreateStructureAndData(SqlConnection connection)
        {
            StringBuilder builder = new StringBuilder();
            SqlCommand command = null;
            //错误标志
            bool isHaveError = false;
            try
            {
                List<DictionaryEntry> manager = ReadSQL(Application.StartupPath + "\\GoodManagerDbUnitTest\\TF.GoodManager.Data");

                if (manager.Count > 0)
                {


                    connection.ChangeDatabase(txbDbName.Text.Trim());

                    command = connection.CreateCommand();
                    command.CommandType = System.Data.CommandType.Text;
                    for (int ii = 0; ii < manager.Count; ii++)
                    {
                        //  MessageBox.Show(item.Key.ToString());

                        //MessageBox.Show(item.Value.ToString());_StructureAndDataFileName
                        builder.Append(manager[ii].Value.ToString());

                    }


                    string[] sqlList = splitSql(builder.ToString());
                    foreach (string sqlItem in sqlList)
                    {
                        Application.DoEvents();
                        try
                        {
                            if (sqlItem.Length > 2)
                            {
                                command.CommandText = sqlItem;
                                command.ExecuteNonQuery();
                            }
                        }
                        catch (Exception error)
                        {
                            //MessageBox.Show(error.Message);
                            continue;
                        }
                        this.richTextBox1.AppendText("正在导入数据..."+sqlItem+"\n\r");
                    }
                }
                else
                {
                    isHaveError = true;
                }
                if (true == isHaveError)
                {
                    CloseConnection(connection);
                    command.Dispose();
                    // throw new InstallException("数据库配置失败！\n请与开发人员联系2！");
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
                CloseConnection(connection);
                command.Dispose();
                //  throw new InstallException("数据库配置失败！\n请与开发人员联系1！");
            }
        }
        private void btnfb_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txbServer.Text))
            {

                MessageBox.Show("服务器信息不能为空", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(txbUserName.Text))
            {

                MessageBox.Show("数据库名不能为空", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(txbPwd.Text))
            {

                MessageBox.Show("密码信息不能为空", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(txtfile.Text))
            {

                MessageBox.Show("选择文件名不能为空", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //this.btnfb.Text = "发布中";
             this.btnfb.Enabled = false;
           // this.richTextBox1.Clear();
           // this.richTextBox1.AppendText("开始发布,请耐心等待。。。。。。" + "\n\r");
           
            //this.dosqldb();
            //this.dodata();
            this.richTextBox1.Clear();
            this.richTextBox1.AppendText("开始更新,请耐心等待。。。。。。\r\n");
            bool bret = DeployDb(txbServer.Text, txbDbName.Text, txbUserName.Text, txbPwd.Text, this.txtfile.Text);
            if (bret)
            {
               // dodata();
               this.richTextBox1.AppendText("更新成功！");
            }
            AppConfig.ConfigSetValue("DBUnitTest2000.exe", "MyCon", "Data Source=" + txbServer.Text + ";Initial Catalog=" + txbDbName.Text + ";Persist Security Info=True;User ID=" + txbUserName.Text + ";Password=" + txbPwd.Text + ";min pool size=1;max pool size=50;Pooling=true");

            this.btnfb.Enabled = true;
            //this.btnfb.Text = "发布";
        }
        /// <summary>
        /// 发布数据库到服务器
        /// </summary>
        /// <param name="ipname"></param>
        /// <param name="dbname"></param>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <param name="filename"></param>
        /// <returns></returns>
        private bool DeployDb(string ipname, string dbname, string user, string password, string filename)
        {
            bool ret = false;

            string sqlConnection = "Data Source=" + ipname + ";Initial Catalog=master;Persist Security Info=True;User ID=" + user + ";Password=" + password + ";min pool size=1;max pool size=50;Pooling=true";
            Stream fs = null;
            Microsoft.SqlServer.Dac.DacPackage dactype = null;
            try
            {
                string dacfile = filename;
                fs = File.Open(dacfile, FileMode.OpenOrCreate) as Stream;
                dactype = Microsoft.SqlServer.Dac.DacPackage.Load(fs, DacSchemaModelStorageType.Memory);
              
                string BNAME = dactype.Name;//数据库名
                Version vs = dactype.Version;//版本
                Microsoft.SqlServer.Dac.DacServices newDacStore = new Microsoft.SqlServer.Dac.DacServices(sqlConnection);

                DacDeployOptions dacde = new DacDeployOptions();
                dacde.CommandTimeout = 300;
                //  dacde.DatabaseSpecification.Edition = DacAzureEdition.Basic;
                //dacde.CreateNewDatabase = true;
                dacde.CreateNewDatabase = false;
                dacde.AllowIncompatiblePlatform = true;
                dacde.BlockOnPossibleDataLoss = false;
             
                // newDacStore.Unregister("Database1");
                newDacStore.Deploy(dactype, BNAME, true, dacde, null);
                fs.Close();
                fs.Dispose();
                dactype.Dispose();


                ret = true;

            }
            catch (Exception error)
            {
                if (dactype != null)
                    dactype = null;
                if (fs != null)
                {
                    fs.Close();
                    fs.Dispose();
                }
                MessageBox.Show(error.Message);
                ret = false;
            }
            return ret;

            // DacPackage dp = Microsoft.SqlServer.Dac.DacPackage.Load("d:\\mysqldb.dacpac");
            // dactype.Unpack("d:\\dp");
            //string d = dactype.Description;
            //Version v = dactype.Version;
            //string n = dactype.Name;
            //Microsoft.SqlServer.Dac.Model.ModelLoadOptions mlo = new Microsoft.SqlServer.Dac.Model.ModelLoadOptions();
            //mlo.ModelStorageType = DacSchemaModelStorageType.Memory;
            //var model = Microsoft.SqlServer.Dac.Model.TSqlModel.LoadFromDacpac(fs, mlo);
            //foreach (var s in new Microsoft.SqlServer.Dac.Model.ModelTypeClass[] { Microsoft.SqlServer.Dac.Model.ModelSchema.Table, Microsoft.SqlServer.Dac.Model.ModelSchema.View, Microsoft.SqlServer.Dac.Model.ModelSchema.Procedure })
            //{
            //    var allTables = model.GetObjects(Microsoft.SqlServer.Dac.Model.DacQueryScopes.UserDefined, s);
            //    var tableScripts = from t in allTables
            //                       select t;
            //    foreach (var x in tableScripts)
            //    {


            //        string on = x.ObjectType.Name;//类型
            //        string nm = x.Name.Parts[1];//名字
            //        string jb = x.GetScript();

            //        //    int id=0;
            //        foreach (var c in x.GetChildren())
            //        {
            //            // writer.WriteStartElement("QueryObjectCols");
            //            // writer.WriteElementString("Title",c.Name.Parts[2]);
            //            //  writer.WriteElementString("ObjColID",id++.ToString());
            //            // writer.WriteElementString("Field",c.Name.Parts[2]);
            //            string field = c.Name.Parts[2].ToString();
            //           // string fieldtype = c.ObjectType.ToString();
            //            string valtype = c.GetReferenced(Microsoft.SqlServer.Dac.Model.Column.DataType).First().Name.Parts[0];

            //            // writer.WriteElementString("Width","80");
            //            //writer.WriteElementString("Sortable","1");
            //            // if(s==Microsoft.SqlServer.Dac.Model.ModelSchema.Procedure)//如果是存储过程
            //            // writer.WriteElementString("ValueType",c.GetReferenced(Microsoft.SqlServer.Dac.Model.Parameter.DataType).First().Name.Parts[0]);
            //            //else
            //            // writer.WriteElementString("ValueType",c.GetReferenced().First().GetReferenced(Microsoft.SqlServer.Dac.Model.Column.DataType).First().Name.Parts[0]);
            //            //writer.WriteElementString("ShowOrder","1");


            //        }


            //    }

            //}



            //  Microsoft.SqlServer.Dac.TSqlModelUtils.CalculatePlatformCompatibility()
            // var model = new Microsoft.SqlServer.Dac.TSqlModelUtils.;//             (@"D:\kljob\CardLan\CardLanDB\bin\Debug\cardlandb.dacpac");
            //  string j = dactype.PostDeploymentScript;
        }
        /// <summary>
        /// 测试连接
        /// </summary>
        /// <param name="serverName"></param>
        /// <param name="dbName"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool TestConnectionb(string serverName, string dbName, string userName, string password)
        {
            bool r = false;
            string connectionString = GetConnectionString(serverName, dbName, userName, password);
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                if (connection.State != System.Data.ConnectionState.Open)
                {
                    connection.Open();
                    connection.Dispose();

                }
                r = true;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
                CloseConnection(connection);
                r = false;


            }
            return r;
        }
        /// <summary>
        /// 关闭数据库
        /// </summary>
        /// <param name="connection"></param>
        private void CloseConnection(SqlConnection connection)
        {
            if (connection != null)
            {
                //关闭数据库
                if (connection.State != System.Data.ConnectionState.Closed)
                {
                    connection.Close();
                    connection.Dispose();
                }
            }
        }
        /// <summary>
        /// 得到连接字符串
        /// </summary>
        /// <param name="serverName"></param>
        /// <param name="dbName"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public string GetConnectionString(string serverName, string dbName, string userName, string password)
        {
            string connectionString = "Data Source={0};Initial Catalog={1};User ID={2};Password={3}";
            connectionString = string.Format(connectionString, serverName, dbName, userName, password);
            return connectionString;
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            myopenFileDialog.Filter = "数据库文件(*.DACPAC)|*.dacpac";
            DialogResult dr = myopenFileDialog.ShowDialog();
            if (dr == DialogResult.OK)
            {
                this.txtfile.Text = myopenFileDialog.FileName;
                if (!string.IsNullOrEmpty(this.txtfile.Text))
                {

                    Stream fs = null;
                    try
                    {


                        string dacfile = this.txtfile.Text;
                        fs = File.Open(dacfile, FileMode.OpenOrCreate) as Stream;

                        Microsoft.SqlServer.Dac.DacPackage dactype = Microsoft.SqlServer.Dac.DacPackage.Load(fs, DacSchemaModelStorageType.Memory);
                       
                        this.txbDbName.Text = dactype.Name;
                        fs.Close();
                        fs.Dispose();
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
            }
        }

        private void FrmDbDeploy_Load(object sender, EventArgs e)
        {
            string newconfig = AppConfig.GetConnectionStringsConfig("MyCon");
            string[] arrstr = newconfig.Split(';');
         //   this.txbServer.Text = pubstr;
            if (string.IsNullOrEmpty(this.txbServer.Text))
                this.txbServer.Text = arrstr[0].Replace("Data Source=","");

            this.txbDbName.Text = arrstr[1].Replace("Initial Catalog=", "");
            this.txbUserName.Text = arrstr[3].Replace("User ID=", "");
            this.txbPwd.Text = arrstr[4].Replace("Password=", "");
        }

        private void FrmDbDeploy_FormClosing(object sender, FormClosingEventArgs e)
        {
            pubstr = this.txbServer.Text;
          //  OnShowString(this.txbServer.Text);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DbView dv = new DbView();
            dv.ShowDialog();
        }
    }
}
