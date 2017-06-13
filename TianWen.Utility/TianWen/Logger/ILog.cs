namespace TianWen.Logger
{
    using System;

    public interface ILog
    {
        void Debug(object Msg);
        void Debug(object Msg, Exception exception);
        void Error(object Msg);
        void Error(object Msg, Exception exception);
        void Fatal(object Msg);
        void Fatal(object Msg, Exception exception);
        void Info(object Msg);
        void Info(object Msg, Exception exception);
        void Warn(object Msg);
        void Warn(object Msg, Exception exception);
    }
}

