namespace TianWen.Framework.Log
{
    using System;

    public interface ILogger : IDisposable
    {
        void Debug(object msg);
        void Debug(object msg, Exception exception);
        void Error(object msg);
        void Error(object msg, Exception exception);
        void Fatal(object msg);
        void Fatal(object msg, Exception exception);
        void Info(object msg);
        void Info(object msg, Exception exception);
        void Warn(object msg);
        void Warn(object msg, Exception exception);

        bool IsDebugEnabled { get; }

        bool IsErrorEnabled { get; }

        bool IsFatalEnabled { get; }

        bool IsInfoEnabled { get; }

        bool IsWarnEnabled { get; }

        string Level { get; }

        string Name { get; }
    }
}

