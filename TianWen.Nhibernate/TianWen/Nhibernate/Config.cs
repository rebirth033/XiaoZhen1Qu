namespace TianWen.Nhibernate.TianWen.Nhibernate
{
    using System;
    using System.Configuration;

    public static class Config
    {
        public static string DataSourceFile
        {
            get
            {
                return (AppDomain.CurrentDomain.BaseDirectory + @"\NHDataSources.config");
            }
        }

        public static string NhAssemblyNames
        {
            get
            {
                return ConfigurationManager.AppSettings["NHAssemblyNames"];
            }
        }

        public static string NhExts
        {
            get
            {
                if ((ConfigurationManager.AppSettings["NhExts"] != null) && (ConfigurationManager.AppSettings["NhExts"] != ""))
                {
                    return ConfigurationManager.AppSettings["NhExts"];
                }
                return "";
            }
        }
    }
}

