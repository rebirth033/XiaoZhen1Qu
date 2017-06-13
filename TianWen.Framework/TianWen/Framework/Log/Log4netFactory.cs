namespace TianWen.Framework.Log
{
    using log4net;
    using log4net.Appender;
    using log4net.Config;
    using log4net.Core;
    using log4net.Repository;
    using log4net.Repository.Hierarchy;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    internal class Log4netFactory : ILoggerFactory
    {
        private static Dictionary<string, IAppender> _AppenderList = new Dictionary<string, IAppender>();
        private static Dictionary<string, ILogger> _Log4netLogList = new Dictionary<string, ILogger>();
        private static Dictionary<string, ILogger> _LogList = new Dictionary<string, ILogger>();

        public Log4netFactory() : this(AppDomain.CurrentDomain.BaseDirectory + @"\Config\log4net.Config")
        {
        }

        public Log4netFactory(string configPath)
        {
            FileInfo info = new FileInfo(configPath);
            XmlConfigurator.ConfigureAndWatch(info);
            this.InitLog4net();
        }

        public void ChangeAppender(string loggerName, string appenderName)
        {
            if (!_Log4netLogList.ContainsKey(loggerName))
            {
                throw new KeyNotFoundException("找不到[" + loggerName + "]关键字！");
            }
            Logger logger = _Log4netLogList[loggerName] as Logger;
            logger.RemoveAllAppenders();
            logger.AddAppender(_AppenderList[appenderName]);
        }

        public void ChangeConfig(string xml)
        {
            MemoryStream stream = new MemoryStream(Encoding.Default.GetBytes(xml));
            XmlConfigurator.Configure(stream);
            this.Clear();
            this.InitLog4net();
        }

        public void ChangeLevel(string loggerName, string levelName)
        {
            //if (!_Log4netLogList.ContainsKey(loggerName))
            //{
            //    throw new KeyNotFoundException("找不到[" + loggerName + "]关键字！");
            //}
            //((Logger) _Log4netLogList[loggerName]).set_Level(_Log4netLogList[loggerName].get_Repository().get_LevelMap().get_Item(levelName));
        }

        private void Clear()
        {
            _AppenderList.Clear();
            _Log4netLogList.Clear();
            _LogList.Clear();
        }

        public ILogger GetLogger(string loggerName)
        {
            if (!_LogList.ContainsKey(loggerName))
            {
                throw new KeyNotFoundException("找不到[" + loggerName + "]关键字！");
            }
            return _LogList[loggerName];
        }

        private void InitLog4net()
        {
            foreach (ILoggerRepository repository in LogManager.GetAllRepositories())
            {
                log4net.Repository.Hierarchy.Hierarchy hierarchy = (log4net.Repository.Hierarchy.Hierarchy)repository;
                foreach (ILogger logger in hierarchy.GetCurrentLoggers())
                {
                    string level = (((Logger)logger).Level == null) ? string.Empty : ((Logger)logger).Level.ToString();
                    _LogList.Add(logger.Name, new Log4netLogger(logger.Name, level));
                    _Log4netLogList.Add(logger.Name, logger);
                }
                foreach (IAppender appender in hierarchy.GetAppenders())
                {
                    if ((appender != null) && (appender.Name != null))
                    {
                        _AppenderList.Add(appender.Name, appender);
                    }
                }
            }

        }

        public Dictionary<string, ILogger> LoggerList
        {
            get
            {
                return _LogList;
            }
        }
    }
}

