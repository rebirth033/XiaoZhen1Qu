namespace TianWen.Framework.Log
{
    using System;
    using System.Collections.Generic;

    public interface ILoggerFactory
    {
        void ChangeAppender(string loggerName, string appenderName);
        void ChangeConfig(string xml);
        void ChangeLevel(string loggerName, string levelName);
        ILogger GetLogger(string loggerName);

        Dictionary<string, ILogger> LoggerList { get; }
    }
}

