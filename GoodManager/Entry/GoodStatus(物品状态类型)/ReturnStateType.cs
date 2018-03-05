using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoodManager.Entry.GoodStatus_物品状态类型_
{
    /// <summary>
    /// 物品状态类型
    /// </summary>
    public class ReturnStateType
    {
        private int m_nid;
        /// <summary>
        /// 
        /// </summary>
        public int nid
        {
            get { return m_nid; }
            set { m_nid = value; }
        }
        private int m_nReturnStateID;
        /// <summary>
        /// 
        /// </summary>
        public int nReturnStateID
        {
            get { return m_nReturnStateID; }
            set { m_nReturnStateID = value; }
        }
        private string m_strStateName;
        /// <summary>
        /// 
        /// </summary>
        public string strStateName
        {
            get { return m_strStateName; }
            set { m_strStateName = value; }
        }
    }
}
