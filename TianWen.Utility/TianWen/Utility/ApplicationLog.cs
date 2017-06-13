namespace TianWen.Utility
{
    using System;
    using System.Text;
    using TianWen.Logger;

    public class ApplicationLog
    {
        public static string FormatException(Exception exception_0, string catchInfo)
        {
            StringBuilder builder = new StringBuilder(catchInfo);
            if (exception_0 != null)
            {
                builder.Append("详细错误信息：\r\n").Append(exception_0.Message).Append("\r\n").Append(exception_0.StackTrace);
            }
            return builder.ToString();
        }

        public static void WriteError(string message)
        {
            LoggerManager.Error(message);
        }

        public static void WriteInfo(string message)
        {
            LoggerManager.Info(message);
        }

        public static void WriteTrace(string message)
        {
            LoggerManager.Debug(message);
        }

        public static void WriteWarning(string message)
        {
            LoggerManager.Warn(message);
        }
    }
}

