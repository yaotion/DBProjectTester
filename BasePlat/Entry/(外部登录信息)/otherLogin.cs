using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

namespace TF.WebPlatForm.Entry
{
	/// <summary>
    ///类名: otherLogin
	///说明: 外部登录信息
	/// </summary>
    public class otherLogin
	{
        
		/// <summary>
		/// 用户名
		/// </summary>
        private string m_UserName;
        public string UserName
		{
            get { return m_UserName; }
            set { m_UserName = value; }
		}
        
        /// <summary>
        /// 角色
        /// </summary>
        private int m_UserRole;
        public int UserRole
        {
            get { return m_UserRole; }
            set { m_UserRole = value; }
        }
        
        /// <summary>
        ///工号
        /// </summary>
        private string m_UserNumber;
        public string UserNumber 
        {
            get { return m_UserNumber; }
            set { m_UserNumber = value; }
        }
        
        /// <summary>
        /// m_Md5pd
        /// </summary>
        private string m_Md5pd;
        public string Md5pd
        {
            get { return m_Md5pd; }
            set { m_Md5pd = value; }
        }
	}
	/// <summary>
    ///类名: otherLoginList
	///说明: 外部登录信息列表
	/// </summary>
    public class otherLoginList : List<otherLogin>
	{
        public otherLoginList()
		{}
	}
}
