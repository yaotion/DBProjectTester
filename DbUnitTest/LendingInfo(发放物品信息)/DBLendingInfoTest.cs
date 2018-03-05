using GoodManager.DBUtils.DBLendingInfo;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using GoodManager.Entry.GoodsQueryParam_物品查询参数_;
using GoodManager.Entry.LendingInfo_发放物品信息_;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using NUnit.Framework;  
namespace TF.GoodManager.UnitTest
{
    
    
    /// <summary>
    ///这是 DBLendingInfoTest 的测试类，旨在
    ///包含所有 DBLendingInfoTest 单元测试
    ///</summary>
    [TestFixture]
    public class DBLendingInfoTest
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
        public DBLendingInfoTest()
         {
             connstr = DatabaseSetup.GetConnectionStringsConfig("MyCon");
             SqlConnection connsql = new SqlConnection(connstr);
             StreamWriter SW = new StreamWriter("C:\\TEST.TXT");
             try
             {

                 SW.WriteLine("DBGoodTypeTest" + connstr);
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
        ///DBLendingInfo 构造函数 的测试
        ///</summary>
        [Test]
        public void DBLendingInfoConstructorTest()
        {
          //  string ConnectionString = string.Empty; // TODO: 初始化为适当的值
            DBLendingInfo target = new DBLendingInfo(connstr);
            Assert.IsNotNull(target);
            //Assert.Inconclusive("TODO: 实现用来验证目标的代码");
        }

        /// <summary>
        ///DeleteGoods 的测试
        ///</summary>
        [Test]
        public void DeleteGoodsTest()
        {
           // string ConnectionString = string.Empty; // TODO: 初始化为适当的值
            DBLendingInfo target = new DBLendingInfo(connstr); // TODO: 初始化为适当的值
            int LendingType = 0; // TODO: 初始化为适当的值
            string LendingExInfo = string.Empty; // TODO: 初始化为适当的值
            string WorkShopGUID = string.Empty; // TODO: 初始化为适当的值
            LendingExInfo = "532";
            WorkShopGUID = "3b50bf66-dabb-48c0-8b6d-05db80591090";

            target.DeleteGoods(LendingType, LendingExInfo, WorkShopGUID);
            Assert.IsNotNull(target);
          //  Assert.Inconclusive("无法验证不返回值的方法。");
        }

        /// <summary>
        ///IsHaveNotReturnGoods 的测试
        ///</summary>
        [Test]
        public void IsHaveNotReturnGoodsTest()
        {
          // string ConnectionString = string.Empty; // TODO: 初始化为适当的值
            DBLendingInfo target = new DBLendingInfo(connstr); // TODO: 初始化为适当的值
            string TrainmanGUID = string.Empty; // TODO: 初始化为适当的值
            TrainmanGUID = "2305966";
            bool expected = true; // TODO: 初始化为适当的值
            bool actual;
            actual = target.IsHaveNotReturnGoods(TrainmanGUID);
            Assert.IsTrue(actual);
            Assert.AreEqual(expected, actual);
          //  Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///QueryRecord 的测试
        ///</summary>
        [Test]
        public void QueryRecordTest()
        {
           // string ConnectionString = string.Empty; // TODO: 初始化为适当的值
            DBLendingInfo target = new DBLendingInfo(connstr); // TODO: 初始化为适当的值
            GoodsQueryParam GoodsQueryParamact = null; // TODO: 初始化为适当的值

            //定义参数

            GoodsQueryParamact = new GoodsQueryParam();
            GoodsQueryParamact.nLendingNumber =-1;
            GoodsQueryParamact.nLendingType = 0;
            GoodsQueryParamact.nReturnState = 0;
            GoodsQueryParamact.strTrainmanName = "张勇";
            GoodsQueryParamact.strTrainmanNumber = "2300679";
            GoodsQueryParamact.strWorkShopGUID = "3b50bf66-dabb-48c0-8b6d-05db80591090";
            GoodsQueryParamact.dtBeginTime = DateTime.Today.AddDays(-30);
            GoodsQueryParamact.dtEndTime = DateTime.Today;
            List<LendingInfo> expected = null; // TODO: 初始化为适当的值
            List<LendingInfo> actual;
            actual = target.QueryRecord(GoodsQueryParamact);
            Assert.IsNotNull(actual);
            //Assert.AreEqual(expected, actual);
           // Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///QueryRecord_DRToModelDTToList 的测试
        ///</summary>
       // [Test]
        public void QueryRecord_DRToModelDTToListTest()
        {
           // string ConnectionString = string.Empty; // TODO: 初始化为适当的值
            DBLendingInfo target = new DBLendingInfo(connstr); // TODO: 初始化为适当的值
            DataRow dr = null; // TODO: 初始化为适当的值
            LendingInfo expected = null; // TODO: 初始化为适当的值
            LendingInfo actual;
            actual = target.QueryRecord_DRToModelDTToList(dr);
            Assert.AreEqual(expected, actual);
           // Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///QueryRecord_DTToList 的测试
        ///</summary>
      //  [Test]
        public void QueryRecord_DTToListTest()
        {
          //  string ConnectionString = string.Empty; // TODO: 初始化为适当的值
            DBLendingInfo target = new DBLendingInfo(connstr); // TODO: 初始化为适当的值
            DataTable dt = null; // TODO: 初始化为适当的值
            List<LendingInfo> expected = null; // TODO: 初始化为适当的值
            List<LendingInfo> actual;
            actual = target.QueryRecord_DTToList(dt);
            Assert.AreEqual(expected, actual);
           // Assert.Inconclusive("验证此测试方法的正确性。");
        }
    }
}
