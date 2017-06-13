namespace TianWen.Logger
{
    using System;
    using System.Collections.Specialized;
    using System.Configuration;
    using System.IO;
    using TianWen.Interface;

    public class Settings
    {
        public static string DataSourceConfigFile
        {
            get
            {
                if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["DataSourceConfigFile"]))
                {
                    return Path.Combine(EnvironmentVar.ApplicationPath, ConfigurationManager.AppSettings["DataSourceConfigFile"]);
                }
                return string.Empty;
            }
        }

        public static string Log4netConfigPath
        {
            get
            {
                if ((ConfigurationManager.GetSection("TianWen/Logger") != null) && (((NameValueCollection) ConfigurationManager.GetSection("TianWen/Logger"))["Log4netConfigPath"] != null))
                {
                    return (AppDomain.CurrentDomain.BaseDirectory + @"\" + ((NameValueCollection) ConfigurationManager.GetSection("TianWen/Logger"))["Log4netConfigPath"]);
                }
                return "";
            }
        }
    }
}

