namespace TianWen.Framework.Log.Layout
{
    using log4net.Core;
    using log4net.Layout.Pattern;
    using System;
    using System.IO;
    using TianWen.Framework.Log;

    public class DescriptionPatternConverter : PatternLayoutConverter
    {
        protected override void Convert(TextWriter writer, LoggingEvent loggingEvent)
        {
            string message = string.Empty;
            if (message != null)
            {
                writer.Write(message);
            }
        }
    }
}

