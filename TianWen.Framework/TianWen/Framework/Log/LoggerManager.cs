using System.IO;

namespace TianWen.Framework.Log
{
    using System;
    using System.Diagnostics;
    using TianWen.Framework.Common;

    public class LoggerManager
    {
        public static void Debug(string bizType, string description)
        {
            Debug(bizType, description, "Default");
        }

        public static void Debug(string bizType, string description, Exception exception)
        {
            Debug(bizType, description, exception, "Default");
        }

        public static void Debug(string bizType, string description, string loggerName)
        {
            Debug(bizType, description, typeof(LoggerManager), loggerName);
        }

        public static void Debug(string bizType, string description, Type type)
        {
            Debug(bizType, description, type, "Default");
        }

        public static void Debug(string bizType, string description, Exception exception, string loggerName)
        {
            Debug(bizType, description, exception, typeof(LoggerManager), loggerName);
        }

        public static void Debug(string bizType, string description, Exception exception, Type type)
        {
            Debug(bizType, description, exception, type, "Default");
        }

        public static void Debug(string bizType, string description, Type type, string loggerName)
        {
            try
            {
                ILogger logger = LoggerFactory.Instance.GetLogger(loggerName);
                TianWenLogMessage msg = new TianWenLogMessage(bizType, description);
                if (type != null)
                {
                    msg.ClassName = type.FullName;
                }
                if (logger.IsDebugEnabled)
                {
                    msg.TianWenContext = ContextManager.TianWenContext;
                    if (ContextManager.TianWenContext != null)
                    {
                        msg.EventNo = ContextManager.TianWenContext.EventNo;
                    }
                    logger.Debug(msg);
                }
            }
            catch (Exception exception)
            {
                Debugger.Log(0, typeof(LoggerManager).Name, typeof(LoggerManager).Name + ":" + exception.Message);
            }
        }

        public static void Debug(string bizType, string description, Exception exception, Type type, string loggerName)
        {
            try
            {
                ILogger logger = LoggerFactory.Instance.GetLogger(loggerName);
                TianWenLogMessage msg = new TianWenLogMessage(bizType, description);
                if (type != null)
                {
                    msg.ClassName = type.FullName;
                }
                if (logger.IsDebugEnabled)
                {
                    msg.TianWenContext = ContextManager.TianWenContext;
                    if (ContextManager.TianWenContext != null)
                    {
                        msg.EventNo = ContextManager.TianWenContext.EventNo;
                    }
                    logger.Debug(msg, exception);
                }
            }
            catch (Exception exception2)
            {
                Debugger.Log(0, typeof(LoggerManager).Name, typeof(LoggerManager).Name + ":" + exception2.Message);
            }
        }

        public static void Error(string bizType, string description)
        {
            Error(bizType, description, "Default");
        }

        public static void Error(string bizType, string description, Exception exception)
        {
            Error(bizType, description, exception, "Default");
        }

        public static void Error(string bizType, string description, string loggerName)
        {
            Error(bizType, description, typeof(LoggerManager), loggerName);
        }

        public static void Error(string bizType, string description, Type type)
        {
            Error(bizType, description, type, "Default");
        }

        public static void Error(string bizType, string description, Exception exception, string loggerName)
        {
            Error(bizType, description, exception, typeof(LoggerManager), loggerName);
        }

        public static void Error(string bizType, string description, Exception exception, Type type)
        {
            Error(bizType, description, exception, type, "Default");
        }

        public static void Error(string bizType, string description, Type type, string loggerName)
        {
            try
            {
                ILogger logger = LoggerFactory.Instance.GetLogger(loggerName);
                TianWenLogMessage msg = new TianWenLogMessage(bizType, description);
                if (type != null)
                {
                    msg.ClassName = type.FullName;
                }
                if (logger.IsErrorEnabled)
                {
                    msg.TianWenContext = ContextManager.TianWenContext;
                    if (ContextManager.TianWenContext != null)
                    {
                        msg.EventNo = ContextManager.TianWenContext.EventNo;
                    }
                    logger.Error(msg);
                }
            }
            catch (Exception exception)
            {
                Debugger.Log(0, typeof(LoggerManager).Name, typeof(LoggerManager).Name + ":" + exception.Message);
            }
        }

        public static void Error(string bizType, string description, Exception exception, Type type, string loggerName)
        {
            try
            {
                ILogger logger = LoggerFactory.Instance.GetLogger(loggerName);
                TianWenLogMessage msg = new TianWenLogMessage(bizType, description);
                if (type != null)
                {
                    msg.ClassName = type.FullName;
                }
                if (logger.IsErrorEnabled)
                {
                    msg.TianWenContext = ContextManager.TianWenContext;
                    if (ContextManager.TianWenContext != null)
                    {
                        msg.EventNo = ContextManager.TianWenContext.EventNo;
                    }
                    logger.Error(msg, exception);
                }
            }
            catch (Exception exception2)
            {
                Debugger.Log(0, typeof(LoggerManager).Name, typeof(LoggerManager).Name + ":" + exception2.Message);
            }
        }

        public static void Fatal(string bizType, string description)
        {
            Fatal(bizType, description, "Default");
        }

        public static void Fatal(string bizType, string description, Exception exception)
        {
            Fatal(bizType, description, exception, "Default");
        }

        public static void Fatal(string bizType, string description, string loggerName)
        {
            Fatal(bizType, description, typeof(LoggerManager), loggerName);
        }

        public static void Fatal(string bizType, string description, Type type)
        {
            Fatal(bizType, description, type, "Default");
        }

        public static void Fatal(string bizType, string description, Exception exception, string loggerName)
        {
            Fatal(bizType, description, exception, typeof(LoggerManager), loggerName);
        }

        public static void Fatal(string bizType, string description, Exception exception, Type type)
        {
            Fatal(bizType, description, exception, type, "Default");
        }

        public static void Fatal(string bizType, string description, Type type, string loggerName)
        {
            try
            {
                ILogger logger = LoggerFactory.Instance.GetLogger(loggerName);
                TianWenLogMessage msg = new TianWenLogMessage(bizType, description);
                if (type != null)
                {
                    msg.ClassName = type.FullName;
                }
                if (logger.IsFatalEnabled)
                {
                    msg.TianWenContext = ContextManager.TianWenContext;
                    if (ContextManager.TianWenContext != null)
                    {
                        msg.EventNo = ContextManager.TianWenContext.EventNo;
                    }
                    logger.Fatal(msg);
                }
            }
            catch (Exception exception)
            {
                Debugger.Log(0, typeof(LoggerManager).Name, typeof(LoggerManager).Name + ":" + exception.Message);
            }
        }

        public static void Fatal(string bizType, string description, Exception exception, Type type, string loggerName)
        {
            try
            {
                ILogger logger = LoggerFactory.Instance.GetLogger(loggerName);
                TianWenLogMessage msg = new TianWenLogMessage(bizType, description);
                if (type != null)
                {
                    msg.ClassName = type.FullName;
                }
                if (logger.IsFatalEnabled)
                {
                    msg.TianWenContext = ContextManager.TianWenContext;
                    if (ContextManager.TianWenContext != null)
                    {
                        msg.EventNo = ContextManager.TianWenContext.EventNo;
                    }
                    logger.Fatal(msg, exception);
                }
            }
            catch (Exception exception2)
            {
                Debugger.Log(0, typeof(LoggerManager).Name, typeof(LoggerManager).Name + ":" + exception2.Message);
            }
        }

        public static void Info(string logtitle, string description)
        {
            Info(logtitle, description, "Default");
        }
        
        public static void Info(string logtitle, string description, string loggerName)
        {
            Info(logtitle, description, typeof(LoggerManager), loggerName);
        }

        public static void Info(string logtitle, string description, Type type, string loggerName)
        {
            string path = "c:\\log";
            if (!Directory.Exists(path))//判断是否有该文件              
                Directory.CreateDirectory(path);
            string logFileName = path + "\\Analysis"+ DateTime.Now.ToString("yyyyMMdd") + ".log";//生成日志文件  
            if (!File.Exists(logFileName))//判断日志文件是否为当天  
                File.Create(logFileName).Close();//创建文件  
            StreamWriter writer = File.AppendText(logFileName);//文件中添加文件流  
            writer.WriteLine("");
            writer.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " " + logtitle + " " + description);
            writer.Flush();
            writer.Close();

        }

        public static void Warn(string bizType, string description)
        {
            Warn(bizType, description, "Default");
        }

        public static void Warn(string bizType, string description, Exception exception)
        {
            Warn(bizType, description, exception, "Default");
        }

        public static void Warn(string bizType, string description, string loggerName)
        {
            Warn(bizType, description, typeof(LoggerManager), loggerName);
        }

        public static void Warn(string bizType, string description, Type type)
        {
            Warn(bizType, description, type, "Default");
        }

        public static void Warn(string bizType, string description, Exception exception, string loggerName)
        {
            Warn(bizType, description, exception, typeof(LoggerManager), loggerName);
        }

        public static void Warn(string bizType, string description, Exception exception, Type type)
        {
            Warn(bizType, description, exception, type, "Default");
        }

        public static void Warn(string bizType, string description, Type type, string loggerName)
        {
            try
            {
                ILogger logger = LoggerFactory.Instance.GetLogger(loggerName);
                TianWenLogMessage msg = new TianWenLogMessage(bizType, description);
                if (type != null)
                {
                    msg.ClassName = type.FullName;
                }
                if (logger.IsWarnEnabled)
                {
                    msg.TianWenContext = ContextManager.TianWenContext;
                    if (ContextManager.TianWenContext != null)
                    {
                        msg.EventNo = ContextManager.TianWenContext.EventNo;
                    }
                    logger.Warn(msg);
                }
            }
            catch (Exception exception)
            {
                Debugger.Log(0, typeof(LoggerManager).Name, typeof(LoggerManager).Name + ":" + exception.Message);
            }
        }

        public static void Warn(string bizType, string description, Exception exception, Type type, string loggerName)
        {
            try
            {
                ILogger logger = LoggerFactory.Instance.GetLogger(loggerName);
                TianWenLogMessage msg = new TianWenLogMessage(bizType, description);
                if (type != null)
                {
                    msg.ClassName = type.FullName;
                }
                if (logger.IsWarnEnabled)
                {
                    msg.TianWenContext = ContextManager.TianWenContext;
                    if (ContextManager.TianWenContext != null)
                    {
                        msg.EventNo = ContextManager.TianWenContext.EventNo;
                    }
                    logger.Warn(msg, exception);
                }
            }
            catch (Exception exception2)
            {
                Debugger.Log(0, typeof(LoggerManager).Name, typeof(LoggerManager).Name + ":" + exception2.Message);
            }
        }
    }
}

