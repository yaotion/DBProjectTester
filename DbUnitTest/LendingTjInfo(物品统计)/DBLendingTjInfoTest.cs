using GoodManager.DBUtils.DBLendingTJInfo;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using GoodManager.Entry.LendingTjInfo_物品统计_;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using NUnit.Framework;
namespace TF.GoodManager.UnitTest
{
    
   
    /// <summary>
    ///这是 DBLendingTjInfoTest 的测试类，旨在
    ///包含所有 DBLendingTjInfoTest 单元测试
    ///</summary>
    [TestFixture]
    public class DBLendingTjInfoTest
    {


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
        public DBLendingTjInfoTest()
         {
             connstr = DatabaseSetup.GetConnectionStringsConfig("MyCon");
             SqlConnection connsql = new SqlConnection(connstr);
             StreamWriter SW = new StreamWriter("C:\\TEST.TXT");
             try
             {

                 SW.WriteLine("DBLendingTjInfoTest" + connstr);
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
        ///DBLendingTjInfo 构造函数 的测试
        ///</summary>
        [Test]
        public void DBLendingTjInfoConstructorTest()
        {
            //string ConnectionString = string.Empty; // TODO: 初始化为适当的值
            DBLendingTjInfo target = new DBLendingTjInfo(connstr);
            Assert.IsNotNull(target);
            //Assert.Inconclusive("TODO: 实现用来验证目标的代码");
        }

        /// <summary>
        ///GetTongJiInfo 的测试
        ///</summary>
        [Test]
        public void GetTongJiInfoTest()
        {
          //  string ConnectionString = string.Empty; // TODO: 初始化为适当的值
            DBLendingTjInfo target = new DBLendingTjInfo(connstr); // TODO: 初始化为适当的值
            string strWorkShopGUID = string.Empty; // TODO: 初始化为适当的值
            strWorkShopGUID = "3b50bf66-dabb-48c0-8b6d-05db80591090";
            List<LendingTjInfo> expected = null; // TODO: 初始化为适当的值
            List<LendingTjInfo> actual;
            actual = target.GetTongJiInfo(strWorkShopGUID);
            //Assert.AreEqual(expected, actual);
            Assert.IsNotNull(actual);
           // Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetTongJiInfo_DRToModelDTToList 的测试
        ///</summary>
       // [Test]
        public void GetTongJiInfo_DRToModelDTToListTest()
        {
          //  string ConnectionString = string.Empty; // TODO: 初始化为适当的值
            DBLendingTjInfo target = new DBLendingTjInfo(connstr); // TODO: 初始化为适当的值
            DataRow dr = null; // TODO: 初始化为适当的值
            LendingTjInfo expected = null; // TODO: 初始化为适当的值
            LendingTjInfo actual;
            actual = target.GetTongJiInfo_DRToModelDTToList(dr);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetTongJiInfo_DTToList 的测试
        ///</summary>
        //[Test]
        public void GetTongJiInfo_DTToListTest()
        {
           // string ConnectionString = string.Empty; // TODO: 初始化为适当的值
            DBLendingTjInfo target = new DBLendingTjInfo(connstr); // TODO: 初始化为适当的值
            DataTable dt = null; // TODO: 初始化为适当的值
            List<LendingTjInfo> expected = null; // TODO: 初始化为适当的值
            List<LendingTjInfo> actual;
            actual = target.GetTongJiInfo_DTToList(dt);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetWorkname 的测试
        ///</summary>
        [Test]
        public void GetWorknameTest()
        {
           // string ConnectionString = string.Empty; // TODO: 初始化为适当的值
            DBLendingTjInfo target = new DBLendingTjInfo(connstr); // TODO: 初始化为适当的值
            string id = string.Empty; // TODO: 初始化为适当的值
            id = "3b50bf66-dabb-48c0-8b6d-05db80591090";
            string expected = string.Empty; // TODO: 初始化为适当的值
            expected="唐山车间";
            string actual;
            actual = target.GetWorkname(id);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("验证此测试方法的正确性。");
        }
    }
}
