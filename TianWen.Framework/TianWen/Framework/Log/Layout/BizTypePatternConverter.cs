namespace TianWen.Framework.Log.Layout
{
    using log4net.Core;
    using log4net.Layout.Pattern;
    using System;
    using System.IO;
    using TianWen.Framework.Log;

    public class BizTypePatternConverter : PatternLayoutConverter
    {
        protected override void Convert(TextWriter writer, LoggingEvent loggingEvent)
        {
            //TianWenLogMessage message = loggingEvent.get_MessageObject() as TianWenLogMessage;
            //if (message != null)
            //{
            //    writer.Write(message.BizType);
            //}
        }
    }
}

