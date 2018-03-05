using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
 using System.Data.SqlClient;
using System.IO;
using Microsoft.SqlServer.Dac;
using Microsoft.SqlServer.Management;
using Microsoft.SqlServer.Management.Common;
using System.Collections;
using System.Text.RegularExpressions;
namespace DbUnitTest2000
{
    public delegate void EventOnShowStringHandler(string ip);
    public partial class frmmsg : Form
    {
        public event EventOnShowStringHandler OnShowString;
        public static string pubstr = "";
        public frmmsg()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string newconfig = AppConfig.GetConnectionStringsConfig("MyCon");
            string[] arrstr = newconfig.Split(';');
            this.txbServer.Text = pubstr;
            if (string.IsNullOrEmpty(this.txbServer.Text))
                this.txbServer.Text = arrstr[0].Replace("Data Source=", "");

            this.txbDbName.Text = arrstr[1].Replace("Initial Catalog=", "");
            this.txbUserName.Text = arrstr[3].Replace("User ID=", "");
            this.txbPwd.Text = arrstr[4].Replace("Password=", "");
        }
        public static bool drdb(string ipname, string dbname, string user, string password, string filename )
        {

            bool ret = false;


             SqlConnection sqlConnection = new SqlConnection("Data Source=" + ipname + ";Initial Catalog=" +dbname + ";Persist Security Info=True;User ID=" +user + ";Password=" + password + ";min pool size=1;max pool size=50;Pooling=true");
            Stream fs = null;
            Microsoft.SqlServer.Dac.DacPackage dactype = null;
            try
            {
               // ServerConnection serverconn = new ServerConnection(sqlConnection);
               // serverconn.Connect();
                string dacfile =filename;
                  fs = File.Open(dacfile, FileMode.OpenOrCreate) as Stream;
 
                  dactype = Microsoft.SqlServer.Dac.DacPackage.Load(fs, DacSchemaModelStorageType.Memory);
              string BNAME=  dactype.Name;
          
                Version vs = dactype.Version;

                // Deploy the DAC and create the database.
               // string dacName = "";
               // bool evaluateTSPolicy = true;
              //  Microsoft.SqlServer.Management.Sdk.Sfc.SqlStoreConnection sqlStoreConnection = new Microsoft.SqlServer.Management.Sdk.Sfc.SqlStoreConnection(serverconn.SqlConnectionObject);
               // sqlStoreConnection.Connect();
                
           
                Microsoft.SqlServer.Dac.DacServices newDacStore = new Microsoft.SqlServer.Dac.DacServices(sqlConnection.ConnectionString);
               //Microsoft.SqlServer.Dac.DacAzureDatabaseSpecification dbversion = new DacAzureDatabaseSpecification();
             
               // Microsoft.SqlServer.Dac.DeploymentPropertyAliasAttribute deployProperties = new Microsoft.SqlServer.Dac.DeploymentPropertyAliasAttribute("mydata");
               
                //先卸载，然后重新安装部署
                //newDacStore.Unregister("Database1");
               // PublishOptions  pop=new PublishOptions();
               // DacDeployOptions ddp = new DacDeployOptions();
               // pop.GenerateDeploymentScript = false;
               // pop.GenerateDeploymentReport = false;
                DacDeployOptions  dacde=new DacDeployOptions();
                dacde.CommandTimeout=300;
              //  dacde.DatabaseSpecification.Edition = DacAzureEdition.Basic;
                dacde.CreateNewDatabase = true;
                dacde.AllowIncompatiblePlatform = true;
               // newDacStore.Unregister("Database1");
                newDacStore.Deploy(dactype, BNAME, true, dacde, null);
                fs.Close();
                fs.Dispose();
                //dactype.Dispose();
                
               // newDacStore.Publish(dactype,"Database1",pop);
               // newDacStore.Deploy(dactype, "Database1", false, null, null);
               // serverconn.Cancel();
               // serverconn.Disconnect();
            //    sqlStoreConnection.Disconnect();


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
        }
        /// <summary>
        /// 导入数据
        /// </summary>
        private void dodata(string dbname)
        {
            // string newconfig = AppConfig.GetConnectionStringsConfig("MyCon");
            SqlConnection sqlconn = TestConnection(this.txbServer.Text, dbname, this.txbUserName.Text, this.txbPwd.Text);
            CreateStructureAndData(sqlconn,dbname);

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
        public void CreateStructureAndData(SqlConnection connection,string dbname)
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


                    connection.ChangeDatabase(dbname);

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
                        this.richTextBox1.AppendText("正在导入数据..." + sqlItem + "\n\r");
                    }
                }
                else
                {
                    isHaveError = true;
                }
                if (true == isHaveError)
                {
                    CloseConnection(connection);
                    if(command!=null)
                    command.Dispose();
                    // throw new InstallException("数据库配置失败！\n请与开发人员联系2！");
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
                CloseConnection(connection);
                if (command != null)
                command.Dispose();
                //  throw new InstallException("数据库配置失败！\n请与开发人员联系1！");
            }
        }
        private void button1_Click(object sender, EventArgs e)
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
            SqlConnection sqlConnection = new SqlConnection("Data Source=" + this.txbServer.Text + ";Initial Catalog=" + "master" + ";Persist Security Info=True;User ID=" + txbUserName.Text + ";Password=" + txbPwd.Text + ";min pool size=1;max pool size=50;Pooling=true");
            Stream fs = null;
            try
            {
               
                button1.Enabled = false;
                this.richTextBox1.Clear();
                this.richTextBox1.AppendText("开始发布中，请稍候。。。。。");
                string dacfile = this.txtfile.Text;
                  fs = File.Open(dacfile, FileMode.OpenOrCreate) as Stream;
                
                Microsoft.SqlServer.Dac.DacPackage dactype = Microsoft.SqlServer.Dac.DacPackage.Load(fs, DacSchemaModelStorageType.Memory);
                string BNAME = this.txbDbName.Text;// dactype.Name;
          
               // Version vs = dactype.Version;
             
                Microsoft.SqlServer.Dac.DacServices newDacStore = new Microsoft.SqlServer.Dac.DacServices(sqlConnection.ConnectionString);
              
                //先卸载，然后重新安装部署
             
                DacDeployOptions  dacde=new DacDeployOptions();
                dacde.CommandTimeout=300;
              
                dacde.CreateNewDatabase = true;
                dacde.AllowIncompatiblePlatform = true;
               
                newDacStore.Deploy(dactype, BNAME, true, dacde, null);
                fs.Close();
                fs.Dispose();
                this.richTextBox1.AppendText("架构发布完成\n\r");
                this.richTextBox1.AppendText("开始导入数据中，稍候。。。。。。\n\r");
                dodata(BNAME);
                this.richTextBox1.AppendText("导入数据结束");
                button1.Enabled = true;
                AppConfig.ConfigSetValue("DBUnitTest2000.exe", "MyCon", "Data Source=" + txbServer.Text + ";Initial Catalog=" + BNAME + ";Persist Security Info=True;User ID=" + txbUserName.Text + ";Password=" + txbPwd.Text + ";min pool size=1;max pool size=50;Pooling=true");

         


            }
            catch (Exception error)
            {
                if(fs!=null)
                { 
                 fs.Close();
                fs.Dispose();
                }
                button1.Enabled = true;
                MessageBox.Show(error.Message);
            }
           
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

        private void btnclose_Click(object sender, EventArgs e)
        {
            AppConfig.ConfigSetValue("DBUnitTest2000.exe", "MyCon", "Data Source=" + txbServer.Text + ";Initial Catalog=" + txbDbName.Text + ";Persist Security Info=True;User ID=" + txbUserName.Text + ";Password=" + txbPwd.Text + ";min pool size=1;max pool size=50;Pooling=true");

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
                        if(fs!=null)
                        {
                            fs.Close();
                            fs.Dispose();
                        }
                        MessageBox.Show(error.Message);
                    }
                }
            }
        }

        private void frmmsg_FormClosing(object sender, FormClosingEventArgs e)
        {
            pubstr = this.txbServer.Text;
             OnShowString(this.txbServer.Text);
        }
    }
}
