namespace TianWen.Logger
{
    using log4net.Core;
    using log4net.Layout.Pattern;
    using System;
    using System.IO;

    internal sealed class Class21 : PatternLayoutConverter
    {
        protected override void Convert(TextWriter writer, LoggingEvent loggingEvent)
        {
            TianWenMessage messageObject = loggingEvent.MessageObject as TianWenMessage;
            if (messageObject != null)
            {
                writer.Write(messageObject.Operation);
            }
        }
    }
}

