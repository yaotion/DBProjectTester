using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

namespace TF.WebPlatForm.Entry
{
	/// <summary>
	//����: UnitInfo
	//˵��: �������Ϣ
	/// <summary>
	public class Dic_UnitInfo
	{
		/// <summary>
		/// 
		/// <summary>
		private int m_nID;
		public int nID
		{
			get {return m_nID;}
			set {m_nID = value;}
		}
		/// <summary>
		/// 
		/// <summary>
		private string m_strID;
		public string strID
		{
			get {return m_strID;}
			set {m_strID = value;}
		}
		/// <summary>
		/// �κ�
		/// <summary>
		private string m_UnitNumber;
		public string UnitNumber
		{
			get {return m_UnitNumber;}
			set {m_UnitNumber = value;}
		}
		/// <summary>
		/// ���������
		/// <summary>
		private string m_UnitName;
		public string UnitName
		{
			get {return m_UnitName;}
			set {m_UnitName = value;}
		}
	}
    /// <summary>
    ///����: Dic_UnitInfoList
    ///˵��: �б���
    /// </summary>
    public class Dic_UnitInfoList : List<Dic_UnitInfo>
    {
        public Dic_UnitInfoList()
        { }
    }
}