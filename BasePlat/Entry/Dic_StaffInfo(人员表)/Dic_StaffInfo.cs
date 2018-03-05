using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

namespace TF.WebPlatForm.Entry
{
	/// <summary>
	//类名: Dic_StaffInfo
	//说明: 人员信息
	/// <summary>
    public class Dic_StaffInfo
	{
		private int m_nID;
		/// <summary>
		/// 
		/// <summary>
		public int nID
		{
			get {return m_nID;}
			set {m_nID = value;}
		}
		private string m_strID;
		/// <summary>
		/// 
		/// <summary>
		public string strID
		{
			get {return m_strID;}
			set {m_strID = value;}
		}
		private string m_strNumber;
		/// <summary>
		/// 人员工号
		/// <summary>
		public string strNumber
		{
			get {return m_strNumber;}
			set {m_strNumber = value;}
		}
		private string m_strName;
		/// <summary>
		/// 人员姓名
		/// <summary>
		public string strName
		{
			get {return m_strName;}
			set {m_strName = value;}
		}
		private string m_strDuty;
		/// <summary>
		/// 职务
		/// <summary>
		public string strDuty
		{
			get {return m_strDuty;}
			set {m_strDuty = value;}
		}
		private string m_strPassword;
		/// <summary>
		/// 系统登陆密码
		/// <summary>
		public string strPassword
		{
			get {return m_strPassword;}
			set {m_strPassword = value;}
		}
		private string m_strPictureFileName;
		/// <summary>
		/// 人员照片名称
		/// <summary>
		public string strPictureFileName
		{
			get {return m_strPictureFileName;}
			set {m_strPictureFileName = value;}
		}
		private DateTime m_dtTokenTime;
		/// <summary>
		/// 
		/// <summary>
		public DateTime dtTokenTime
		{
			get {return m_dtTokenTime;}
			set {m_dtTokenTime = value;}
		}
		private DateTime m_dtLoginTime;
		/// <summary>
		/// 
		/// <summary>
		public DateTime dtLoginTime
		{
			get {return m_dtLoginTime;}
			set {m_dtLoginTime = value;}
		}
		private string m_strTokenID;
		/// <summary>
		/// 
		/// <summary>
		public string strTokenID
		{
			get {return m_strTokenID;}
			set {m_strTokenID = value;}
		}
		private int m_nRoleID;
		/// <summary>
		/// 
		/// <summary>
		public int nRoleID
		{
			get {return m_nRoleID;}
			set {m_nRoleID = value;}
		}
	}
    /// <summary>
    ///类名: Dic_UnitInfoList
    ///说明: 列表类
    /// </summary>
    public class Dic_StaffInfoList : List<Dic_StaffInfo>
    {
        public Dic_StaffInfoList()
        { }
    }
}
