using GoodManager.DBUtils.DBcodeRange;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using GoodManager.Entry.LendingManager_物品编码_;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Reflection;

using NUnit.Framework;

using System.Data.SqlClient;
namespace TF.GoodManager.UnitTest
{
    
    
    /// <summary>
    ///这是 DBLendingManagerTest 的测试类，旨在
    ///包含所有 DBLendingManagerTest 单元测试
    ///</summary>
    //[TestClass()]
    [TestFixture]  
    public class DBLendingManagerTest
    {

        public DBLendingManagerTest()
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
        //private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContextInstance;

        ///// <summary>
        /////获取或设置测试上下文，上下文提供
        /////有关当前测试运行及其功能的信息。
        /////</summary>
        //public Microsoft.VisualStudio.TestTools.UnitTesting.TestContext TestContext
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
        ///DBLendingManager 构造函数 的测试
        ///</summary>
        //[TestMethod()]
        //public void DBLendingManagerConstructorTest()
        //{
        //    string ConnectionString = string.Empty; // TODO: 初始化为适当的值
        //    DBLendingManager target = new DBLendingManager(ConnectionString);
        //  //  Assert.Inconclusive("TODO: 实现用来验证目标的代码");
        //}

        /// <summary>
        ///DeleteGoodsCodeRange 的测试
        ///</summary>
        //[TestMethod()]
         [Test] 
        public void DeleteGoodsCodeRangeTest()
        {
           // string ConnectionString = string.Empty; // TODO: 初始化为适当的值

           // ConnectionString = DatabaseSetup.GetConnectionStringsConfig("MyCon");// DatabaseSetup.CONNTXT.Connection.ConnectionString;// "Data Source=192.168.1.166;Initial Catalog=goodtestdb;User ID=sa;PassWord=Think123";
            DBLendingManager target = new DBLendingManager(connstr); // TODO: 初始化为适当的值
            string rangeGUID = string.Empty; // TODO: 初始化为适当的值
            bool expected = true; // TODO: 初始化为适当的值
            bool actual;
            string strguid = "867F086C-AF3C-4D88-88A4-63C85729F820";
            actual = target.DeleteGoodsCodeRange(strguid);

          ////  var sqlHelperMock = new Mock<LendingManagerInterface>();
           //sqlHelperMock.Setup(x => x.DeleteGoodsCodeRange(strguid)).Returns(true);
           //actual= sqlHelperMock.Object.DeleteGoodsCodeRange(strguid);
           
          Assert.AreEqual(expected, actual);
          
           // Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetGoodsCodeRange 的测试
        ///</summary>
        //[TestMethod()]
         [Test] 
        public void GetGoodsCodeRangeTest()
        {
         //   string ConnectionString = string.Empty; // TODO: 初始化为适当的值
          //  ConnectionString = DatabaseSetup.GetConnectionStringsConfig("MyCon");// DatabaseSetup.CONNTXT.Connection.ConnectionString;
            DBLendingManager target = new DBLendingManager(connstr); // TODO: 初始化为适当的值
            string WorkShopGUID = string.Empty; // TODO: 初始化为适当的值
            WorkShopGUID = "3b50bf66-dabb-48c0-8b6d-05db80591090";
            int lendingType = 0; // TODO: 初始化为适当的值
            List<LendingManager> expected = null; // TODO: 初始化为适当的值
            //准备期望值
            List<LendingManager> actual;
            actual = target.GetGoodsCodeRange(WorkShopGUID, lendingType);
            //Assert.AreEqual(expected, actual);

            Assert.IsNotNull(actual);
           // Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetGoodsCodeRange 的测试
        ///</summary>
        //[TestMethod()]
         [Test] 
        public void GetGoodsCodeRangeTest1()
        {
           
           // Data Source=192.168.1.166;Initial Catalog=goodtestdb;User ID=sa;Pooling=False
           // string ConnectionString = string.Empty; // TODO: 初始化为适当的值
            //ConnectionString = "Data Source=192.168.1.166;Initial Catalog=goodtestdb;User ID=sa;PassWord=Think123";
           // ConnectionString = DatabaseSetup.GetConnectionStringsConfig("MyCon"); //DatabaseSetup.CONNTXT.Connection.ConnectionString;
            DBLendingManager target = new DBLendingManager(connstr); // TODO: 初始化为适当的值
            string strguid = string.Empty; // TODO: 初始化为适当的值
            strguid = "867F086C-AF3C-4D88-88A4-63C85729F820";
            LendingManager expected = null; // TODO: 初始化为适当的值
            expected = new LendingManager ();
            expected.nID = 3; 
              expected.strGUID=  "867F086C-AF3C-4D88-88A4-63C85729F820"; 
              expected.nLendingTypeID=  0;
            expected.nStartCode=    1; 
             expected.nStopCode=   100;
             expected.strExceptCodes=   ""; 
             expected.strWorkShopGUID=   "3b50bf66-dabb-48c0-8b6d-05db80591090" ;

            LendingManager actual;
            actual = target.GetGoodsCodeRange(strguid);
            Assert.IsNotNull(actual);
            //bool r = actual.Equals(expected);
            Assert.AreEqual(actual.nStartCode, expected.nStartCode);
           // Assert.AreSame(expected, actual);
         //bool ret=   compareobj(expected, actual);
           // Assert.Inconclusive("验证此测试方法的正确性。");
        }
        /// <summary>
        /// 获取属性值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="propertyname"></param>
        /// <returns></returns>
        public static string GetObjectPropertyValue<T>(T t, string propertyname)
        {
            Type type = typeof(T);

            PropertyInfo property = type.GetProperty(propertyname);

            if (property == null) return string.Empty;

            object o = property.GetValue(t, null);

            if (o == null) return string.Empty;

            return o.ToString();
        }
        /// <summary>
        /// 反射获取类的属性
        /// </summary>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        /// <returns></returns>
        public bool compareobj(LendingManager t1, LendingManager t2)
        {
            Type tone = typeof(LendingManager);
            System.Reflection.PropertyInfo[] properties = tone.GetProperties();

            foreach (System.Reflection.PropertyInfo info in properties)
            {
                string str = "name=" + info.Name + ";" + "type=" + info.PropertyType.Name + ";value=" + GetObjectPropertyValue<LendingManager>(t1, info.Name);
                string str2 = "name=" + info.Name + ";" + "type=" + info.PropertyType.Name + ";value=" + GetObjectPropertyValue<LendingManager>(t2, info.Name);
            }
           
            return true;
        }

        /// <summary>
        ///GetGoodsCodeRange_DRToModelDTToList 的测试
        ///</summary>
        //[TestMethod()]
         //[Test] 
        public void GetGoodsCodeRange_DRToModelDTToListTest()
        {
            //string ConnectionString = string.Empty; // TODO: 初始化为适当的值
            //ConnectionString = DatabaseSetup.GetConnectionStringsConfig("MyCon"); //DatabaseSetup.CONNTXT.Connection.ConnectionString;
            DBLendingManager target = new DBLendingManager(connstr); // TODO: 初始化为适当的值
            DataRow dr = null; // TODO: 初始化为适当的值
            LendingManager expected = null; // TODO: 初始化为适当的值
            LendingManager actual;
            actual = target.GetGoodsCodeRange_DRToModelDTToList(dr);
          // Assert.AreEqual(expected, actual);
            Assert.IsNotNull(actual);
           // Assert.AreSame(expected, actual);
            // Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetGoodsCodeRange_DTToList 的测试
        ///</summary>
        //[TestMethod()]
       //[Test] 
        public void GetGoodsCodeRange_DTToListTest()
        {
           // string ConnectionString = string.Empty; // TODO: 初始化为适当的值
            //ConnectionString = DatabaseSetup.GetConnectionStringsConfig("MyCon");// DatabaseSetup.CONNTXT.Connection.ConnectionString;
            DBLendingManager target = new DBLendingManager(connstr); // TODO: 初始化为适当的值
            DataTable dt = null; // TODO: 初始化为适当的值
            List<LendingManager> expected = null; // TODO: 初始化为适当的值
            List<LendingManager> actual;
            actual = target.GetGoodsCodeRange_DTToList(dt);
          //  Assert.AreEqual(expected, actual);
            Assert.IsNotNull(actual);
            //  Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///InsertGoodsCodeRange 的测试
        ///</summary>
        //[TestMethod()]
         [Test] 
        public void InsertGoodsCodeRangeTest()
        {
         //   string ConnectionString = string.Empty; // TODO: 初始化为适当的值
          //  ConnectionString = "Data Source=192.168.1.166;Initial Catalog=goodtestdb;User ID=sa;PassWord=Think123";.
          //  ConnectionString = DatabaseSetup.GetConnectionStringsConfig("MyCon");// DatabaseSetup.CONNTXT.Connection.ConnectionString;
            DBLendingManager target = new DBLendingManager(connstr); // TODO: 初始化为适当的值
            
            LendingManager model = null; // TODO: 初始化为适当的值
           LendingManager expected = null; // TODO: 初始化为适当的值
            model = new LendingManager();
             
                model.nID = 3;
                 model.strGUID = "867F086C-AF3C-4D88-88A4-63C85729F820";
                 model.nLendingTypeID = 0;
                 model.nStartCode = 1;
                 model.nStopCode = 100;
                 model.strExceptCodes = "";
                 model.strWorkShopGUID = "3b50bf66-dabb-48c0-8b6d-05db80591090";
            

          //  bool result = true; // TODO: 初始化为适当的值
           // bool actual;
            bool inbol = true;
            //actual = target.InsertGoodsCodeRange(model);
           // var sqlHelperMock = new Mock<LendingManagerInterface>();
          
           // sqlHelperMock.Setup(x => x.InsertGoodsCodeRange(model)).Returns(true);
            bool actual = false;// sqlHelperMock.Object.InsertGoodsCodeRange(model);
            actual = target.InsertGoodsCodeRange(model);
            //bool ret = false;
            //try
            //{
                Assert.AreEqual(inbol,actual );
              //  sqlHelperMock.VerifyAll();
            //    ret = true;
            //}
            //catch(Exception error)
            //{
            //    ret = false;
            //}
           // return ret;
           // expected = target.GetGoodsCodeRange("867F086C-AF3C-4D88-88A4-63C85729F820");
          //  Assert.AreEqual(result, actual);
            //Assert.IsTrue(actual);
           // Assert.AreSame(model, expected);
           // Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///IsGoodInRange 的测试
        ///</summary>
        //[TestMethod()]
         [Test] 
        public void IsGoodInRangeTest()
        {
          //  string ConnectionString = string.Empty; // TODO: 初始化为适当的值
           // ConnectionString = DatabaseSetup.GetConnectionStringsConfig("MyCon"); //DatabaseSetup.CONNTXT.Connection.ConnectionString;
            DBLendingManager target = new DBLendingManager(connstr); // TODO: 初始化为适当的值
            int nLendingType = 1; // TODO: 初始化为适当的值
            int strLendingExInfo = 0; // TODO: 初始化为适当的值
            strLendingExInfo = 402;
            string WorkShopGUID = string.Empty; // TODO: 初始化为适当的值
            WorkShopGUID = "3b50bf66-dabb-48c0-8b6d-05db80591090";
            bool expected = true; // TODO: 初始化为适当的值
            bool actual;
            actual = target.IsGoodInRange(nLendingType, strLendingExInfo, WorkShopGUID);
            Assert.AreEqual(expected, actual);
            // Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///UpdateGoodsCodeRange 的测试
        ///</summary>
        //[TestMethod()]
         [Test] 
        public void UpdateGoodsCodeRangeTest()
        {
           // string ConnectionString = string.Empty; // TODO: 初始化为适当的值
           // ConnectionString = DatabaseSetup.GetConnectionStringsConfig("MyCon");// DatabaseSetup.CONNTXT.Connection.ConnectionString;
          //  ConnectionString = "Data Source=192.168.1.166;Initial Catalog=goodtestdb;User ID=sa;PassWord=Think123";
            DBLendingManager target = new DBLendingManager(connstr); // TODO: 初始化为适当的值
            LendingManager model = null; // TODO: 初始化为适当的值
            model = new LendingManager();
            model.nID = 11;
            model.strGUID = "606C3E5D-0EFC-4E12-9E47-DFB512085D02";
            model.nLendingTypeID = 1;
            model.nStartCode = 300;
            model.nStopCode = 400;
            model.strExceptCodes = "";
            model.strWorkShopGUID = "3b50bf66-dabb-48c0-8b6d-05db80591090";
            
            bool expected = true; // TODO: 初始化为适当的值

            bool actual = target.UpdateGoodsCodeRange(model);
           // var sqlHelperMock = new Mock<LendingManagerInterface>();

           // sqlHelperMock.Setup(x => x.UpdateGoodsCodeRange(model)).Returns(true);
          // bool actual = sqlHelperMock.Object.UpdateGoodsCodeRange(model);
            Assert.AreEqual(expected, actual);
          //  Assert.Inconclusive("验证此测试方法的正确性。");
        }
    }
}
