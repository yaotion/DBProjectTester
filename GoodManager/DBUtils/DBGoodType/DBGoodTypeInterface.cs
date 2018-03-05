using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoodManager.Entry.LendingType_物品类型_;
namespace GoodManager.DBUtils
{
    public interface DBGoodTypeInterface
    {
          List<LendingType> GetGoodType();
    }
}
