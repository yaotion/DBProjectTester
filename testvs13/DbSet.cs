using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace DbUnitTest2000
{
    public delegate void oneventConnstr(string ip);
    public partial class DbSet : Form
    {
        public event oneventConnstr OnString;
        public DbSet()
        {
            InitializeComponent();
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
            if (string.IsNullOrEmpty(this.txtserver.Text))
            {

                MessageBox.Show("服务器信息不能为空", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(this.txtuser.Text))
            {

                MessageBox.Show("数据库名不能为空", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(this.txtpass.Text))
            {

                MessageBox.Show("密码信息不能为空", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string serverName = this.txtserver.Text.Trim();

            string dbName = this.comdb.Text.Trim();

            string userName = this.txtuser.Text.Trim();

            string password = this.txtpass.Text.Trim();
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
        private List<string> GetDatabaseNames(SqlConnection conn)
        {

            SqlCommand comm = new SqlCommand("SELECT name FROM sys.databases where database_id>4  ", conn);

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

            catch(Exception  error)
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

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            string serverName = this.txtserver.Text.Trim();

            string dbName = "master";

            string userName = this.txtuser.Text.Trim();

            string password = this.txtpass.Text.Trim();
            string connectionString = GetConnectionString(serverName, dbName, userName, password);
            SqlConnection connsql = new SqlConnection(connectionString);
          List<string> strdb=  GetDatabaseNames(connsql);
          strdb.Sort();
          this.comdb.Items.Clear();
            for(int i=0;i<strdb.Count;i++)
            {
                this.comdb.Items.Add(strdb[i]);
            }
            if(this.comdb.Items.Count>0)
            this.comdb.SelectedIndex = 0;
        }

        private void DbSet_Load(object sender, EventArgs e)
        {

        }

        private void DbSet_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void DbSet_FormClosing(object sender, FormClosingEventArgs e)
        {
         
        }

        private void btnsel_Click(object sender, EventArgs e)
        {
            string serverName = this.txtserver.Text.Trim();

            string dbName = this.comdb.Text;

            string userName = this.txtuser.Text.Trim();

            string password = this.txtpass.Text.Trim();
            this.btnsel.Text = "执行中";
            string connectionString = GetConnectionString(serverName, dbName, userName, password);
            OnString(connectionString);
          
            this.Hide();
            this.Close();
        }
    }
}
