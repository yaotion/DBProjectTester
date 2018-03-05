using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoodManager.Entry.LendingTjInfo_物品统计_
{
    /// <summary>
    /// 物品统计
    /// </summary>
    public class LendingTjInfo
    {
        private int _nLendingType;

        public int nLendingType
        {
            get { return _nLendingType; }
            set { _nLendingType = value; }
        }
        private string _strLendingTypeName;

        public string strLendingTypeName
        {
            get { return _strLendingTypeName; }
            set { _strLendingTypeName = value; }
        }
        private string _strTypeAlias;

        public string strTypeAlias
        {
            get { return _strTypeAlias; }
            set { _strTypeAlias = value; }
        }
        private string _WorkName;

        public string WorkName
        {
            get { return _WorkName; }
            set { _WorkName = value; }
        }
        private int _nTotalCount;

        public int nTotalCount
        {
            get { return _nTotalCount; }
            set { _nTotalCount = value; }
        }
        private int _nNoReturnCount;

        public int nNoReturnCount
        {
            get { return _nNoReturnCount; }
            set { _nNoReturnCount = value; }
        }
    }
}
