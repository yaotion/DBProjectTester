using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Configuration;

namespace DbUnitTest2000
{
    public class AppConfig
    {
        public AppConfig()
        {
            ///
            /// TODO: 在此处添加构造函数逻辑
            ///
        }
        /// <summary>
        /// 写操作
        /// </summary>
        /// <param name="strExecutablePath"></param>
        /// <param name="AppKey"></param>
        /// <param name="AppValue"></param>
        public static void ConfigSetValue(string strExecutablePath, string AppKey, string AppValue)
        {
            XmlDocument xDoc = new XmlDocument();
            //获取可执行文件的路径和名称
            xDoc.Load(strExecutablePath + ".config");

            XmlNode xNode;
            XmlElement xElem1;
            XmlElement xElem2;
            xNode = xDoc.SelectSingleNode("//connectionStrings");
            // xDoc.Load(System.Windows.Forms.Application.ExecutablePath + ".config");
            xElem1 = (XmlElement)xNode.SelectSingleNode("//add[@name='" + AppKey + "']");
            if (xElem1 != null)
            {
                xElem1.SetAttribute("connectionString", AppValue);
            }
            else
            {
                xElem2 = xDoc.CreateElement("add");
                xElem2.SetAttribute("name", AppKey);
                xElem2.SetAttribute("connectionString", AppValue);
                xNode.AppendChild(xElem2);
            }
            xDoc.Save(strExecutablePath + ".config");
        }
        ///</summary>
        ///<param >MyCon</param>
        ///<returns></returns>
        public static string GetConnectionStringsConfig(string connectionName)
        {
            string connectionString =
                    ConfigurationManager.ConnectionStrings[connectionName].ConnectionString.ToString();
            Console.WriteLine(connectionString);
            return connectionString;
        }

         
    }
}
