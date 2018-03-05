using GoodManager.DBUtils;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using GoodManager.Entry.LendingType_物品类型_;
using System.Collections.Generic;
using System.Data;
 
using NUnit.Framework;
using System.Data.SqlClient;
using System.IO;
namespace TF.GoodManager.UnitTest
{
   
    [TestFixture]  
    public class DBGoodTypeTest
    {
         public DBGoodTypeTest()
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

      [Test]   
        public void DBGoodTypeConstructorTest()
        {
            DBGoodType target = new DBGoodType(connstr);
         
            Assert.IsNotNull(target);
           // Assert.Inconclusive("TODO: 实现用来验证目标的代码");
        }
     //// private static DBGoodType dbtype = null;
     // [TestFixtureSetUp]
     // public static  void MakeAppDomain()
     // {
     //    // dbtype = new DBGoodType("");
     //     //connstr = DatabaseSetup.GetConnectionStringsConfig("MyCon");
     //     //SqlConnection connsql = new SqlConnection(connstr);
     //     StreamWriter SW = new StreamWriter("C:\\TEST111.TXT");
     //     try
     //     {

     //         SW.WriteLine("DBGoodTypeTest" );
     //         SW.Flush();
     //         //connsql.Open();
     //        // bolconn = true;
     //        // SW.WriteLine(bolconn);
     //        // SW.Flush();
     //         SW.Close();

     //     }
     //     catch (Exception error)
     //     {
     //         SW.WriteLine(error.Message);
     //         SW.Flush();
     //         SW.Close();
     //         //bolconn = false;
     //         //if (connsql != null)
     //         //    connsql.Dispose();
     //     }
     //     finally
     //     {
     //         //connsql.Close();
     //     }
     // }
     // [SetUp]
     // public void SetUp()
     // {
     //     //testDomain = new TestDomain();
     //     connstr = DatabaseSetup.GetConnectionStringsConfig("MyCon");
     //     SqlConnection connsql = new SqlConnection(connstr);
     //     StreamWriter SW = new StreamWriter("C:\\TESTsetp.TXT");
     //     try
     //     {

     //         SW.WriteLine("DBGoodTypeTest" + connstr);
     //         SW.Flush();
     //         connsql.Open();
     //         bolconn = true;
     //         SW.WriteLine(bolconn);
     //         SW.Flush();
     //         SW.Close();

     //     }
     //     catch (Exception error)
     //     {
     //         SW.WriteLine(error.Message);
     //         SW.Flush();
     //         SW.Close();
     //         bolconn = false;
     //         if (connsql != null)
     //             connsql.Dispose();
     //     }
     //     finally
     //     {
     //         connsql.Close();
     //     }
      // }  //  public static DBGoodType targets = null;
  
       [Test]
      public void GetGoodTypeTest()
        { 


        DBGoodType target = new DBGoodType(connstr); // TODO: 初始化为适当的值
         //List<LendingType> expected = null; // TODO: 初始化为适当的值
           // Methods m = new Methods();
         List<LendingType> actual;
         actual = target.GetGoodType();
         Assert.IsNotNull(actual);
           Assert.AreEqual(2, actual.Count);
       
        
           // Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetGoodType_DRToModelDTToList 的测试
        ///</summary>
        //[Test] 
        public void GetGoodType_DRToModelDTToListTest()
        {
            //string ConnectionString = string.Empty; // TODO: 初始化为适当的值
            DBGoodType target = new DBGoodType(connstr); // TODO: 初始化为适当的值
            DataRow dr = null; // TODO: 初始化为适当的值
            //LendingType expected = null; // TODO: 初始化为适当的值
            //LendingType actual;
            //actual = target.GetGoodType_DRToModelDTToList(dr);
            //Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetGoodType_DTToList 的测试
        ///</summary>
       //[Test] 
        public void GetGoodType_DTToListTest()
        {
            //string ConnectionString = string.Empty; // TODO: 初始化为适当的值
            DBGoodType target = new DBGoodType(connstr); // TODO: 初始化为适当的值
            DataTable dt = null; // TODO: 初始化为适当的值
            //List<LendingType> expected = null; // TODO: 初始化为适当的值
            //List<LendingType> actual;
            //actual = target.GetGoodType_DTToList(dt);
            //Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }
    }
}
