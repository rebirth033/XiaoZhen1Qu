namespace TianWen.Logger
{
    using log4net;
    using log4net.Core;
    using log4net.Repository;
    using log4net.Repository.Hierarchy;
    using System;
    using TianWen.Plus4MEF;

    [TianWenComponent("Log4Net")]
    public class Log4netLogger : TianWen.Logger.ILog
    {
        private readonly log4net.ILog ilog_0;

        public Log4netLogger() : this("Default")
        {
        }

        public Log4netLogger(string LoggerName)
        {
            this.ilog_0 = LogManager.GetLogger(LoggerName);
        }

        public void ChangeLevel(string level)
        {
            ILoggerRepository[] allRepositories = LogManager.GetAllRepositories();
            int index = 0;
        Label_000A:
            if (index >= allRepositories.Length)
            {
                return;
            }
            ILoggerRepository repository = allRepositories[index];
            log4net.Repository.Hierarchy.Hierarchy hierarchy = (log4net.Repository.Hierarchy.Hierarchy) repository;
            ILogger[] currentLoggers = hierarchy.GetCurrentLoggers();
            int num2 = 0;
            while (true)
            {
                if (num2 < currentLoggers.Length)
                {
                    ILogger logger = currentLoggers[num2];
                    try
                    {
                        ((Logger) logger).Level = hierarchy.LevelMap[level];
                    }
                    catch
                    {
                    }
                }
                else
                {
                    index++;
                    goto Label_000A;
                }
                num2++;
            }
        }

        public void Debug(object Msg)
        {
            this.ilog_0.Debug(Msg);
        }

        public void Debug(object Msg, Exception exception)
        {
            this.ilog_0.Debug(Msg, exception);
        }

        public void Error(object Msg)
        {
            this.ilog_0.Error(Msg);
        }

        public void Error(object Msg, Exception exception)
        {
            this.ilog_0.Error(Msg, exception);
        }

        public void Fatal(object Msg)
        {
            this.ilog_0.Fatal(Msg);
        }

        public void Fatal(object Msg, Exception exception)
        {
            this.ilog_0.Fatal(Msg, exception);
        }

        public void Info(object Msg)
        {
            this.ilog_0.Info(Msg);
        }

        public void Info(object Msg, Exception exception)
        {
            this.ilog_0.Info(Msg, exception);
        }

        public void Warn(object Msg)
        {
            this.ilog_0.Warn(Msg);
        }

        public void Warn(object Msg, Exception exception)
        {
            this.ilog_0.Warn(Msg, exception);
        }
    }
}

