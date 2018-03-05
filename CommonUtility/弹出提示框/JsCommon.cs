using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.Script.Serialization;

/// <summary>
///JsCommon 的摘要说明
/// </summary>t
namespace TF.CommonUtility
{
    public class JsCommon
    {
        public JsCommon()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }
        public static void Alert(System.Web.UI.Page msgPage, string msgString)
        {
            string tempString = msgString;
            tempString = tempString.Replace("'", "‘");
            msgPage.ClientScript.RegisterStartupScript(msgPage.ClientScript.GetType(), "dd", "<script type='text/javascript'>javascript:alert('" + tempString + "'); </script>");
        }

    }
}