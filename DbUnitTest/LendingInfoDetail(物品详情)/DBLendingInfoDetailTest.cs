using GoodManager.DBUtils.DBLendingInfoDetail;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using GoodManager.Entry.LendingInfoDetail_物品详情_;
using System.Collections.Generic;
using System.Data;
using GoodManager.Entry.GoodsDetailQueryParam_物品详细参数_;
using System.IO;
using System.Data.SqlClient;
using NUnit.Framework;  
namespace TF.GoodManager.UnitTest
{
    
     
    /// <summary>
    ///这是 DBLendingInfoDetailTest 的测试类，旨在
    ///包含所有 DBLendingInfoDetailTest 单元测试
    ///</summary>
    [TestFixture]
    public class DBLendingInfoDetailTest
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
        public DBLendingInfoDetailTest()
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
        ///DBLendingInfoDetail 构造函数 的测试
        ///</summary>
        [Test]
        public void DBLendingInfoDetailConstructorTest()
        {
          //  string ConnectionString = string.Empty; // TODO: 初始化为适当的值
            DBLendingInfoDetail target = new DBLendingInfoDetail(connstr);
            Assert.IsNotNull(target);
          //  Assert.Inconclusive("TODO: 实现用来验证目标的代码");
        }

        /// <summary>
        ///AddLendingDetails 的测试
        ///</summary>
        [Test]
        public void AddLendingDetailsTest()
        {
          //  string ConnectionString = string.Empty; // TODO: 初始化为适当的值
            DBLendingInfoDetail target = new DBLendingInfoDetail(connstr); // TODO: 初始化为适当的值
            List<LendingInfoDetail> lifd = null; // TODO: 初始化为适当的值
            lifd = new List<LendingInfoDetail>();
            LendingInfoDetail newmodel = new LendingInfoDetail();
            newmodel.dtBorrwoTime = DateTime.Today;
            newmodel.dtModifyTime = DateTime.Today;
            newmodel.nBorrowVerifyType = 0;
            newmodel.nKeepMunites = 20;
            newmodel.nLendingType = 0;
            newmodel.nReturnState = 1;
            newmodel.strBorrowVerifyTypeName = "1";
            newmodel.strGiveBackTrainmanGUID = "08809D42-3B1C-4318-B818-756A7ED04300";
            newmodel.strGiveBackTrainmanName = "张勇";
            newmodel.strGiveBackTrainmanNumber = "2300679";
            newmodel.strGiveBackVerifyTypeName = "1";
            newmodel.strGUID = Guid.NewGuid().ToString();
            newmodel.strLenderGUID = "";
            newmodel.strLenderName = "";
            newmodel.strLenderNumber = "";
            newmodel.strLendingExInfo = 420;
            newmodel.strLendingInfoGUID = "";
            newmodel.strLendingTypeAlias = "";
            newmodel.strLendingTypeName = "";
            newmodel.strStateName = "";
            newmodel.strTrainmanGUID = "08809D42-3B1C-4318-B818-756A7ED04300";
            newmodel.strTrainmanName = "张勇";
            newmodel.strTrainmanNumber = "2300679";
            newmodel.strWorkShopGUID = "3b50bf66-dabb-48c0-8b6d-05db80591090";
            lifd.Add(newmodel);
            target.AddLendingDetails(lifd);

            Assert.IsNotNull(lifd);
            //Assert.Inconclusive("无法验证不返回值的方法。");
        }

        /// <summary>
        ///CheckLendAble 的测试
        ///</summary>
        [Test]
        public void CheckLendAbleTest()
        {
          //  string ConnectionString = string.Empty; // TODO: 初始化为适当的值
            DBLendingInfoDetail target = new DBLendingInfoDetail(connstr); // TODO: 初始化为适当的值
            LendingInfoDetail newmodel = null; // TODO: 初始化为适当的值

            string strWorkShop = string.Empty; // TODO: 初始化为适当的值
            strWorkShop = "3b50bf66-dabb-48c0-8b6d-05db80591090";
            newmodel = new LendingInfoDetail();
            newmodel.dtBorrwoTime = DateTime.Today;
            newmodel.dtModifyTime = DateTime.Today;
            newmodel.nBorrowVerifyType = 0;
            newmodel.nKeepMunites = 20;
            newmodel.nLendingType = 0;
            newmodel.nReturnState = 1;
            newmodel.strBorrowVerifyTypeName = "1";
            newmodel.strGiveBackTrainmanGUID = "08809D42-3B1C-4318-B818-756A7ED04300";
            newmodel.strGiveBackTrainmanName = "张勇";
            newmodel.strGiveBackTrainmanNumber = "2300679";
            newmodel.strGiveBackVerifyTypeName = "1";
            newmodel.strGUID = Guid.NewGuid().ToString();
            newmodel.strLenderGUID = "";
            newmodel.strLenderName = "";
            newmodel.strLenderNumber = "";
            newmodel.strLendingExInfo = 420;
            newmodel.strLendingInfoGUID = "";
            newmodel.strLendingTypeAlias = "";
            newmodel.strLendingTypeName = "";
            newmodel.strStateName = "";
            newmodel.strTrainmanGUID = "08809D42-3B1C-4318-B818-756A7ED04300";
            newmodel.strTrainmanName = "张勇";
            newmodel.strTrainmanNumber = "2300679";
            newmodel.strWorkShopGUID = "3b50bf66-dabb-48c0-8b6d-05db80591090";
            strWorkShop = "3b50bf66-dabb-48c0-8b6d-05db80591090";
            bool expected = true; // TODO: 初始化为适当的值
            bool actual;
            actual = target.CheckLendAble(newmodel, strWorkShop);
            Assert.AreEqual(expected, actual);
           // Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///CheckReturnAble 的测试
        ///</summary>
        [Test]
        public void CheckReturnAbleTest()
        {
           // string ConnectionString = string.Empty; // TODO: 初始化为适当的值
            DBLendingInfoDetail target = new DBLendingInfoDetail(connstr); // TODO: 初始化为适当的值
            string TrainmanGUID = string.Empty; // TODO: 初始化为适当的值
            TrainmanGUID = "08809D42-3B1C-4318-B818-756A7ED04300";
            LendingInfoDetail newmodel = null; // TODO: 初始化为适当的值
              newmodel = new LendingInfoDetail();
            newmodel.dtBorrwoTime = DateTime.Today;
            newmodel.dtModifyTime = DateTime.Today;
            newmodel.nBorrowVerifyType = 0;
            newmodel.nKeepMunites = 20;
            newmodel.nLendingType = 0;
            newmodel.nReturnState = 1;
            newmodel.strBorrowVerifyTypeName = "1";
            newmodel.strGiveBackTrainmanGUID = "08809D42-3B1C-4318-B818-756A7ED04300";
            newmodel.strGiveBackTrainmanName = "张勇";
            newmodel.strGiveBackTrainmanNumber = "2300679";
            newmodel.strGiveBackVerifyTypeName = "1";
            newmodel.strGUID = Guid.NewGuid().ToString();
            newmodel.strLenderGUID = "";
            newmodel.strLenderName = "";
            newmodel.strLenderNumber = "";
            newmodel.strLendingExInfo = 420;
            newmodel.strLendingInfoGUID = "";
            newmodel.strLendingTypeAlias = "";
            newmodel.strLendingTypeName = "";
            newmodel.strStateName = "";
            newmodel.strTrainmanGUID = "08809D42-3B1C-4318-B818-756A7ED04300";
            newmodel.strTrainmanName = "张勇";
            newmodel.strTrainmanNumber = "2300679";
            newmodel.strWorkShopGUID = "3b50bf66-dabb-48c0-8b6d-05db80591090";
            bool expected = true; // TODO: 初始化为适当的值
            bool actual;
            actual = target.CheckReturnAble(TrainmanGUID, newmodel);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetLender 的测试
        ///</summary>
        [Test]
        public void GetLenderTest()
        {
           // string ConnectionString = string.Empty; // TODO: 初始化为适当的值
            DBLendingInfoDetail target = new DBLendingInfoDetail(connstr); // TODO: 初始化为适当的值
            string num = string.Empty; // TODO: 初始化为适当的值
            num = "2302715";
            DataTable expected = null; // TODO: 初始化为适当的值

            DataTable actual;
            actual = target.GetLender(num);
           // Assert.AreEqual(expected, actual);
            Assert.IsNotNull(actual);
            //Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetTrainmanGuid 的测试
        ///</summary>
        [Test]
        public void GetTrainmanGuidTest()
        {
            //string ConnectionString = string.Empty; // TODO: 初始化为适当的值
            DBLendingInfoDetail target = new DBLendingInfoDetail(connstr); // TODO: 初始化为适当的值
            string num = string.Empty; // TODO: 初始化为适当的值
            num = "0CC1604A-D94A-4A27-8A5A-C9D021E8AE75";
            DataTable expected = null; // TODO: 初始化为适当的值
            DataTable actual;
            actual = target.GetTrainmanGuid(num);
            Assert.IsNotNull(actual);
           // Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetTrainmanNotReturnLendingInfo 的测试
        ///</summary>
        [Test]
        public void GetTrainmanNotReturnLendingInfoTest()
        {
            //string ConnectionString = string.Empty; // TODO: 初始化为适当的值
            DBLendingInfoDetail target = new DBLendingInfoDetail(connstr); // TODO: 初始化为适当的值
            string TrainmanGUID = string.Empty; // TODO: 初始化为适当的值
            TrainmanGUID = "07B9BD80-150C-4E62-9973-FF6E35D4CC8D";
            int state = 0; // TODO: 初始化为适当的值
            List<LendingInfoDetail> expected = null; // TODO: 初始化为适当的值
            List<LendingInfoDetail> actual;
            actual = target.GetTrainmanNotReturnLendingInfo(TrainmanGUID, state);
           // Assert.AreEqual(expected, actual);
            Assert.IsNotNull(actual);
            //Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetTrainmanNotReturnLendingInfo_DRToModelDTToList 的测试
        ///</summary>
       // [Test]
        public void GetTrainmanNotReturnLendingInfo_DRToModelDTToListTest()
        {
           // string ConnectionString = string.Empty; // TODO: 初始化为适当的值
            DBLendingInfoDetail target = new DBLendingInfoDetail(connstr); // TODO: 初始化为适当的值
            DataRow dr = null; // TODO: 初始化为适当的值
            LendingInfoDetail expected = null; // TODO: 初始化为适当的值
            LendingInfoDetail actual;
            actual = target.GetTrainmanNotReturnLendingInfo_DRToModelDTToList(dr);
            Assert.AreEqual(expected, actual);
           // Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetTrainmanNotReturnLendingInfo_DTToList 的测试
        ///</summary>
       // [Test]
        public void GetTrainmanNotReturnLendingInfo_DTToListTest()
        {
            //string ConnectionString = string.Empty; // TODO: 初始化为适当的值
            DBLendingInfoDetail target = new DBLendingInfoDetail(connstr); // TODO: 初始化为适当的值
            DataTable dt = null; // TODO: 初始化为适当的值
            List<LendingInfoDetail> expected = null; // TODO: 初始化为适当的值
            List<LendingInfoDetail> actual;
            actual = target.GetTrainmanNotReturnLendingInfo_DTToList(dt);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GiveBackDetail 的测试
        ///</summary>
        [Test]
        public void GiveBackDetailTest()
        {
         //   string ConnectionString = string.Empty; // TODO: 初始化为适当的值
            DBLendingInfoDetail target = new DBLendingInfoDetail(connstr); // TODO: 初始化为适当的值
            List<LendingInfoDetail> lifd = null; // TODO: 初始化为适当的值
            lifd = new List<LendingInfoDetail>();
            LendingInfoDetail l=new LendingInfoDetail();
            l.nGiveBackVerifyType = 0;
            l.strGiveBackTrainmanGUID = "55E0BDC7-CCD4-4979-BA69-D890F814F08D";
            l.strGUID = "25416FBC-35E7-40E4-B881-6C2314D4C08D";
            lifd.Add(l);
            target.GiveBackDetail(lifd);
            Assert.IsNotNull(lifd);
           // Assert.Inconclusive("无法验证不返回值的方法。");
        }

        /// <summary>
        ///InsertLendingInfo 的测试
        ///</summary>
        [Test]
        public void InsertLendingInfoTest()
        {
           // string ConnectionString = string.Empty; // TODO: 初始化为适当的值
            DBLendingInfoDetail target = new DBLendingInfoDetail(connstr); // TODO: 初始化为适当的值
            string strRemark = string.Empty; // TODO: 初始化为适当的值
            string strGUID = string.Empty; // TODO: 初始化为适当的值
            strGUID = Guid.NewGuid().ToString();
            target.InsertLendingInfo(strRemark, strGUID);
            Assert.IsNotNull(strGUID);
          //  Assert.Inconclusive("无法验证不返回值的方法。");
        }

        /// <summary>
        ///IsGoodInRange 的测试
        ///</summary>
        [Test]
        public void IsGoodInRangeTest()
        {
            //string ConnectionString = string.Empty; // TODO: 初始化为适当的值
            DBLendingInfoDetail target = new DBLendingInfoDetail(connstr); // TODO: 初始化为适当的值
            int nLendingType = 0; // TODO: 初始化为适当的值
            int strLendingExInfo = 102; // TODO: 初始化为适当的值
            string WorkShopGUID = string.Empty; // TODO: 初始化为适当的值
            WorkShopGUID = "3B50BF66-DABB-48C0-8B6D-05DB80591090";
            bool expected = true; // TODO: 初始化为适当的值
            bool actual;
            actual = target.IsGoodInRange(nLendingType, strLendingExInfo, WorkShopGUID);
            Assert.AreEqual(expected, actual);
           // Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///QueryDetails 的测试
        ///</summary>
        [Test]
        public void QueryDetailsTest()
        {
           // string ConnectionString = string.Empty; // TODO: 初始化为适当的值
            DBLendingInfoDetail target = new DBLendingInfoDetail(connstr); // TODO: 初始化为适当的值
            GoodsDetailQueryParam queryParam = null; // TODO: 初始化为适当的值
            List<LendingInfoDetail> expected = null; // TODO: 初始化为适当的值
            List<LendingInfoDetail> actual;
            queryParam = new GoodsDetailQueryParam();
            queryParam.nBianHao = -1;
            queryParam.strTrainmanName = "";
            queryParam.strTrainmanNumber="";
            queryParam.nLendingType=1;
            queryParam.nReturnState=0;
            actual = target.QueryDetails(queryParam);
            //Assert.AreEqual(expected, actual);
            Assert.IsNotNull(actual);
            //Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///QueryDetails_DRToModelDTToList 的测试
        ///</summary>
        //[Test]
        public void QueryDetails_DRToModelDTToListTest()
        {
           // string ConnectionString = string.Empty; // TODO: 初始化为适当的值
            DBLendingInfoDetail target = new DBLendingInfoDetail(connstr); // TODO: 初始化为适当的值
            DataRow dr = null; // TODO: 初始化为适当的值
            LendingInfoDetail expected = null; // TODO: 初始化为适当的值
            LendingInfoDetail actual;
            actual = target.QueryDetails_DRToModelDTToList(dr);
            //Assert.AreEqual(expected, actual);
            Assert.IsNotNull(actual);
            //Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///QueryDetails_DTToList 的测试
        ///</summary>
        //[Test]
        public void QueryDetails_DTToListTest()
        {
           // string ConnectionString = string.Empty; // TODO: 初始化为适当的值
            DBLendingInfoDetail target = new DBLendingInfoDetail(connstr); // TODO: 初始化为适当的值
            DataTable dt = null; // TODO: 初始化为适当的值
            List<LendingInfoDetail> expected = null; // TODO: 初始化为适当的值
            List<LendingInfoDetail> actual;
            actual = target.QueryDetails_DTToList(dt);
           // Assert.AreEqual(expected, actual);
            Assert.IsNotNull(actual);
           // Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///QueryGoodsNow 的测试
        ///</summary>
        [Test]
        public void QueryGoodsNowTest()
        {
           // string ConnectionString = string.Empty; // TODO: 初始化为适当的值
            DBLendingInfoDetail target = new DBLendingInfoDetail(connstr); // TODO: 初始化为适当的值
            string WorkShopGUID = string.Empty; // TODO: 初始化为适当的值
            WorkShopGUID = "3B50BF66-DABB-48C0-8B6D-05DB80591090";
            int GoodType = 0; // TODO: 初始化为适当的值
            int GoodID = 0; // TODO: 初始化为适当的值
            GoodID = 532;
            int orderType = 0; // TODO: 初始化为适当的值
            List<LendingInfoDetail> expected = null; // TODO: 初始化为适当的值
            List<LendingInfoDetail> actual;
            actual = target.QueryGoodsNow(WorkShopGUID, GoodType, GoodID, orderType);
            //Assert.AreEqual(expected, actual);
            Assert.IsNotNull(actual);
            //Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///QueryGoodsNow_DRToModelDTToList 的测试
        ///</summary>
        //[Test]
        public void QueryGoodsNow_DRToModelDTToListTest()
        {
           // string ConnectionString = string.Empty; // TODO: 初始化为适当的值
            DBLendingInfoDetail target = new DBLendingInfoDetail(connstr); // TODO: 初始化为适当的值
            DataRow dr = null; // TODO: 初始化为适当的值
            LendingInfoDetail expected = null; // TODO: 初始化为适当的值
            LendingInfoDetail actual;
            actual = target.QueryGoodsNow_DRToModelDTToList(dr);
           // Assert.AreEqual(expected, actual);
            Assert.IsNotNull(actual);
            //Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///QueryGoodsNow_DTToList 的测试
        ///</summary>
       // [Test]
        public void QueryGoodsNow_DTToListTest()
        {
         //   string ConnectionString = string.Empty; // TODO: 初始化为适当的值
            DBLendingInfoDetail target = new DBLendingInfoDetail(connstr); // TODO: 初始化为适当的值
            DataTable dt = null; // TODO: 初始化为适当的值
            List<LendingInfoDetail> expected = null; // TODO: 初始化为适当的值
            List<LendingInfoDetail> actual;
            actual = target.QueryGoodsNow_DTToList(dt);
          //  Assert.AreEqual(expected, actual);
            Assert.IsNotNull(actual);
            //Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///SendLendingInfo 的测试
        ///</summary>
        [Test]
        public void SendLendingInfoTest()
        {
           // string ConnectionString = string.Empty; // TODO: 初始化为适当的值
            DBLendingInfoDetail target = new DBLendingInfoDetail(connstr); // TODO: 初始化为适当的值
            string TrainmanGUID = string.Empty; // TODO: 初始化为适当的值
            string remark = string.Empty; // TODO: 初始化为适当的值
            List<LendingInfoDetail> lifd = null; // TODO: 初始化为适当的值
            lifd = new List<LendingInfoDetail>();
            LendingInfoDetail lendinfo = new LendingInfoDetail();
            //定义他的值
            TrainmanGUID = "08809D42-3B1C-4318-B818-756A7ED04300";
            lendinfo.dtBorrwoTime = DateTime.Now;
            lendinfo.nBorrowVerifyType=1;
                
           lendinfo.strTrainmanGUID =TrainmanGUID;
           lendinfo.strLenderGUID ="02517596-577B-4A0C-9E7F-A8C1AA35888E";
           lendinfo.strLendingInfoGUID = Guid.NewGuid().ToString();
           lendinfo.nLendingType =1;
           lendinfo.strLendingExInfo =450;
           lendinfo.nReturnState =0;
           lendinfo.dtModifyTime =  DateTime.Now;

            lifd.Add(lendinfo);
            target.SendLendingInfo(TrainmanGUID, remark, lifd);
            Assert.IsNotNull(lifd);
           // Assert.Inconclusive("无法验证不返回值的方法。");
        }

        /// <summary>
        ///UpdateLendingInfoRemark 的测试
        ///</summary>
        [Test]
        public void UpdateLendingInfoRemarkTest()
        {
           // string ConnectionString = string.Empty; // TODO: 初始化为适当的值
            DBLendingInfoDetail target = new DBLendingInfoDetail(connstr); // TODO: 初始化为适当的值
            string strGUID = string.Empty; // TODO: 初始化为适当的值
            string remark = string.Empty; // TODO: 初始化为适当的值
            strGUID = "02517596-577B-4A0C-9E7F-A8C1AA35888E";// Guid.NewGuid().ToString();
            remark = "mytest";
            target.UpdateLendingInfoRemark(strGUID, remark);
            Assert.IsNotNull(strGUID);
           // Assert.Inconclusive("无法验证不返回值的方法。");
        }
    }
}
