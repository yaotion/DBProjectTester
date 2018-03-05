using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbUnitTest2000
{
    //表名
 public   class TabInfoClass
    {
     public string TableName { get; set; }
     public    List<fileds> FiledName { get; set; }
    }
    //表字段
 public class fileds
 {

     public string Fname { get; set; }
     public string Ftype { get; set; }

 }
}
