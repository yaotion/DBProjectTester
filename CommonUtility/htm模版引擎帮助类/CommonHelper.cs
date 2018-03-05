using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NVelocity.App;
using NVelocity.Runtime;
using NVelocity;
using System.IO;
using System.Text;

namespace TF.CommonUtility
{
    public class CommonHelper
    {
        /// <summary>
        /// 用data数据填充templateName模板，渲染生成html返回
        /// </summary>
        /// <param name="templateName"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string RenderHtml(string templateName, object data)
        {
            VelocityEngine vltEngine = new VelocityEngine();
            vltEngine.SetProperty(RuntimeConstants.RESOURCE_LOADER, "file");
            vltEngine.SetProperty(RuntimeConstants.FILE_RESOURCE_LOADER_PATH, System.Web.Hosting.HostingEnvironment.MapPath("~/SpecificOnDuty/Temp"));//模板文件所在的文件夹
            vltEngine.Init();

            VelocityContext vltContext = new VelocityContext();
            vltContext.Put("Data", data);//设置参数，在模板中可以通过$data来引用

            Template vltTemplate = vltEngine.GetTemplate(templateName);
            System.IO.StringWriter vltWriter = new System.IO.StringWriter();
            vltTemplate.Merge(vltContext, vltWriter);

            string html = vltWriter.GetStringBuilder().ToString();
            return html;
        }

        /// <summary>
        /// 用data数据填充templateName模板，渲染生成html返回
        /// </summary>
        /// <param name="templateName"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string RenderHtml(string templateName,string strFilepath)
        {
            string strFilePath = System.AppDomain.CurrentDomain.BaseDirectory + strFilepath + "/" + templateName;
            string strHtmlContent = File.ReadAllText(strFilePath, Encoding.GetEncoding("GB2312"));
            return strHtmlContent;
        }





        /// <summary>
        /// 读取HTML文件
        /// </summary>
        /// <param name="temp">;</param>
        /// <returns></returns>
        public static string ReadHtmlFile(string temp)
        {
            temp = HttpContext.Current.Server.MapPath(temp);
            StreamReader sr = null;
            string str = "";
            try
            {
                sr = new StreamReader(temp);
                str = sr.ReadToEnd(); // 读取文件 
            }
            catch (Exception exp)
            {
                HttpContext.Current.Response.Write(exp.Message);
                HttpContext.Current.Response.End();
            }
            finally
            {
                sr.Dispose();
                sr.Close();

            }
            return str;
        }

    }
}