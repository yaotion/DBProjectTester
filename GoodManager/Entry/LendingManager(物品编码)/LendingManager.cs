using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoodManager.Entry.LendingManager_物品编码_
{
    /// <summary>
    /// 物品编码
    /// </summary>
    public class LendingManager
    {

        public  LendingManager()
        {
            nID = m_nID; strGUID = m_strGUID; nLendingTypeID = m_nLendingTypeID; nStartCode = m_nStartCode; nStopCode = m_nStopCode; strExceptCodes = m_strExceptCodes;
            strWorkShopGUID = m_strWorkShopGUID;
        }
        private  int m_nID;
        /// <summary>
        /// 
        /// </summary>
        public virtual int nID
        {
            get { return m_nID; }
            set { m_nID = value; }
        }
        private string m_strGUID;
        /// <summary>
        /// 
        /// </summary>
        public virtual string strGUID
        {
            get { return m_strGUID; }
            set { m_strGUID = value; }
        }
        private int m_nLendingTypeID;
        /// <summary>
        /// 
        /// </summary>
        public virtual int nLendingTypeID
        {
            get { return m_nLendingTypeID; }
            set { m_nLendingTypeID = value; }
        }
        private int m_nStartCode;
        /// <summary>
        /// 
        /// </summary>
        public virtual int nStartCode
        {
            get { return m_nStartCode; }
            set { m_nStartCode = value; }
        }
        private int m_nStopCode;
        /// <summary>
        /// 
        /// </summary>
        public virtual int nStopCode
        {
            get { return m_nStopCode; }
            set { m_nStopCode = value; }
        }
        private string m_strExceptCodes;
        /// <summary>
        /// 
        /// </summary>
        public virtual string strExceptCodes
        {
            get { return m_strExceptCodes; }
            set { m_strExceptCodes = value; }
        }
        private string m_strWorkShopGUID;
        /// <summary>
        /// 
        /// </summary>
        public virtual string strWorkShopGUID
        {
            get { return m_strWorkShopGUID; }
            set { m_strWorkShopGUID = value; }
        }
    }
}
