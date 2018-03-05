using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

namespace TF.WebPlatForm.Entry
{
	/// <summary>
	///类名: Module_Information
	///说明: URL地址
	/// </summary>
	public class Module_Information
	{
		private int m_nID;
		/// <summary>
		/// 
		/// </summary>
		public int nID
		{
			get {return m_nID;}
			set {m_nID = value;}
		}
		private string m_strURL;
		/// <summary>
		/// URL地址
		/// </summary>
		public string strURL
		{
			get {return m_strURL;}
			set {m_strURL = value;}
		}
		private string m_strUrlDescription;
		/// <summary>
		/// URL描述
		/// </summary>
		public string strUrlDescription
		{
			get {return m_strUrlDescription;}
			set {m_strUrlDescription = value;}
		}
		private int m_nParentID;
		/// <summary>
		/// 上级ID
		/// </summary>
		public int nParentID
		{
			get {return m_nParentID;}
			set {m_nParentID = value;}
		}
		private int m_nsortid;
		/// <summary>
		/// 
		/// </summary>
		public int nsortid
		{
			get {return m_nsortid;}
			set {m_nsortid = value;}
		}
		private int m__blank;
		/// <summary>
		/// 
		/// </summary>
		public int _blank
		{
			get {return m__blank;}
			set {m__blank = value;}
		}
		private string m_strIconCss;
		/// <summary>
		/// 图标样式
		/// </summary>
		public string strIconCss
		{
			get {return m_strIconCss;}
			set {m_strIconCss = value;}
		}

        private int m_nEnable;
        /// <summary>
        /// 是否启用
        /// </summary>
        public int nEnable
        {
            get { return m_nEnable; }
            set { m_nEnable = value; }
        }
	}
	/// <summary>
	///类名: Module_InformationList
	///说明: URL地址列表类
	/// </summary>
	public class Module_InformationList : List<Module_Information>
	{
		public Module_InformationList()
		{}
	}
}
