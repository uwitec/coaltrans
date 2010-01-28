using System;
using System.Web;
using System.Text;
using System.Web.UI.WebControls;
namespace Coal.Util
{
	/// <summary>
	/// 显示消息提示对话框。
	/// </summary>
	public class MessageBox
	{		
		/// <summary>
		/// 显示消息提示对话框
		/// </summary>
		/// <param name="page">当前页面指针，一般为this</param>
		/// <param name="msg">提示信息</param>
		//public static void  Show(System.Web.UI.Page page,string msg)
        public static void Show(string msg)
		{
            //page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript' defer>alert('" + msg.ToString() + "');</script>");
            HttpContext.Current.Response.Write("<script language='javascript'>alert('" + msg.ToString() + "');</script>");
            HttpContext.Current.Response.End();
		}

		/// <summary>
		/// 控件点击 消息确认提示框
		/// </summary>
		/// <param name="page">当前页面指针，一般为this</param>
		/// <param name="msg">提示信息</param>
		public static void  ShowConfirm(System.Web.UI.WebControls.WebControl Control,string msg)
		{
			Control.Attributes.Add("onclick", "return confirm('" + msg + "');") ;
		}

		/// <summary>
		/// 显示消息提示对话框，并进行页面跳转
		/// </summary>
		/// <param name="page">当前页面指针，一般为this</param>
		/// <param name="msg">提示信息</param>
		/// <param name="url">跳转的目标URL</param>
        //public static void ShowAndRedirect(System.Web.UI.Page page, string msg, string url)
        public static void ShowAndRedirect(string msg, string url)
		{
			StringBuilder Builder=new StringBuilder();
            Builder.Append("<script language='javascript'>");
			Builder.AppendFormat("alert('{0}');",msg);
			Builder.AppendFormat("window.location.href='{0}'",url);
			Builder.Append("</script>");
            //page.ClientScript.RegisterStartupScript(page.GetType(), "message", Builder.ToString());
            HttpContext.Current.Response.Write(Builder.ToString());
            HttpContext.Current.Response.End();
		}
		/// <summary>
		/// 输出自定义脚本信息
		/// </summary>
		/// <param name="page">当前页面指针，一般为this</param>
		/// <param name="script">输出脚本</param>
		//public static void ResponseScript(System.Web.UI.Page page,string script)
        public static void ResponseScript(string script)
		{
            //page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript' defer>" + script + "</script>");
            HttpContext.Current.Response.Write("<script language='javascript'>" + script + "</script>");         
		}

        /// <summary>
        /// 显示消息提示对话框，并输出自定义脚本信息
        /// </summary>
        /// <param name="page">当前页面指针，一般为this</param>
        /// <param name="script">输出脚本</param>
        //public static void ResponseScript(System.Web.UI.Page page,string script)
        public static void ShowAndScript(string msg, string script)
        {
            HttpContext.Current.Response.Write("<script language='javascript'>alert('" + msg + "');" + script + ";</script>");
        }

        /// <summary>
        /// 显示消息提示对话框，并返回
        /// </summary>
        /// <param name="page">当前页面指针，一般为this</param>
        /// <param name="msg">提示信息</param>
        //public static void ShowAndBack(System.Web.UI.Page page, string msg)
        public static void ShowAndBack(string msg)
        {
            //page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript' defer>alert(\"" + msg + "\");window.history.back(1);</script>");
            HttpContext.Current.Response.Write("<script language='javascript'>alert(\"" + msg + "\");window.history.back(1);</script>");
            HttpContext.Current.Response.End();
        }
	}
}
