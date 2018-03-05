using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;
namespace DbUnitTest2000
{
    public class AssemblyResult  
    {
        /// <summary>  
        /// 程序集名称  
        /// </summary>  
        public List<string> AssemblyName { get; set; }

        /// <summary>  
        /// 类名  
        /// </summary>  
        public List<string> ClassName { get; set; }

        /// <summary>  
        /// 类的属性  
        /// </summary>  
        public List<string> Properties { get; set; }

        /// <summary>  
        /// 类的方法  
        /// </summary>  
        public List<string> Methods { get; set; }  
    }
    public class AssemblyHandler
    {
        string path = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + @"/MyDLL/";

        /// <summary>  
        /// 获取程序集名称列表  
        /// </summary>  
        public AssemblyResult GetAssemblyName(String path)
        {
            AssemblyResult result = new AssemblyResult();
            string[] dicFileName = Directory.GetFileSystemEntries(path);
            if (dicFileName != null)
            {
                List<string> assemblyList = new List<string>();
                foreach (string name in dicFileName)
                {
                    assemblyList.Add(name.Substring(name.LastIndexOf('/') + 1));
                }
                result.AssemblyName = assemblyList;
            }
            return result;
        }

        /// <summary>  
        /// 获取程序集中的类名称  
        /// </summary>  
        /// <param name="assemblyName">程序集</param>  
        public AssemblyResult GetClassName(string assemblyName)
        {
            AssemblyResult result = new AssemblyResult();
            if (!String.IsNullOrEmpty(assemblyName))
            {
               // assemblyName = assemblyName;// path +
                Assembly assembly = Assembly.LoadFrom(assemblyName);
                Type[] ts = assembly.GetTypes();
                List<string> classList = new List<string>();
                foreach (Type t in ts)
                {
                    //classList.Add(t.Name);  
                    classList.Add(t.FullName);
                }
                result.ClassName = classList;
            }
            return result;
        }

        /// <summary>  
        /// 获取类的属性、方法  
        /// </summary>  
        /// <param name="assemblyName">程序集</param>  
        /// <param name="className">类名</param>  
        public AssemblyResult GetClassInfo(string assemblyName, string className)
        {
            AssemblyResult result = new AssemblyResult();
            if (!String.IsNullOrEmpty(assemblyName) && !String.IsNullOrEmpty(className))
            {
              //  assemblyName = path + assemblyName;
                Assembly assembly = Assembly.LoadFrom(assemblyName);
                Type type = assembly.GetType(className, true, true);
                if (type != null)
                {
                    //类的属性  
                    List<string> propertieList = new List<string>();
                    PropertyInfo[] propertyinfo = type.GetProperties(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                    foreach (PropertyInfo p in propertyinfo)
                    {
                        propertieList.Add(p.ToString());
                    }
                    result.Properties = propertieList;

                    //类的方法  
                    List<string> methods = new List<string>();
                    MethodInfo[] methodInfos = type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                    foreach (MethodInfo mi in methodInfos)
                    {
                        methods.Add(mi.Name);
                        //方法的参数  
                        //foreach (ParameterInfo p in mi.GetParameters())  
                        //{  

                        //}  
                        //方法的返回值  
                        //string returnParameter = mi.ReturnParameter.ToString();  
                    }
                    result.Methods = methods;
                }
            }
            return result;
        }
        public String GetMethodInfo(string assemblyName, string className,String methodname)
        {
           
            AssemblyResult result = new AssemblyResult();
            StringBuilder sb = new StringBuilder();
            if (!String.IsNullOrEmpty(assemblyName) && !String.IsNullOrEmpty(className))
            {
                //  assemblyName = path + assemblyName;
                Assembly assembly = Assembly.LoadFrom(assemblyName);
                Type type = assembly.GetType(className, true, true);
                if (type != null)
                {
                    

                    //类的方法  
                    List<string> methods = new List<string>();
                    MethodInfo[] methodInfos = type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                
                    foreach (MethodInfo mi in methodInfos)
                    {
                       methods.Add(mi.Name);
                        //方法的参数  
                       int csgs = 0;
                        if(mi.Name.Equals(methodname))
                        {
                       foreach (ParameterInfo p in mi.GetParameters())  
                         {
                             csgs++;
                             string csm = p.Name;
                            
                             string cslx = p.ParameterType.ToString();
                             object o = p.DefaultValue;
                             sb.Append("参数名:" + csm+Environment.NewLine);
                             sb.Append("参数类型:" + cslx + Environment.NewLine);
                             sb.Append("默认值:" + o.ToString() + Environment.NewLine);
                           

                        }  
                        }
                        //方法的返回值  
                        //string returnParameter = mi.ReturnParameter.ToString();  
                    }
                    result.Methods = methods;
                }
            }
            return sb.ToString();
        }
    }
}
