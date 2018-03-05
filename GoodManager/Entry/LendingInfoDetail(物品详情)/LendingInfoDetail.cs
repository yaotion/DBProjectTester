using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoodManager.Entry.LendingInfoDetail_物品详情_
{

    public class LendingDetailList
    {
        public List<LendingInfoDetail> lendingDetailList;
    }
    /// <summary>
    /// 物品详情
    /// </summary>
    public class LendingInfoDetail
    {
        private string m_strLendingInfoGUID;
        private int m_nLendingType;
        private int m_strLendingExInfo;
        private int m_nReturnState;
        private DateTime? m_dtModifyTime;
        private string m_strGUID;
        private DateTime? m_dtBorrowTime;
        private int m_nID;
        private DateTime? m_dtGiveBackTime;
        private int m_nBorrowLoginType;
        private int m_nGiveBackLoginType;
        private string m_strLenderGUID;
        private string m_strBorrowTrainmanGUID;
        private string m_strGiveBackTrainmanGUID;
        private string m_strBorrowTrainmanNumber;
        private string m_strBorrowTrainmanName;
        private string m_strLenderNumber;
        private string m_strLenderName;
        private string m_strGiveBackTrainmanNumber;
        private string m_strBorrowLoginTypeName;
        private string m_strGiveBackLoginTypeName;
        private string m_strLendingTypeName;
        private string m_strAlias;
        private string m_strStateName;
        private int m_nMinutes;
        private string m_strWorkShopGUID;
        private string m_strGiveBackTrainmanName;

        /// <summary>
        /// 
        /// </summary>
        public int nLendingType
        {
            get { return m_nLendingType; }
            set { m_nLendingType = value; }
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
        public int strLendingExInfo
        {
            get { return m_strLendingExInfo; }
            set { m_strLendingExInfo = value; }
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
        public DateTime? dtModifyTime
        {
            get { return m_dtModifyTime; }
            set { m_dtModifyTime = value; }
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
        public int nID
        {
            get { return m_nID; }
            set { m_nID = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? dtBorrwoTime
        {
            get { return m_dtBorrowTime; }
            set { m_dtBorrowTime = value; }
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
        public int nBorrowVerifyType
        {
            get { return m_nBorrowLoginType; }
            set { m_nBorrowLoginType = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int nGiveBackVerifyType
        {
            get { return m_nGiveBackLoginType; }
            set { m_nGiveBackLoginType = value; }
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
        public string strTrainmanGUID
        {
            get { return m_strBorrowTrainmanGUID; }
            set { m_strBorrowTrainmanGUID = value; }
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
        public string strTrainmanNumber
        {
            get { return m_strBorrowTrainmanNumber; }
            set { m_strBorrowTrainmanNumber = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string strTrainmanName
        {
            get { return m_strBorrowTrainmanName; }
            set { m_strBorrowTrainmanName = value; }
        }
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
        public string strLenderName
        {
            get { return m_strLenderName; }
            set { m_strLenderName = value; }
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
        public string strGiveBackTrainmanName
        {
            get { return m_strGiveBackTrainmanName; }
            set { m_strGiveBackTrainmanName = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string strBorrowVerifyTypeName
        {
            get { return m_strBorrowLoginTypeName; }
            set { m_strBorrowLoginTypeName = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string strGiveBackVerifyTypeName
        {
            get { return m_strGiveBackLoginTypeName; }
            set { m_strGiveBackLoginTypeName = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string strLendingTypeName
        {
            get { return m_strLendingTypeName; }
            set { m_strLendingTypeName = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string strLendingTypeAlias
        {
            get { return m_strAlias; }
            set { m_strAlias = value; }
        }
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
        public int nKeepMunites
        {
            get { return m_nMinutes; }
            set { m_nMinutes = value; }
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
