using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TF.GoodManager.UnitTest
{
  
       //加、减、乘、除 运算实例  
   public class Methods
   {
        

       //无参构造函数  
       public Methods() { }


       #region 加、减、乘、除 运算实现

       /// <summary>  
       /// 加法  
       /// </summary>  
       public Double add(Double a, Double b)
       {
           return a + b;
       }

       /// <summary>  
       /// 减法  
       /// </summary>  
       public int subtract(int Minuend, int Subtrahend)
       {
           //被减数-减数  
           return Minuend - Subtrahend;
       }

       /// <summary>  
       /// 乘法  
       /// </summary>  
       public int multiply(int a, int b)
       {
           return a * b;
       }

       /// <summary>  
       /// 除法  
       /// </summary>  
       public double division(double dividend, double divisor)
       {
           if (divisor == 0)
           {
               Console.WriteLine("除数不能为0，算式无意义！");
               return 0;
           }
           else
           {
               return dividend / divisor;
           }
       }
   }
 
        #endregion  

}
