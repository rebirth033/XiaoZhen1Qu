namespace TianWen.Framework.Log
{
    using System;

    public interface ITopLogger
    {
        void Debug(string bizType, string description);
        void Debug(string bizType, string description, Exception exception);
        void Error(string bizType, string description);
        void Error(string bizType, string description, Exception exception);
        void Fatal(string bizType, string description);
        void Fatal(string bizType, string description, Exception exception);
        void Info(string bizType, string description);
        void Warn(string bizType, string description);
        void Warn(string bizType, string description, Exception exception);
    }
}

