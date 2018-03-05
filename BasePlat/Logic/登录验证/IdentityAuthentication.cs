using System;
using System.Linq;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using System.Reflection;
using TF.WebPlatForm.DBUtils;
using System.Configuration;
using TF.WebPlatForm.Entry;
using System.Web;
using System.Web.Configuration;
using TF.CommonUtility;
namespace TF.WebPlatForm.Logic
{
    /// <summary>
    ///IdentityAuthentication 的摘要说明
    /// </summary>
    public class IdentityAuthentication
    {
        public IdentityAuthentication()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }
        public static long MaxTokenSecond = 60 * 60 * 24;      //24小时  不操作
        public static long MaxLoginSecond = 60 * 60 * 24; //24小时 登录

        public static bool ValidTokenID(string tokenID, DateTime tokenTime, DateTime loginTime)
        {
            bool result = false;
            if (tokenID.Length == 0) return result;
            if (DBNull.Value.Equals(tokenTime) || (tokenTime == null)) return false;
            if (DBNull.Value.Equals(loginTime) || (loginTime == null)) return false;
            if (MaxTokenSecond > -1)
            {
                if (tokenTime.AddSeconds(MaxTokenSecond) < DateTime.Now) return result;
            }
            if (MaxLoginSecond > -1)
            {
                if (loginTime.AddSeconds(MaxLoginSecond) < DateTime.Now) return result;
            }
            result = true;
            return result;

        }
        /// <summary>
        /// 返回指定字符串的MD5加密形式
        /// </summary>
        /// <param name="inputString">输入字符串</param>
        /// <returns>加密后的字符串</returns>
        public static string EncryptionMD5(string inputString)
        {

            System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();

            byte[] data = md5.ComputeHash(System.Text.Encoding.Default.GetBytes(inputString));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            System.Text.StringBuilder sBuilder = new System.Text.StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }

        /// <summary>
        /// 根据用户名生成待加密的字符串
        /// </summary>
        /// <param name="userID">登录用户名</param>
        /// <returns>待加密字符串</returns>
        public static string CreateInputString(string userID)
        {
            return userID + DateTime.Now.Ticks.ToString();
        }


        public static string Login(string userID, string password)
        {
            string result = "";
           

                //lsDicUserInfo UserInfo = new lsDicUserInfo(userID, password, ConData.WebSiteConnectionString);
                DBDic_StaffInfo DBUserInfo = new DBDic_StaffInfo(ConData.WebSiteConnectionString);
                Dic_StaffInfo UserInfo = DBUserInfo.UserInfo(userID, "", password);
                //验证用户名密码
                //验证用户名密码
                if (UserInfo.nID == 0) return result;

                if (UserInfo.strPassword != password) return result;


                //验证临时令牌是否有效,如果令牌有效则返回临时令牌，否则重新生成临时令牌
                if (ValidTokenID(UserInfo.strTokenID, Convert.ToDateTime(UserInfo.dtTokenTime), Convert.ToDateTime(UserInfo.dtLoginTime)))
                {
                    UserInfo.dtTokenTime = DateTime.Now;
                    UserInfo.dtLoginTime = DateTime.Now;
                    if (DBUserInfo.Update(UserInfo))
                    {
                        return UserInfo.strTokenID;
                    }
                }
                string tokenID = EncryptionMD5(CreateInputString(userID));
                UserInfo.strTokenID = tokenID;
                UserInfo.dtTokenTime = DateTime.Now;
                UserInfo.dtLoginTime = DateTime.Now;
                if (DBUserInfo.Update(UserInfo))
                {
                    result = UserInfo.strTokenID;
                }

            return result;
        }

        //public static bool IsLogin(string tokenID)
        //{
        //    DutyUser ui = new DutyUser(tokenID, MaxTokenSecond, MaxLoginSecond, ConData.WebSiteConnectionString);
        //    if (ui.strDutyGUID.Length > 0)
        //    {
        //        return true;
        //    }
        //    return false;
        //}



        #region 创建文件的MD5

        /// <summary> 创建文件的MD5码存储到数据库</summary>
        /// <param name="fileName">文件名</param>
        /// <param name="algName">algName 只能使用 sha1 或 md5</param>
        /// <returns></returns>
        public static string CreateMD5(string fileName, string algName)
        {
            if (!System.IO.File.Exists(fileName))
                return string.Empty;
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            byte[] hashBytes = HashData(fs, algName);
            fs.Close();
            return ByteArrayToHexString(hashBytes);
        }
        /// <summary>
        /// 哈希加密算法
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="algName"></param>
        /// <returns></returns>
        private static byte[] HashData(Stream stream, string algName)
        {
            HashAlgorithm algorithm;
            if (algName == null)
            {
                throw new ArgumentNullException("algName 不能为 null");
            }
            if (string.Compare(algName, "sha1", true) == 0)
            {
                algorithm = SHA1.Create();
            }
            else
            {
                if (string.Compare(algName, "md5", true) != 0)
                {
                    throw new Exception("algName 只能使用 sha1 或 md5");
                }
                algorithm = MD5.Create();
            }
            return algorithm.ComputeHash(stream);
        }

        /// <summary>
        /// 将字节数组转换为16进制表示的字符串
        /// </summary>
        /// <param name="buf"></param>
        /// <returns></returns>
        private static string ByteArrayToHexString(byte[] buf)
        {
            int iLen = 0;
            // 通过反射获取 MachineKeySection 中的 ByteArrayToHexString 方法，该方法用于将字节数组转换为16进制表示的字符串。  
            Type type = typeof(MachineKeySection);
            MethodInfo byteArrayToHexString = type.GetMethod("ByteArrayToHexString", BindingFlags.Static | BindingFlags.NonPublic);
            // 字节数组转换为16进制表示的字符串   
            return (string)byteArrayToHexString.Invoke(null, new object[] { buf, iLen });
        }
        #endregion

    }
}