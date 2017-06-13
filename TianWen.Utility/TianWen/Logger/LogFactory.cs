namespace TianWen.Logger
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using TianWen.Interface;
    using TianWen.Logger.LowestLog;

    public class LogFactory
    {
        private static bool bool_0 = true;
        private static IDictionary<string, ILog> idictionary_0;
        private static ILogInitHelper ilogInitHelper_0;
        private static readonly LogFactory logFactory_0 = new LogFactory();

        static LogFactory()
        {
            Class8 class2 = new Class8 {
                bool_0 = true
            };
            smethod_0(class2);
        }

        public ILog GetLogger(string LoggerName = "Default")
        {
            ILog log;
            if (!idictionary_0.ContainsKey(LoggerName))
            {
                LoggerName = bool_0 ? "Lowest" : "Default";
            }
            try
            {
                log = idictionary_0[LoggerName];
            }
            catch (KeyNotFoundException exception)
            {
                throw new Exception("找不到日志记录器：" + LoggerName, exception);
            }
            return log;
        }

        internal static void smethod_0(Class8 class8_0)
        {
            try
            {
                ilogInitHelper_0 = class8_0.bool_0 ? ((ILogInitHelper) new Class27()) : ((ILogInitHelper) new Log4NetInit());
                if (!(bool_0 || (ilogInitHelper_0.InitLog().Count != 0)))
                {
                    return;
                }
            }
            catch
            {
                ilogInitHelper_0 = new Class27();
            }
            bool_0 = class8_0.bool_0;
            if (ilogInitHelper_0 == null)
            {
                throw new NullReferenceException("无法初始化日志组件，请联系管理员");
            }
            idictionary_0 = ilogInitHelper_0.InitLog();
        }

        public static bool InitMode
        {
            get
            {
                return bool_0;
            }
            internal set
            {
                bool_0 = value;
            }
        }

        public static LogFactory Instance
        {
            get
            {
                return logFactory_0;
            }
        }
    }
}

