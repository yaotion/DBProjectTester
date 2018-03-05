using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoodManager.Entry.GoodsQueryParam_物品查询参数_
{
   public class GoodsQueryParam
    {
        private DateTime _dtBeginTime;

        public DateTime dtBeginTime
        {
            get { return _dtBeginTime; }
            set { _dtBeginTime = value; }
        }
        private DateTime _dtEndTime;

        public DateTime dtEndTime
        {
            get { return _dtEndTime; }
            set { _dtEndTime = value; }
        }
        private int _nReturnState;

        public int nReturnState
        {
            get { return _nReturnState; }
            set { _nReturnState = value; }
        }
        private int _nLendingType;

        public int nLendingType
        {
            get { return _nLendingType; }
            set { _nLendingType = value; }
        }
        private string _strTrainmanNumber;

        public string strTrainmanNumber
        {
            get { return _strTrainmanNumber; }
            set { _strTrainmanNumber = value; }
        }
        private string _strTrainmanName;

        public string strTrainmanName
        {
            get { return _strTrainmanName; }
            set { _strTrainmanName = value; }
        }
        private string _strWorkShopGUID;

        public string strWorkShopGUID
        {
            get { return _strWorkShopGUID; }
            set { _strWorkShopGUID = value; }
        }
        private int _nLendingNumber;

        public int nLendingNumber
        {
            get { return _nLendingNumber; }
            set { _nLendingNumber = value; }
        }
    
    }
}
