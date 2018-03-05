using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoodManager.Entry.LendingInfo_发放物品信息_
{
    /// <summary>
    /// 发放物品信息
    /// </summary>
  public  class LendingInfo
    {
        private string m_strStateName;
        private string m_strGiveBackLoginTypeName;
        private string m_strRemark;
        private string m_strBorrowLoginTypeName;
        private string m_strGiveBackTrainmanNumber;
        private string m_strLenderName;
        private string m_strGiveBackTrainmanName;
        private string m_strLenderNumber;
        private string m_strBorrowTrainmanName;
        private string m_strBorrowTrainmanNumber;
        private string m_strGiveBackTrainmanGUID;
        private string m_strBorrowTrainmanGUID;
        private string m_strLenderGUID;
        private string m_strGUID;
        private int m_nReturnState;
        private string m_strLendingDetail;
        private string m_strLendingInfoGUID;
        private DateTime? m_dtModifyTime;
        private DateTime? m_dtGiveBackTime;
        private int m_nBorrowLoginType;
        private DateTime? m_dtBorrowTime;
        private int m_nGiveBackLoginType;
        private string m_strWorkShopGUID;
        /// <summary>
        /// 
        /// </summary>
        public string strStateName
        {
            get { return m_strStateName; }
            set { m_strStateName = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string strGiveBackLoginName
        {
            get { return m_strGiveBackLoginTypeName; }
            set { m_strGiveBackLoginTypeName = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string strRemark
        {
            get { return m_strRemark; }
            set { m_strRemark = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string strBorrowLoginName
        {
            get { return m_strBorrowLoginTypeName; }
            set { m_strBorrowLoginTypeName = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string strGiveBackTrainmanNumber
        {
            get { return m_strGiveBackTrainmanNumber; }
            set { m_strGiveBackTrainmanNumber = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string strLenderName
        {
            get { return m_strLenderName; }
            set { m_strLenderName = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string strGiveBackTrainmanName;
        /// <summary>
        /// 
        /// </summary>
        public string strLenderNumber
        {
            get { return m_strLenderNumber; }
            set { m_strLenderNumber = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string strBorrowTrainmanName
        {
            get { return m_strBorrowTrainmanName; }
            set { m_strBorrowTrainmanName = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string strBorrowTrainmanNumber
        {
            get { return m_strBorrowTrainmanNumber; }
            set { m_strBorrowTrainmanNumber = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string strGiveBackTrainmanGUID
        {
            get { return m_strGiveBackTrainmanGUID; }
            set { m_strGiveBackTrainmanGUID = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string strBorrowTrainmanGUID
        {
            get { return m_strBorrowTrainmanGUID; }
            set { m_strBorrowTrainmanGUID = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string strLenderGUID
        {
            get { return m_strLenderGUID; }
            set { m_strLenderGUID = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string strGUID
        {
            get { return m_strGUID; }
            set { m_strGUID = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int nReturnState
        {
            get { return m_nReturnState; }
            set { m_nReturnState = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string strDetails
        {
            get { return m_strLendingDetail; }
            set { m_strLendingDetail = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string strLendingInfoGUID
        {
            get { return m_strLendingInfoGUID; }
            set { m_strLendingInfoGUID = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? dtModifyTime
        {
            get { return m_dtModifyTime; }
            set { m_dtModifyTime = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? dtGiveBackTime
        {
            get { return m_dtGiveBackTime; }
            set { m_dtGiveBackTime = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int nBorrowLoginType
        {
            get { return m_nBorrowLoginType; }
            set { m_nBorrowLoginType = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? dtBorrowTime
        {
            get { return m_dtBorrowTime; }
            set { m_dtBorrowTime = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int nGiveBackLoginType
        {
            get { return m_nGiveBackLoginType; }
            set { m_nGiveBackLoginType = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string strWorkShopGUID
        {
            get { return m_strWorkShopGUID; }
            set { m_strWorkShopGUID = value; }
        }
    }
}
