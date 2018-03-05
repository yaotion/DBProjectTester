using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Data.Schema.UnitTesting;
 
namespace TF.GoodManager.UnitTest
{
   
   // [TestClass()]
    public class DatabaseSetup
    {
        public static ConnectionContext CONNTXT = new ConnectionContext();
        [AssemblyInitialize()]
        public static void InitializeAssembly(TestContext ctx)
        {
            //   根据配置文件中的设置来设置
            // 测试数据库
           //DatabaseTestClass.TestService.DeployDatabaseProject();
       // DatabaseTestClass.TestService.GenerateData();
        //表示 app.config 文件的 DatabaseUnitTesting 部分中的 ExecutionContext 或 PrivilegedContext 配置元素。
        Microsoft.Data.Schema.UnitTesting.Configuration.ConnectionContextElement cce = new Microsoft.Data.Schema.UnitTesting.Configuration.ConnectionContextElement();
        //表示 app.config 文件的 DatabaseUnitTesting 部分中的 DatabaseDeployment 配置元素
            Microsoft.Data.Schema.UnitTesting.Configuration.DatabaseDeploymentElement bse = new Microsoft.Data.Schema.UnitTesting.Configuration.DatabaseDeploymentElement();
            //表示 app.config 文件的 DatabaseUnitTesting 部分中的 DataGeneration 配置元素
            Microsoft.Data.Schema.UnitTesting.Configuration.DataGenerationElement dge = new Microsoft.Data.Schema.UnitTesting.Configuration.DataGenerationElement();
            //app.config 文件中的 DatabaseUnitTesting 配置部分。
            Microsoft.Data.Schema.UnitTesting.Configuration.DatabaseUnitTestingSection dus = new Microsoft.Data.Schema.UnitTesting.Configuration.DatabaseUnitTestingSection();

            CONNTXT.Connection.ConnectionString = GetConnectionStringsConfig("MyCon");// System.Configuration.ConfigurationManager.AppSettings["MyCon"].ToString();
           // System.Configuration.ConfigurationManager.AppSettings[""].
            //string xc = ctx.DataConnection.ConnectionString;
        }
   

    ///<summary>
///在＊.exe.config文件中appSettings配置节增加一对键、值对
///</summary>
///<param ></param>
///<param ></param>
        private static void UpdateAppConfig(string newKey, string newValue)
        {
            bool isModified = false;
            foreach (string key in ConfigurationManager.AppSettings)
            {
                if (key == newKey)
                {
                    isModified = true;
                }
            }

            // Open App.Config of executable
            Configuration config =
                ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            // You need to remove the old settings object before you can replace it
            if (isModified)
            {
                config.AppSettings.Settings.Remove(newKey);
            }
            // Add an Application Setting.
            config.AppSettings.Settings.Add(newKey, newValue);
            // Save the changes in App.config file.
            config.Save(ConfigurationSaveMode.Modified);
            // Force a reload of a changed section.
            ConfigurationManager.RefreshSection("appSettings");
        }
        ///<summary>
        ///返回＊.exe.config文件中appSettings配置节的value项
        ///</summary>
        ///<param ></param>
        ///<returns></returns>
        private static string GetAppConfig(string strKey)
        {
            foreach (string key in ConfigurationManager.AppSettings)
            {
                if (key == strKey)
                {
                    return ConfigurationManager.AppSettings[strKey];
                }
            }
            return null;
        }
        ///</summary>
        ///<param ></param>
        ///<returns></returns>
        public static string GetConnectionStringsConfig(string connectionName)
        {
            string connectionString =
                    ConfigurationManager.ConnectionStrings[connectionName].ConnectionString.ToString();
            Console.WriteLine(connectionString);
            return connectionString;
        }
        ///<summary>
        ///更新连接字符串
        ///</summary>
        ///<param >连接字符串名称</param>
        ///<param >连接字符串内容</param>
        ///<param >数据提供程序名称</param>
        private static void UpdateConnectionStringsConfig(string newName, string newConString, string newProviderName)
        {
            bool isModified = false;    //记录该连接串是否已经存在
            //如果要更改的连接串已经存在
            if (ConfigurationManager.ConnectionStrings[newName] != null)
            {
                isModified = true;
            }
            //新建一个连接字符串实例
            ConnectionStringSettings mySettings =
                new ConnectionStringSettings(newName, newConString, newProviderName);
            // 打开可执行的配置文件*.exe.config
            Configuration config =
                ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            // 如果连接串已存在，首先删除它
            if (isModified)
            {
                config.ConnectionStrings.ConnectionStrings.Remove(newName);
            }
            // 将新的连接串添加到配置文件中.
            config.ConnectionStrings.ConnectionStrings.Add(mySettings);
            // 保存对配置文件所作的更改
            config.Save(ConfigurationSaveMode.Modified);
            // 强制重新载入配置文件的ConnectionStrings配置节
            ConfigurationManager.RefreshSection("ConnectionStrings");
        }
    }
}
