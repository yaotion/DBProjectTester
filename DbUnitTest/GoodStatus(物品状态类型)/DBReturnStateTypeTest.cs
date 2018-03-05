using GoodManager.DBUtils;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using GoodManager.Entry.GoodStatus_物品状态类型_;
using System.Collections.Generic;
using System.Data;

using NUnit.Framework;  
using System.Data.SqlClient;
using System.IO;
namespace TF.GoodManager.UnitTest
{
    
    
    /// <summary>
    ///这是 DBReturnStateTypeTest 的测试类，旨在
    ///包含所有 DBReturnStateTypeTest 单元测试
    ///</summary>
    //[TestClass()]
     [TestFixture]  
    public class DBReturnStateTypeTest
    {


         public DBReturnStateTypeTest()
         {
             connstr = DatabaseSetup.GetConnectionStringsConfig("MyCon");
             SqlConnection connsql = new SqlConnection(connstr);
             //try
             //{
             //    File.Create("C:\\TESTlog.TXT");
             // string strOldText = File.ReadAllText("C:\\TESTlog.TXT", System.Text.Encoding.Default);

             //    File.AppendAllText("C:\\TESTlog.TXT", connstr, System.Text.Encoding.Default);
             //}
             //catch
             //{
                
             //}
             StreamWriter SW = new StreamWriter("C:\\TEST.TXT");
             try
             {

                 SW.WriteLine("DBReturnStateTypeTest" + connstr);
                 SW.Flush();
                 connsql.Open();
                 bolconn = true;
                 SW.WriteLine(bolconn);
                 SW.Flush();
                 SW.Close();

             }
             catch (Exception error)
             {
                 SW.WriteLine(error.Message);
                 SW.Flush();
                 SW.Close();
                 bolconn = false;
                 if (connsql != null)
                     connsql.Dispose();
             }
             finally
             {
                 connsql.Close();
                 if (connsql != null)
                     connsql.Dispose();
             }
             
         }
        
         public String connstr = String.Empty;
         public bool bolconn = false;
         public String Connstr
         {
             get
             {
                 return connstr;
             }
             set
             {
                 connstr = value;
             }
         }
         public bool Bolconn
         {
             get
             {
                 return bolconn;
             }
             set
             {
                 bolconn = value;
             }
         }
        //private TestContext testContextInstance;

        ///// <summary>
        /////获取或设置测试上下文，上下文提供
        /////有关当前测试运行及其功能的信息。
        /////</summary>
        //public TestContext TestContext
        //{
        //    get
        //    {
        //        return testContextInstance;
        //    }
        //    set
        //    {
        //        testContextInstance = value;
        //    }
        //}

        #region 附加测试特性
        // 
        //编写测试时，还可使用以下特性:
        //
        //使用 ClassInitialize 在运行类中的第一个测试前先运行代码
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //使用 ClassCleanup 在运行完类中的所有测试后再运行代码
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //使用 TestInitialize 在运行每个测试前先运行代码
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //使用 TestCleanup 在运行完每个测试后运行代码
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///DBReturnStateType 构造函数 的测试
        ///</summary>
        //[TestMethod()]
           [Test] 
        public void DBReturnStateTypeConstructorTest()
        {
         //   string ConnectionString = string.Empty; // TODO: 初始化为适当的值
           // ConnectionString = DatabaseSetup.GetConnectionStringsConfig("MyCon"); 
            DBReturnStateType target = new DBReturnStateType(connstr);
            Assert.IsNotNull(target);
            //Assert.Inconclusive("TODO: 实现用来验证目标的代码");
        }

        /// <summary>
        ///GetStateNames 的测试
        ///</summary>
        //[TestMethod()]
           [Test] 
        public void GetStateNamesTest()
        {
            //string ConnectionString = string.Empty; // TODO: 初始化为适当的值
           // ConnectionString = DatabaseSetup.GetConnectionStringsConfig("MyCon"); 
            DBReturnStateType target = new DBReturnStateType(connstr); // TODO: 初始化为适当的值
           // List<ReturnStateType> expected = null; // TODO: 初始化为适当的值
            List<ReturnStateType> actual;
            actual = target.GetStateNames();
            Assert.IsNotNull(target);
            Assert.AreEqual(3, actual.Count);
            //Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetStateNames_DRToModelDTToList 的测试
        ///</summary>
        //[TestMethod()]
           //[Test] 
        public void GetStateNames_DRToModelDTToListTest()
        {
         //   string ConnectionString = string.Empty; // TODO: 初始化为适当的值
            DBReturnStateType target = new DBReturnStateType(connstr); // TODO: 初始化为适当的值
            DataRow dr = null; // TODO: 初始化为适当的值
            ReturnStateType expected = null; // TODO: 初始化为适当的值
            ReturnStateType actual;
            actual = target.GetStateNames_DRToModelDTToList(dr);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetStateNames_DTToList 的测试
        ///</summary>
        //[TestMethod()]
           //[Test] 
        public void GetStateNames_DTToListTest()
        {
           // string ConnectionString = string.Empty; // TODO: 初始化为适当的值
            DBReturnStateType target = new DBReturnStateType(connstr); // TODO: 初始化为适当的值
            DataTable dt = null; // TODO: 初始化为适当的值
            List<ReturnStateType> expected = null; // TODO: 初始化为适当的值
            List<ReturnStateType> actual;
            actual = target.GetStateNames_DTToList(dt);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }
    }
}
