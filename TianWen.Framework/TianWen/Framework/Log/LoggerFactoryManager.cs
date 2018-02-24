namespace TianWen.Framework.Log
{
    using System;
    using System.Diagnostics;

    public class LoggerFactoryManager
    {
        public static void ChangeAppender(string appenderName)
        {
            ChangeAppender(appenderName, "Default");
        }

        public static void ChangeAppender(string appenderName, string loggerName)
        {
            try
            {
                LoggerFactory.Instance.ChangeAppender(loggerName, appenderName);
            }
            catch (Exception exception)
            {
                Debugger.Log(0, typeof(LoggerFactoryManager).Name, typeof(LoggerFactoryManager).Name + ":" + exception.Message);
            }
        }

        public static void ChangeConfig(string xml)
        {
            try
            {
                LoggerFactory.Instance.ChangeConfig(xml);
            }
            catch (Exception exception)
            {
                Debugger.Log(0, typeof(LoggerFactoryManager).Name, typeof(LoggerFactoryManager).Name + ":" + exception.Message);
            }
        }

        public static void ChangeLevel(string levelName)
        {
            ChangeLevel("Default", levelName);
        }

        public static void ChangeLevel(string loggerName, string levelName)
        {
            try
            {
                LoggerFactory.Instance.ChangeLevel(loggerName, levelName);
            }
            catch (Exception exception)
            {
                Debugger.Log(0, typeof(LoggerFactoryManager).Name, typeof(LoggerFactoryManager).Name + ":" + exception.Message);
            }
        }

        public static ILogger GetLogger()
        {
            return LoggerFactory.Instance.GetLogger("Default");
        }

        public static ILogger GetLogger(string loggerName)
        {
            try
            {
                return LoggerFactory.Instance.GetLogger(loggerName);
            }
            catch (Exception exception)
            {
                Debugger.Log(0, typeof(LoggerFactoryManager).Name, typeof(LoggerFactoryManager).Name + ":" + exception.Message);
                return null;
            }
        }
    }
}

