namespace TianWen.Framework.Common
{
    using System;
    using System.Text;
    using System.Web.UI;

    public class JSFunctionString
    {
        public static string JS_Alert(string MessageText)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("<Script Language=JavaScript>").Append("\r\n");
            builder.Append("alert('").Append(MessageText).Append("');").Append("\r\n");
            builder.Append("</Script>").Append("\r\n");
            return builder.ToString();
        }

        public static string JS_Alert(string MessageText, bool IsReLoad)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("<Script Language=JavaScript>").Append("\r\n");
            builder.Append("alert('").Append(MessageText).Append("');").Append("\r\n");
            if (IsReLoad)
            {
                builder.Append("window.location.href=window.location.href");
            }
            builder.Append("</Script>").Append("\r\n");
            return builder.ToString();
        }

        public static string JS_Alert(string MessageText, string Url)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("<Script Language=JavaScript>").Append("\r\n");
            builder.Append("alert('").Append(MessageText).Append("');").Append("\r\n");
            if (!string.IsNullOrEmpty(Url))
            {
                builder.Append("window.location.href='" + Url + "'");
            }
            builder.Append("</Script>").Append("\r\n");
            return builder.ToString();
        }

        public static string JS_CloseFormScript()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("<Script Language=JavaScript>").Append("\r\n");
            builder.Append("window.close();").Append("\r\n");
            builder.Append("</Script>").Append("\r\n");
            return builder.ToString();
        }

        public static string JS_CloseFormScript(string pMessage)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("<Script Language=JavaScript>").Append("\r\n");
            builder.Append("alert('" + pMessage + "');").Append("\r\n");
            builder.Append("window.close();").Append("\r\n");
            builder.Append("</Script>").Append("\r\n");
            return builder.ToString();
        }

        public static string JS_DialogOpenerReloadScript(bool IsClosed)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("<Script Language=JavaScript>").Append("\r\n");
            builder.Append("dialogArguments.location.href = dialogArguments.location.href;").Append("\r\n");
            if (IsClosed)
            {
                builder.Append("window.close();").Append("\r\n");
            }
            builder.Append("</Script>").Append("\r\n");
            return builder.ToString();
        }

        public static string JS_DialogOpenerReloadScript(string theUrl, bool IsClosed)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("<Script Language=JavaScript>").Append("\r\n");
            builder.Append("dialogArguments.location.href = '" + theUrl + "';").Append("\r\n");
            if (IsClosed)
            {
                builder.Append("window.close();").Append("\r\n");
            }
            builder.Append("</Script>").Append("\r\n");
            return builder.ToString();
        }

        public static string JS_FormateScriptMessage(string MessageText, string Url)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("<Script Language=JavaScript>").Append("\r\n");
            builder.Append("alert('").Append(MessageText).Append("');").Append("\r\n");
            if (Url == "")
            {
                builder.Append("history.back();").Append("\r\n");
            }
            else
            {
                builder.Append("location.href = \"" + Url + "\";").Append("\r\n");
            }
            builder.Append("</Script>").Append("\r\n");
            return builder.ToString();
        }

        public static string JS_OpenerReloadScript(string theUrl, bool IsClosed)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("<Script Language=JavaScript>").Append("\r\n");
            builder.Append("opener.location.href = '" + theUrl + "';").Append("\r\n");
            if (IsClosed)
            {
                builder.Append("window.close();").Append("\r\n");
            }
            builder.Append("</Script>").Append("\r\n");
            return builder.ToString();
        }

        public static string JS_OpenFormScript(string pUrl, int pWidth, int pHeight)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("<Script Language=JavaScript>").Append("\r\n");
            builder.Append("var iNewX = (screen.availWidth - " + pWidth.ToString() + ")/2;").Append("\r\n");
            builder.Append("var iNewY = (screen.availHeight - " + pHeight.ToString() + ")/2;").Append("\r\n");
            builder.Append("var theDes = \"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=0,width=" + pWidth.ToString() + ",height=" + pHeight.ToString() + ",top=\" + iNewY + \",left=\" + iNewX;").Append("\r\n");
            builder.Append("var SubWin = window.open('" + pUrl + "','Info',theDes);").Append("\r\n");
            builder.Append("</Script>").Append("\r\n");
            return builder.ToString();
        }

        public static string JS_OpenModalDialogScript(string pUrl, int pWidth, int pHeight)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("<Script Language=JavaScript>").Append("\r\n");
            builder.Append("var iNewX = (screen.availWidth - " + pWidth.ToString() + ")/2;").Append("\r\n");
            builder.Append("var iNewY = (screen.availHeight - " + pHeight.ToString() + ")/2;").Append("\r\n");
            builder.Append("var theDes = \"dialogWidth:" + pWidth.ToString() + "px;dialogHeight:" + pHeight.ToString() + "px;edge:sunken;help:no;status:no;scroll:no;\"").Append("\r\n");
            builder.Append("var ReturnValue = window.showModalDialog('" + pUrl + "',window,theDes);").Append("\r\n");
            builder.Append("</Script>").Append("\r\n");
            return builder.ToString();
        }

        public static string JS_OpenModelessDialogScript(string pUrl, int pWidth, int pHeight)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("<Script Language=JavaScript>").Append("\r\n");
            builder.Append("var iNewX = (screen.availWidth - " + pWidth.ToString() + ")/2;").Append("\r\n");
            builder.Append("var iNewY = (screen.availHeight - " + pHeight.ToString() + ")/2;").Append("\r\n");
            builder.Append("var theDes = \"dialogWidth:" + pWidth.ToString() + "px;dialogHeight:" + pHeight.ToString() + "px;edge:sunken;help:no;status:no;scroll:no;\"").Append("\r\n");
            builder.Append("var ReturnValue = window.showModelessDialog('" + pUrl + "',window,theDes);").Append("\r\n");
            builder.Append("</Script>").Append("\r\n");
            return builder.ToString();
        }

        public static string JS_PageReloadScript()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("<Script Language=JavaScript>").Append("\r\n");
            builder.Append("window.reload();").Append("\r\n");
            builder.Append("</Script>").Append("\r\n");
            return builder.ToString();
        }

        public static string JS_PageReplace(string URL)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("<Script Language=JavaScript>").Append("\r\n");
            builder.Append("window.location.replace('" + URL + "')").Append("\r\n");
            builder.Append("</Script>").Append("\r\n");
            return builder.ToString();
        }

        public static void RegisterScript(Page page, string key, string script)
        {
            page.ClientScript.RegisterClientScriptBlock(typeof(JSFunctionString), key, script);
        }

        public static void RegisterScriptStart(Page page, string key, string script)
        {
            page.ClientScript.RegisterStartupScript(typeof(JSFunctionString), key, script);
        }
    }
}

