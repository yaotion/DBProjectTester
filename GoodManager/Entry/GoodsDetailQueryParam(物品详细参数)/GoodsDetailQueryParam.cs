using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoodManager.Entry.GoodsDetailQueryParam_物品详细参数_
{
    /// <summary>
    /// 物品详细参数
    /// </summary>
    public class GoodsDetailQueryParam
    {
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
        private int _nBianHao;

        public int nBianHao
        {
            get { return _nBianHao; }
            set { _nBianHao = value; }
        }
        private string _WorkShopGUID;

        public string workShopGUID
        {
            get { return _WorkShopGUID; }
            set { _WorkShopGUID = value; }
        }
        private string _strOrderField;

        public string strOrderField
        {
            get { return _strOrderField; }
            set { _strOrderField = value; }
        }
    }
}
