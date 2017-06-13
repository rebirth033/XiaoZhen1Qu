namespace TianWen.Framework.Exceptions
{
    using System;
    using System.Text;

    internal class PubFunction
    {
        public static string GetChildException(Exception ex, bool IsFirst, string DivID, int i)
        {
            StringBuilder builder = new StringBuilder();
            if (IsFirst)
            {
                builder.Append(" <div class=\"one\">");
                builder.Append(string.Concat(new object[] { "<span onclick=\"ShowChild('", DivID, i, "',this)\">异常详细信息</span>" }));
            }
            else
            {
                builder.Append("<div class=\"two\">");
                builder.Append(string.Concat(new object[] { "<span onclick=\"ShowChild('", DivID, i, "',this)\">内部异常</span>" }));
            }
            builder.Append(string.Concat(new object[] { "<div ", IsFirst ? "" : "style=\"display: none\"", " id=\"", DivID, i, "\">" }));
            builder.Append(string.Concat(new object[] { "<div class=\"info\" id=\"Code", DivID, i, "\">" }));
            builder.Append("<span>异常编号：</span>" + ((ex.GetType() == typeof(TianWenException)) ? ((TianWenException) ex).Code : "") + "<br>");
            builder.Append("</div>");
            builder.Append(string.Concat(new object[] { "<div class=\"info\" id=\"Msg", DivID, i, "\">" }));
            builder.Append("<span>错误信息：</span>" + ex.Message.Replace("\r\n", "<br />").Replace(@"\r\n", "<br />") + "<br>");
            builder.Append("</div>");
            builder.Append(string.Concat(new object[] { "<div class=\"info\" id=\"Sol", DivID, i, "\">" }));
            builder.Append("<span>解决方案：</span>" + ((ex.GetType() == typeof(TianWenException)) ? ((TianWenException) ex).Solution : "") + "<br>");
            builder.Append("</div>");
            builder.Append(string.Concat(new object[] { "<div class=\"info\" id=\"Sta", DivID, i, "\">" }));
            builder.Append("<span>异常堆栈：</span>" + ((ex.GetType() == typeof(TianWenException)) ? ((TianWenException) ex).TopStackTrace : ex.StackTrace) + "<br>");
            builder.Append("</div>");
            if (ex.InnerException != null)
            {
                builder.Append(GetChildException(ex.InnerException, false, DivID, ++i));
            }
            builder.Append("</div>");
            builder.Append("</div>");
            return builder.ToString();
        }
    }
}

