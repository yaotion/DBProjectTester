using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoodManager.Entry.LendingType_物品类型_
{
    /// <summary>
    /// 物品类型
    /// </summary>
    public class LendingType
    {
        private int m_nID;
        /// <summary>
        /// 
        /// </summary>
        public int nID
        {
            get { return m_nID; }
            set { m_nID = value; }
        }
        private int m_nLendingTypeID;
        /// <summary>
        /// 
        /// </summary>
        public int nLendingTypeID
        {
            get { return m_nLendingTypeID; }
            set { m_nLendingTypeID = value; }
        }
        private string m_strLendingTypeName;
        /// <summary>
        /// 
        /// </summary>
        public string strLendingTypeName
        {
            get { return m_strLendingTypeName; }
            set { m_strLendingTypeName = value; }
        }
        private string m_strAlias;
        /// <summary>
        /// 
        /// </summary>
        public string strAlias
        {
            get { return m_strAlias; }
            set { m_strAlias = value; }
        }
    }
}
