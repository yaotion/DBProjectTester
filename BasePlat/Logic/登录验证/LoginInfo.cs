
using System;
using System.Data;
using System.Configuration;
using System.Web;
using TF.CommonUtility;
using TF.WebPlatForm.DBUtils;
using TF.WebPlatForm.Entry;
using System.Reflection;

namespace TF.WebPlatForm.Logic
{
    public class UserLogin
    {
        //定义操作员信息在Cookie中的目录
        public static string CookieName = "Platform";
        public static string ItemName = "UserLogin";
        public static long ValidSecond = 60 * 60 * 24;

        /// <summary> 返回登录用户的信息
        /// </summary>
        public static Dic_StaffInfo LoginUser
        {
            get
            {
                string tokenID = Cookie.ReadCookie(CookieName, ItemName);
                Dic_StaffInfo ui = new Dic_StaffInfo();
                if ((tokenID == null) || (tokenID.Length == 0))
                {
                    Dic_StaffInfo userInfo = new Dic_StaffInfo();
                    return userInfo;
                }

                if (ConstCommon.UserTabEnable == 2)
                {
                    var asm = Assembly.LoadFile(HttpContext.Current.Server.MapPath("/Bin/" + ConstCommon.UserTabDllName));
                    var type = asm.GetType(ConstCommon.UserTabLoginUserClassName);
                    var instance = asm.CreateInstance(ConstCommon.UserTabLoginUserClassName);
                    var method = type.GetMethod(ConstCommon.UserTabLoginUserMethodName);
                    otherLogin model = (otherLogin)method.Invoke(instance, new object[] { tokenID });
                    ui.nRoleID = model.UserRole;
                    ui.strName = model.UserName;
                    ui.strNumber = model.UserNumber;
                    ui.strPassword = model.Md5pd;
                }
                else
                {
                     DBDic_StaffInfo UserInfo = new DBDic_StaffInfo(ConData.WebSiteConnectionString);
                ui = UserInfo.UserInfoByTL(tokenID, IdentityAuthentication.MaxTokenSecond, IdentityAuthentication.MaxLoginSecond);
                }
                return ui;
            }
        }

        /// <summary> 判断是否登录
        /// </summary>
        public static Boolean IsLogin
        {
            get
            {
                string tokenID = Cookie.ReadCookie(CookieName, ItemName);
                if ((tokenID == null) || (tokenID.Length == 0)) return false;
                DBDic_StaffInfo UserInfo = new DBDic_StaffInfo(ConData.WebSiteConnectionString);
                Dic_StaffInfo ui = UserInfo.UserInfoByTL(tokenID, IdentityAuthentication.MaxTokenSecond, IdentityAuthentication.MaxLoginSecond);
                //lsDicUserInfo ui = new lsDicUserInfo(tokenID, IdentityAuthentication.MaxTokenSecond, IdentityAuthentication.MaxLoginSecond, ConData.WebSiteConnectionString);
                try
                {
                    if (!IdentityAuthentication.ValidTokenID(ObjectConvertClass.static_ext_string(ui.strTokenID), Convert.ToDateTime(ui.dtTokenTime), Convert.ToDateTime(ui.dtLoginTime)))
                        return false;
                    return true;
                }
                catch
                {
                    return false;
                }

            }
        }

    }
}
