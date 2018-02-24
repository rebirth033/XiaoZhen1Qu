namespace TianWen.Framework.Log
{
    using log4net;
    using log4net.Repository.Hierarchy;
    using System;

    internal class Log4netLogger : IDisposable, ILogger
    {
        private string _Level;
        private ILog _Logger;

        public Log4netLogger(ILog log)
        {
            this._Level = "";
            this._Logger = log;
            //this._Level = ((Logger) log.get_Logger()).get_Level().ToString();
        }

        public Log4netLogger(string loggerName, string level)
        {
            this._Level = "";
            this._Logger = LogManager.GetLogger(loggerName);
            this._Level = level;
        }

        public void Debug(object msg)
        {
            this._Logger.Debug(msg);
        }

        public void Debug(object msg, Exception exception)
        {
            this._Logger.Debug(msg, exception);
        }

        public void Dispose()
        {
            this._Logger = null;
        }

        public void Error(object msg)
        {
            this._Logger.Error(msg);
        }

        public void Error(object msg, Exception exception)
        {
            this._Logger.Error(msg, exception);
        }

        public void Fatal(object msg)
        {
            this._Logger.Fatal(msg);
        }

        public void Fatal(object msg, Exception exception)
        {
            this._Logger.Fatal(msg, exception);
        }

        public void Info(object msg)
        {
            //if (this._Logger.get_IsInfoEnabled())
            //{
            //    this._Logger.Info(msg);
            //}
        }

        public void Info(object msg, Exception exception)
        {
            this._Logger.Info(msg, exception);
        }

        public void Warn(object msg)
        {
            this._Logger.Warn(msg);
        }

        public void Warn(object msg, Exception exception)
        {
            this._Logger.Warn(msg, exception);
        }

        public bool IsDebugEnabled
        {
            get
            {
                return this._Logger.IsDebugEnabled;
            }
        }

        public bool IsErrorEnabled
        {
            get
            {
                return this._Logger.IsErrorEnabled;
            }
        }

        public bool IsFatalEnabled
        {
            get
            {
                return this._Logger.IsFatalEnabled;
            }
        }

        public bool IsInfoEnabled
        {
            get
            {
                return this._Logger.IsInfoEnabled;
            }
        }

        public bool IsWarnEnabled
        {
            get
            {
                return this._Logger.IsWarnEnabled;
            }
        }

        public string Level
        {
            get
            {
                return this._Level;
            }
        }

        public string Name
        {
            get
            {
                return this._Logger.Logger.Name;
            }
        }
    }
}

