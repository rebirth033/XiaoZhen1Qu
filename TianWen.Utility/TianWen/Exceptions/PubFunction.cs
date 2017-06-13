namespace TianWen.Exceptions
{
    using System;
    using System.Collections.Specialized;
    using System.Configuration;
    using System.Text;
    using TianWen.Utility;

    public class PubFunction
    {
        public static string GetChildException(Exception exception_0, bool isFirst, string divId, int int_0)
        {
            StringBuilder builder = new StringBuilder();
            if (isFirst)
            {
                builder.Append(" <div class=\"one\">");
                builder.Append(string.Concat(new object[] { "<span onclick=\"ShowChild('", divId, int_0, "',this)\">异常详细信息</span>" }));
            }
            else
            {
                builder.Append("<div class=\"two\">");
                builder.Append(string.Concat(new object[] { "<span onclick=\"ShowChild('", divId, int_0, "',this)\">内部异常</span>" }));
            }
            builder.Append(string.Concat(new object[] { "<div ", isFirst ? "" : "style=\"display: none\"", " id=\"", divId, int_0, "\">" }));
            builder.Append(string.Concat(new object[] { "<div class=\"info\" id=\"Code", divId, int_0, "\">" }));
            builder.Append("<span>异常编号：</span>" + ((exception_0.GetType() == typeof(TianWenException)) ? ((TianWenException) exception_0).Code : "") + "<br>");
            builder.Append("</div>");
            builder.Append(string.Concat(new object[] { "<div class=\"info\" id=\"Msg", divId, int_0, "\">" }));
            builder.Append("<span>错误信息：</span>" + exception_0.Message.Replace("\r\n", "<br />").Replace(@"\r\n", "<br />") + "<br>");
            builder.Append("</div>");
            builder.Append(string.Concat(new object[] { "<div class=\"info\" id=\"Sol", divId, int_0, "\">" }));
            builder.Append("<span>解决方案：</span>" + ((exception_0.GetType() == typeof(TianWenException)) ? ((TianWenException) exception_0).Solution : "") + "<br>");
            builder.Append("</div>");
            builder.Append(string.Concat(new object[] { "<div class=\"info\" id=\"Sta", divId, int_0, "\">" }));
            builder.Append("<span>异常堆栈：</span>" + ((exception_0.GetType() == typeof(TianWenException)) ? ((TianWenException) exception_0).TianWenStackTrace : exception_0.StackTrace) + "<br>");
            builder.Append("</div>");
            if (exception_0.InnerException != null)
            {
                builder.Append(GetChildException(exception_0.InnerException, false, divId, ++int_0));
            }
            builder.Append("</div>");
            builder.Append("</div>");
            return builder.ToString();
        }

        public static T GetCustomSectionValue<T>(string sectionGroupName, string string_0, T defaultValue)
        {
            NameValueCollection section = GetSection(sectionGroupName);
            if (!((section == null) || string.IsNullOrEmpty(section[string_0])))
            {
                return Cast.To<T>(section[string_0], defaultValue);
            }
            return defaultValue;
        }

        public static NameValueCollection GetSection(string sectionGroupName)
        {
            return (NameValueCollection) ConfigurationManager.GetSection(sectionGroupName);
        }

        public static string GetSectionKey(NameValueCollection nameValueCollection, string string_0)
        {
            return nameValueCollection[string_0];
        }
    }
}

