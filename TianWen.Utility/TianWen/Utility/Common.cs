namespace TianWen.Utility
{
    using Syncfusion.Calculate;
    using System;
    using System.Collections.Specialized;
    using System.Configuration;
    using System.Net;
    using System.Web;
    using TianWen.Exceptions;

    public class Common
    {
        public const string SFALSE = "F";
        public const string STRUE = "T";

        public static string Calculate(string expression, NameValueCollection nameValues)
        {
            CalcQuick quick = new CalcQuick();
            for (int i = 0; i < nameValues.Count; i++)
            {
                quick[nameValues.GetKey(i)] = nameValues[i];
            }
            if (expression.StartsWith("="))
            {
                quick["result"] = expression;
            }
            else
            {
                quick["result"] = "= " + expression;
            }
            return quick["result"];
        }

        public static string GetAttributeByName(string sAttribute, string TipName)
        {
            string str = "[" + TipName + "]";
            string str2 = "[/" + TipName + "]";
            sAttribute = sAttribute.ToUpper();
            int index = sAttribute.IndexOf(str);
            int num2 = sAttribute.IndexOf(str2);
            if (((index > -1) && (num2 > -1)) && ((index + str.Length) < num2))
            {
                return sAttribute.Substring(index + str.Length, (num2 - index) - str.Length);
            }
            return "";
        }

        public static string GetConfigValue(string name, string defaultValue)
        {
            string str;
            try
            {
                str = ConfigurationManager.AppSettings[name];
                if (str == null)
                {
                    str = defaultValue;
                }
            }
            catch
            {
                str = defaultValue;
            }
            return str;
        }

        public static string GetFileRootPath()
        {
            string str2;
            try
            {
                string path = ConfigurationManager.AppSettings["附件目录"];
                if ((path != null) && (path != string.Empty))
                {
                    if (path.Substring(path.Length - 1, 1) != @"\")
                    {
                        path = path + @"\";
                    }
                    return path;
                }
                path = CodeCache.Instance["系统参数", "附件目录"];
                if (path.IndexOf("/") != -1)
                {
                    path = HttpContext.Current.Server.MapPath(path);
                }
                if (path.Substring(path.Length - 1, 1) != @"\")
                {
                    path = path + @"\";
                }
                str2 = path;
            }
            catch (Exception exception)
            {
                throw ExceptionManager.Instance.CreateException(exception, "TianWen0100900094");
            }
            return str2;
        }

        public static string GetLocalIPAddress()
        {
            try
            {
                return Dns.GetHostEntry(Dns.GetHostName()).AddressList[0].ToString();
            }
            catch
            {
                return string.Empty;
            }
        }

        public static string GetLocalIPAddress(string sHostName)
        {
            try
            {
                return Dns.GetHostEntry(sHostName).AddressList[0].ToString();
            }
            catch
            {
                return string.Empty;
            }
        }

        public static bool IsFalse(string value)
        {
            return (((value == "F") || (value == string.Empty)) || (value == null));
        }

        public static bool IsSqlExpression(string expression)
        {
            if (string.IsNullOrEmpty(expression))
            {
                return false;
            }
            string str = expression.ToLower();
            return (((((str.IndexOf("||''", StringComparison.Ordinal) > 0) || (str.IndexOf("|| ''", StringComparison.Ordinal) > 0)) || ((str.IndexOf(" and ", StringComparison.Ordinal) > 0) || (str.IndexOf(" or ", StringComparison.Ordinal) > 0))) || (str.IndexOf(" like ", StringComparison.OrdinalIgnoreCase) > 0)) || (str.IndexOf(" from ", StringComparison.Ordinal) > 0));
        }

        public static bool IsTrue(string value)
        {
            return (value == "T");
        }

        public static string[] SplitByComma(string value)
        {
            if (value == null)
            {
                return new string[0];
            }
            return value.Split(new char[] { ',' });
        }
    }
}

