using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data.SqlClient;

using System.Threading.Tasks;
using NUnit.Framework;  
namespace TF.GoodManager.UnitTest
{
   // [TestFixture]   //关键字  
    public class ProgramTester
    {
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
        public ProgramTester()
        {
            connstr = DatabaseSetup.GetConnectionStringsConfig("MyCon");
            SqlConnection connsql = new SqlConnection(connstr);
            StreamWriter SW = new StreamWriter("C:\\TEST.TXT");
            try
            {

                SW.WriteLine("测试计算的构造器" + connstr);
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
            }
        }
       //1.1 必须有[Test]作为标识；  
          //关键字  
        //1.2 访问权限必须为Public，必须无返回值void  
         //[Test]   
        public void TestAdd()  //加法1  
        {
              
            //实例化 生成 对象  
            Methods addOne = new Methods();  
  
            //利用测试数据，对方法进行测试  
            double result = addOne.add(1, 2);  
  
             //1.3 设置断言“3”为expected期望值；“result”为actual真实值。  
            Assert.AreEqual(3, result);  
        }  
  
  
        //[Test]可扩展写成[Test(Description="")]对本测试进行简单描述  
       // [Test(Description = "加法Add()测试")]  
        public void TestSubtract()  //减法  
        {  
            Methods subtractOne = new Methods();  
            int result = subtractOne.subtract(2, 1);  
            Assert.AreEqual(1, result);  
        }  
  
  
      //  [Test]  
        public void TestMutiply()   //乘法  
        {  
            Methods mutiplyOne = new Methods();  
            int result = mutiplyOne.multiply(1, 2);  
            Assert.AreEqual(2, result);  
        }  
  
  
        //[Test]  
        public void TestDivision1()  //除法  
        {
            try
            {
                Methods methodsOne = new Methods();
                //5为被除数，2为除数  
                double result = methodsOne.division(5, 2);
                Assert.AreEqual(3, result);
            }
            catch (Exception ERROR)
            {
                Console.WriteLine(ERROR.Message);
                throw ERROR;
            }
        }  
  
  
       // [Test]  
        public void TestDivision2()  //除法  
        {  
            // try
            //{
            Methods methodsTwo = new Methods();  
            //程序运行，弹出提示信息“除数不能为0，算式无意义！”  
            double result = methodsTwo.division(5, 0);  
            Assert.AreEqual(0, result);
            //}
            // catch (Exception ERROR)
            // {
            //     Console.WriteLine(ERROR.Message);
            //     throw ERROR;
            // }
        }  
    }
}
