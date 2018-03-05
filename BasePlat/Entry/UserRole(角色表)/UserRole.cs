using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

namespace TF.WebPlatForm.Entry
{
	/// <summary>
	//类名: UserRole
	//说明: 用户角色
	/// <summary>
	public class UserRole
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
		private string m_strName;
		/// <summary>
		/// 
		/// <summary>
		public string strName
		{
			get {return m_strName;}
			set {m_strName = value;}
		}
	}
}
