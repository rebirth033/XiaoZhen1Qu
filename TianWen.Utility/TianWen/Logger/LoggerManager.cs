namespace TianWen.Logger
{
    using System;

    public class LoggerManager
    {
        public static void Debug(object Msg)
        {
            LogFactory.Instance.GetLogger("Default").Debug(Msg);
        }

        public static void Debug(object Msg, Exception exception)
        {
            LogFactory.Instance.GetLogger("Default").Debug(Msg, exception);
        }

        public static void Debug(object Msg, string LoggerName)
        {
            LogFactory.Instance.GetLogger(LoggerName).Debug(Msg);
        }

        public static void Debug(object Msg, Exception exception, string LoggerName)
        {
            LogFactory.Instance.GetLogger(LoggerName).Debug(Msg, exception);
        }

        public static void Error(object Msg)
        {
            LogFactory.Instance.GetLogger("Default").Error(Msg);
        }

        public static void Error(object Msg, Exception exception)
        {
            LogFactory.Instance.GetLogger("Default").Error(Msg, exception);
        }

        public static void Error(object Msg, string LoggerName)
        {
            LogFactory.Instance.GetLogger(LoggerName).Error(Msg);
        }

        public static void Error(object Msg, Exception exception, string LoggerName)
        {
            LogFactory.Instance.GetLogger(LoggerName).Error(Msg, exception);
        }

        public static void Fatal(object Msg)
        {
            LogFactory.Instance.GetLogger("Default").Fatal(Msg);
        }

        public static void Fatal(object Msg, Exception exception)
        {
            LogFactory.Instance.GetLogger("Default").Fatal(Msg, exception);
        }

        public static void Fatal(object Msg, string LoggerName)
        {
            LogFactory.Instance.GetLogger(LoggerName).Fatal(Msg);
        }

        public static void Fatal(object Msg, Exception exception, string LoggerName)
        {
            LogFactory.Instance.GetLogger(LoggerName).Fatal(Msg, exception);
        }

        public static void Info(object Msg)
        {
            LogFactory.Instance.GetLogger("Default").Info(Msg);
        }

        public static void Info(object Msg, Exception exception)
        {
            LogFactory.Instance.GetLogger("Default").Info(Msg, exception);
        }

        public static void Info(object Msg, string LoggerName)
        {
            LogFactory.Instance.GetLogger(LoggerName).Info(Msg);
        }

        public static void Info(object Msg, Exception exception, string LoggerName)
        {
            LogFactory.Instance.GetLogger(LoggerName).Info(Msg, exception);
        }

        public static void Warn(object Msg)
        {
            LogFactory.Instance.GetLogger("Default").Warn(Msg);
        }

        public static void Warn(object Msg, Exception exception)
        {
            LogFactory.Instance.GetLogger("Default").Warn(Msg, exception);
        }

        public static void Warn(object Msg, string LoggerName)
        {
            LogFactory.Instance.GetLogger(LoggerName).Warn(Msg);
        }

        public static void Warn(object Msg, Exception exception, string LoggerName)
        {
            LogFactory.Instance.GetLogger(LoggerName).Warn(Msg, exception);
        }
    }
}

