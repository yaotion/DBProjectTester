using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

namespace TF.WebPlatForm.Entry
{
	/// <summary>
    ///����: otherLogin
	///˵��: �ⲿ��¼��Ϣ
	/// </summary>
    public class otherLogin
	{
        
		/// <summary>
		/// �û���
		/// </summary>
        private string m_UserName;
        public string UserName
		{
            get { return m_UserName; }
            set { m_UserName = value; }
		}
        
        /// <summary>
        /// ��ɫ
        /// </summary>
        private int m_UserRole;
        public int UserRole
        {
            get { return m_UserRole; }
            set { m_UserRole = value; }
        }
        
        /// <summary>
        ///����
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
    ///����: otherLoginList
	///˵��: �ⲿ��¼��Ϣ�б�
	/// </summary>
    public class otherLoginList : List<otherLogin>
	{
        public otherLoginList()
		{}
	}
}
