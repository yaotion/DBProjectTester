using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TF.CommonUtility;
namespace TF.WebPlatForm.Logic
{
    public class ConData
    {
        //系统数据库配置
        public static string WebSiteConnectionString = XmlClass.Read("XmlConfig.xml", "/XmlConfig/ConData/WebSiteConnectionString");

        public static string WebSiteORCLConnectionString = XmlClass.Read("XmlConfig.xml", "/XmlConfig/ConData/WebSiteORCLConnectionString");

    }

       

    public class ConstCommon
    {
        //是否用平台用户表
        public static int UserTabEnable = ObjectConvertClass.static_ext_int(XmlClass.Read("XmlConfig.xml", "/XmlConfig/UserTabEnable/nEnable"));
        //ddl名称
        public static string UserTabDllName = ObjectConvertClass.static_ext_string(XmlClass.Read("XmlConfig.xml", "/XmlConfig/UserTabEnable/DllName"));
        //Login类名称
        public static string UserTabLoginClassName = ObjectConvertClass.static_ext_string(XmlClass.Read("XmlConfig.xml", "/XmlConfig/UserTabEnable/login/ClassName"));
        //Login方法名称
        public static string UserTabLoginMethodName = ObjectConvertClass.static_ext_string(XmlClass.Read("XmlConfig.xml", "/XmlConfig/UserTabEnable/login/MethodName"));
        //LoginUser类名称
        public static string UserTabLoginUserClassName = ObjectConvertClass.static_ext_string(XmlClass.Read("XmlConfig.xml", "/XmlConfig/UserTabEnable/LoginUser/ClassName"));
        //LoginUser方法名称
        public static string UserTabLoginUserMethodName = ObjectConvertClass.static_ext_string(XmlClass.Read("XmlConfig.xml", "/XmlConfig/UserTabEnable/LoginUser/MethodName"));
        //setPwd类名称
        public static string UserTabsetPwdClassName = ObjectConvertClass.static_ext_string(XmlClass.Read("XmlConfig.xml", "/XmlConfig/UserTabEnable/setPwd/ClassName"));
        //setPwd方法名称
        public static string UserTabsetPwdMethodName = ObjectConvertClass.static_ext_string(XmlClass.Read("XmlConfig.xml", "/XmlConfig/UserTabEnable/setPwd/MethodName"));
        //IsLogin类名称
        public static string UserTabIsLoginClassName = ObjectConvertClass.static_ext_string(XmlClass.Read("XmlConfig.xml", "/XmlConfig/UserTabEnable/IsLogin/ClassName"));
        //IsLogin方法名称
        public static string UserTabIsLoginMethodName = ObjectConvertClass.static_ext_string(XmlClass.Read("XmlConfig.xml", "/XmlConfig/UserTabEnable/IsLogin/MethodName"));
        //站点名称
        public static string SiteName
        {
            get
            {
                return XmlClass.Read("XmlConfig.xml", "/XmlConfig/SystemBase/SiteName");
            }
        }

        //站点版本号
        public static string SiteVersion
        {
            get
            {
                return XmlClass.Read("XmlConfig.xml", "/XmlConfig/SystemBase/SiteVersion");
            }
        }
    }
}
