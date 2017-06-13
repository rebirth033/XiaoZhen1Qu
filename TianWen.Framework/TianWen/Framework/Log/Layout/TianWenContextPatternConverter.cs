namespace TianWen.Framework.Log.Layout
{
    using log4net.Core;
    using log4net.Layout.Pattern;
    using System;
    using System.IO;
    using System.Text;
    using TianWen.Framework.Log;

    public class TianWenContextPatternConverter : PatternLayoutConverter
    {
        protected override void Convert(TextWriter writer, LoggingEvent loggingEvent)
        {
            //TianWenLogMessage message = loggingEvent.get_MessageObject() as TianWenLogMessage;
            //if ((((message != null) && (message.TianWenContext != null)) && (message.TianWenContext.ContextCollection != null)) && (message.TianWenContext.ContextCollection.Count > 0))
            //{
            //    StringBuilder builder = new StringBuilder();
            //    for (int i = 0; i < message.TianWenContext.ContextCollection.Count; i++)
            //    {
            //        builder.Append("    " + message.TianWenContext.ContextCollection.Keys[i] + " = " + message.TianWenContext.ContextCollection[i].ToString() + writer.NewLine);
            //    }
            //    writer.Write(builder.ToString());
            //}
        }
    }
}

