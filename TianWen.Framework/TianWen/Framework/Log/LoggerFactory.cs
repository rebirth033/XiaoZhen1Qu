﻿namespace TianWen.Framework.Log
{
    using System;

    internal class LoggerFactory
    {
        private static LoggerFactory _Instance = new LoggerFactory();
        private static ILoggerFactory _LoggerFactory = new Log4netFactory();

        public void ChangeAppender(string loggerName, string appenderName)
        {
            _LoggerFactory.ChangeAppender(loggerName, appenderName);
        }

        public void ChangeConfig(string xml)
        {
            _LoggerFactory.ChangeConfig(xml);
        }

        public void ChangeLevel(string loggerName, string levelName)
        {
            _LoggerFactory.ChangeLevel(loggerName, levelName);
        }

        public ILogger GetLogger(string loggerName)
        {
            return _LoggerFactory.GetLogger(loggerName);
        }

        public static LoggerFactory Instance
        {
            get
            {
                return _Instance;
            }
        }
    }
}

