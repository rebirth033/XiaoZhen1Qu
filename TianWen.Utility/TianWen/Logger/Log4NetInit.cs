namespace TianWen.Logger
{
    using log4net;
    using log4net.Appender;
    using log4net.Config;
    using log4net.Core;
    using log4net.Repository.Hierarchy;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Xml;
    using TianWen.Exceptions;
    using TianWen.Interface;
    using TianWen.Plus4MEF;

    [TianWenComponent("Log4NetInit")]
    public class Log4NetInit : ILogInitHelper
    {
        private static readonly Dictionary<string, string> dictionary_0 = new Dictionary<string, string>();

        private static void smethod_0()
        {
            try
            {
                log4net.Repository.Hierarchy.Hierarchy repository = LogManager.GetRepository() as log4net.Repository.Hierarchy.Hierarchy;
                foreach (ILogger logger in repository.GetCurrentLoggers())
                {
                    foreach (IAppender appender in repository.GetLogger(logger.Name, repository.LoggerFactory).Appenders)
                    {
                        if (appender.GetType() == typeof(AdoNetAppender))
                        {
                            try
                            {
                                if (string.IsNullOrEmpty(((AdoNetAppender) appender).ConnectionString))
                                {
                                    ((AdoNetAppender) appender).ConnectionString = dictionary_0["Default"];
                                }
                                else
                                {
                                    ((AdoNetAppender) appender).ConnectionString = dictionary_0[((AdoNetAppender) appender).ConnectionString];
                                }
                                ((AdoNetAppender) appender).ActivateOptions();
                            }
                            catch (KeyNotFoundException)
                            {
                            }
                        }
                    }
                }
            }
            catch (NullReferenceException)
            {
            }
        }

        private static void smethod_1()
        {
            try
            {
                XmlDocument document = new XmlDocument();
                document.Load(Path.Combine(EnvironmentVar.ApplicationPath, TianWen.Logger.Settings.DataSourceConfigFile));
                XmlNodeList list = document.SelectNodes("//DataSource");
                if (list != null)
                {
                    foreach (XmlNode node3 in list)
                    {
                        XmlNode node2 = node3.SelectSingleNode("Name");
                        if (node2 != null)
                        {
                            string innerText = node2.InnerText;
                            XmlNode node = node3.SelectSingleNode("ConnectionString");
                            if (node != null)
                            {
                                string str = node.InnerText;
                                if (!dictionary_0.ContainsKey(innerText))
                                {
                                    dictionary_0.Add(innerText, str);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                throw ExceptionManager.Instance.CreateException("TianWen0100200035", exception);
            }
        }

        IDictionary<string, TianWen.Logger.ILog> ILogInitHelper.InitLog()
        {
            Dictionary<string, TianWen.Logger.ILog> dictionary = new Dictionary<string, TianWen.Logger.ILog>(10);
            if (string.IsNullOrEmpty(TianWen.Logger.Settings.Log4netConfigPath))
            {
                XmlDocument document = new XmlDocument();
                document.LoadXml("\r\n                    <log4net>\r\n                      <logger name=\"Default\">\r\n                        <level value=\"All\" />\r\n                        <appender-ref ref=\"RollingFileAppender\" />\r\n                      </logger>\r\n                      <appender name=\"RollingFileAppender\" type=\"log4net.Appender.RollingFileAppender\">\r\n                        <file value=\".\\TianWenLog\\\" />\r\n                        <appendToFile value=\"true\" />\r\n                        <datePattern value=\"yyyy-MM-dd&quot;\\\\TianWenErrorLog.txt&quot;\" />\r\n                        <staticLogFileName value=\"false\"></staticLogFileName>\r\n                        <rollingStyle value =\"Date\"></rollingStyle>\r\n                        <lockingModel type=\"log4net.Appender.FileAppender+MinimalLock\" />\r\n                        <layout type=\"log4net.Layout.PatternLayout\">\r\n                          <conversionPattern value=\"%date [%thread] %-5level %logger [%property{NDC}] - %message%newline\" />\r\n                        </layout>\r\n                      </appender>\r\n                    </log4net>\r\n                ");
                XmlConfigurator.Configure(document["log4net"]);
            }
            else
            {
                FileInfo configFile = new FileInfo(TianWen.Logger.Settings.Log4netConfigPath);
                XmlConfigurator.ConfigureAndWatch(configFile);
            }
            foreach (log4net.ILog log in LogManager.GetCurrentLoggers())
            {
                dictionary.Add(log.Logger.Name, new Log4netLogger(log.Logger.Name));
            }
            if (!string.IsNullOrEmpty(TianWen.Logger.Settings.DataSourceConfigFile))
            {
                smethod_1();
                if ((dictionary_0 != null) && (dictionary_0.Count > 0))
                {
                    smethod_0();
                }
            }
            return dictionary;
        }
    }
}

