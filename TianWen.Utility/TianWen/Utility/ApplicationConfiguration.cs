namespace TianWen.Utility
{
    using System;
    using System.Collections.Specialized;
    using System.Configuration;
    using System.Diagnostics;
    using System.IO;
    using System.Web;
    using System.Xml;
    using TianWen.Exceptions;
    using TianWen.Interface;

    public class ApplicationConfiguration : IConfigurationSectionHandler
    {
        public static string AuthenticateType;
        private const bool bool_0 = true;
        private const bool bool_1 = true;
        private static bool bool_2 = true;
        private static bool bool_3;
        private const string string_0 = "SystemFramework.Tracing.Enabled";
        private const string string_1 = "SystemFramework.Tracing.TraceFile";
        private const string string_10 = "ApplicationTraceSwitch";
        private const string string_11 = "Application error and tracing information";
        private const string string_12 = ".";
        private const string string_13 = "WebApplication";
        private static string string_14 = (AppDomain.CurrentDomain.BaseDirectory + string.Format("trace{0}.txt", DateTime.Now.ToString("yyyyMM")));
        private static string string_15 = "ApplicationTraceSwitch";
        private static string string_16 = "Application error and tracing information";
        private static string string_17;
        private static string string_18;
        private static string string_19;
        private const string string_2 = "SystemFramework.Tracing.TraceLevel";
        private static string string_20;
        private static string string_21;
        private static string string_22;
        private const string string_3 = "SystemFramework.Tracing.SwitchName";
        private const string string_4 = "SystemFramework.Tracing.SwitchDescription";
        private const string string_5 = "SystemFramework.EventLog.Enabled";
        private const string string_6 = "SystemFramework.EventLog.Machine";
        private const string string_7 = "SystemFramework.EventLog.SourceName";
        private const string string_8 = "SystemFramework.EventLog.LogLevel";
        private const string string_9 = "ApplicationTrace.txt";
        private const TraceLevel traceLevel_0 = TraceLevel.Verbose;
        private const TraceLevel traceLevel_1 = TraceLevel.Error;
        private static TraceLevel traceLevel_2 = TraceLevel.Verbose;
        private static TraceLevel traceLevel_3;

        static ApplicationConfiguration()
        {
            if (!EnvironmentVar.NoWeb)
            {
                smethod_0();
            }
        }

        public object Create(object parent, object configContext, XmlNode section)
        {
            NameValueCollection values;
            try
            {
                NameValueSectionHandler handler = new NameValueSectionHandler();
                values = (NameValueCollection) handler.Create(parent, configContext, section);
            }
            catch
            {
                values = null;
            }
            if (values == null)
            {
                bool_2 = true;
                string_14 = "ApplicationTrace.txt";
                traceLevel_2 = TraceLevel.Verbose;
                string_15 = "ApplicationTraceSwitch";
                string_16 = "Application error and tracing information";
                bool_3 = true;
                string_17 = ".";
                string_18 = "WebApplication";
                traceLevel_3 = TraceLevel.Error;
            }
            else
            {
                bool_2 = ReadSetting(values, "SystemFramework.Tracing.Enabled", true);
                string_14 = ReadSetting(values, "SystemFramework.Tracing.TraceFile", "ApplicationTrace.txt");
                traceLevel_2 = ReadSetting(values, "SystemFramework.Tracing.TraceLevel", TraceLevel.Verbose);
                string_15 = ReadSetting(values, "SystemFramework.Tracing.SwitchName", "ApplicationTraceSwitch");
                string_16 = ReadSetting(values, "SystemFramework.Tracing.SwitchDescription", "Application error and tracing information");
                bool_3 = ReadSetting(values, "SystemFramework.EventLog.Enabled", true);
                string_17 = ReadSetting(values, "SystemFramework.EventLog.Machine", ".");
                string_18 = ReadSetting(values, "SystemFramework.EventLog.SourceName", "WebApplication");
                traceLevel_3 = ReadSetting(values, "SystemFramework.EventLog.LogLevel", TraceLevel.Error);
            }
            if (!Path.IsPathRooted(string_14))
            {
                string_14 = AppRoot + @"\" + string_14;
            }
            return null;
        }

        public static bool ReadSetting(NameValueCollection settings, string string_23, bool defaultValue)
        {
            try
            {
                object obj2 = settings[string_23];
                return ((obj2 == null) ? defaultValue : Convert.ToBoolean((string) obj2));
            }
            catch
            {
                return defaultValue;
            }
        }

        public static TraceLevel ReadSetting(NameValueCollection settings, string string_23, TraceLevel defaultValue)
        {
            try
            {
                object obj2 = settings[string_23];
                return ((obj2 == null) ? defaultValue : ((TraceLevel) Convert.ToInt32((string) obj2)));
            }
            catch
            {
                return defaultValue;
            }
        }

        public static int ReadSetting(NameValueCollection settings, string string_23, int defaultValue)
        {
            try
            {
                object obj2 = settings[string_23];
                return ((obj2 == null) ? defaultValue : Convert.ToInt32((string) obj2));
            }
            catch
            {
                return defaultValue;
            }
        }

        public static string ReadSetting(NameValueCollection settings, string string_23, string defaultValue)
        {
            try
            {
                object obj2 = settings[string_23];
                return ((obj2 == null) ? defaultValue : ((string) obj2));
            }
            catch
            {
                return defaultValue;
            }
        }

        internal static void smethod_0()
        {
            if (!WebRoot.EndsWith("/"))
            {
                WebRoot = WebRoot + "/";
            }
            string_19 = EnvironmentVar.ApplicationPath;
            ConfigurationManager.GetSection("ApplicationConfiguration");
            smethod_1();
        }

        private static void smethod_1()
        {
            string_21 = AppSettingCache.Get<string>("DataSourceConfigFile", "DataSources.config");
            if (!string_21.Contains(":"))
            {
                string_21 = Path.Combine(AppRoot, string_21);
            }
            if (!File.Exists(string_21))
            {
                throw ExceptionManager.Instance.CreateException("TianWen0100200037", new object[] { string_21 });
            }
            string_22 = AppSettingCache.Get<string>("DefaultDataSourceName", "Default");
        }

        public static string AppRoot
        {
            get
            {
                return string_19;
            }
        }

        public static string DataSourceConfigFile
        {
            get
            {
                return string_21;
            }
        }

        public static string DefaultDataSourceName
        {
            get
            {
                return string_22;
            }
        }

        public static bool EventLogEnabled
        {
            get
            {
                return bool_3;
            }
        }

        public static string EventLogMachineName
        {
            get
            {
                return string_17;
            }
        }

        public static string EventLogSourceName
        {
            get
            {
                return string_18;
            }
        }

        public static TraceLevel EventLogTraceLevel
        {
            get
            {
                return traceLevel_3;
            }
        }

        public static bool TracingEnabled
        {
            get
            {
                return bool_2;
            }
        }

        public static string TracingSwitchDescription
        {
            get
            {
                return string_16;
            }
        }

        public static string TracingSwitchName
        {
            get
            {
                return string_15;
            }
        }

        public static string TracingTraceFile
        {
            get
            {
                return string_14;
            }
        }

        public static TraceLevel TracingTraceLevel
        {
            get
            {
                return traceLevel_2;
            }
        }

        public static string WebRoot
        {
            get
            {
                return (string_20 ?? HttpContext.Current.Request.ApplicationPath).ToLower();
            }
            private set
            {
                string_20 = value;
            }
        }
    }
}

