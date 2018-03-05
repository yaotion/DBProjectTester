using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoodManager.Entry.GoodStatus_物品状态类型_;
namespace GoodManager.DBUtils
{
    public interface DBReturnStateTypeInterface
    {
          List<ReturnStateType> GetStateNames();
    }
}
