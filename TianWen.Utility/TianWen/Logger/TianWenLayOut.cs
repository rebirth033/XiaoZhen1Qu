namespace TianWen.Logger
{
    using log4net.Core;
    using log4net.Layout;
    using log4net.Layout.Pattern;
    using log4net.Util;
    using System;
    using System.Collections;
    using System.IO;
    using System.Runtime.CompilerServices;

    public class TianWenLayOut : LayoutSkeleton
    {
        public const string DefaultConversionPattern = "%message%newline";
        public const string DetailConversionPattern = "%timestamp [%thread] %level %logger %ndc - %message%newline";
        private static readonly Hashtable hashtable_0 = new Hashtable(3);
        private readonly Hashtable hashtable_1;
        private PatternConverter patternConverter_0;
        private string string_0;

        static TianWenLayOut()
        {
            hashtable_0.Add("UserName", typeof(Class23));
            hashtable_0.Add("Operation", typeof(Class21));
            hashtable_0.Add("Topic", typeof(Class22));
            hashtable_0.Add("Description", typeof(Class20));
        }

        public TianWenLayOut() : this("%message%newline")
        {
        }

        public TianWenLayOut(string pattern)
        {
            this.hashtable_1 = new Hashtable();
            this.IgnoresException = true;
            this.string_0 = pattern;
            if (this.string_0 == null)
            {
                this.string_0 = "%message%newline";
            }
            this.ActivateOptions();
        }

        public override void ActivateOptions()
        {
            this.patternConverter_0 = this.CreatePatternParser(this.string_0).Parse();
            for (PatternConverter converter = this.patternConverter_0; converter != null; converter = converter.Next)
            {
                PatternLayoutConverter converter2 = converter as PatternLayoutConverter;
                if ((converter2 != null) && !converter2.IgnoresException)
                {
                    this.IgnoresException = false;
                    break;
                }
            }
        }

        public void AddConverter(ConverterInfo converterInfo)
        {
            this.AddConverter(converterInfo.Name, converterInfo.Type);
        }

        public void AddConverter(string name, Type type)
        {
            if (name == null)
            {
                throw new ArgumentNullException("name");
            }
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }
            if (!typeof(PatternConverter).IsAssignableFrom(type))
            {
                throw new ArgumentException("The converter type specified [" + type + "] must be a subclass of log4net.Util.PatternConverter", "type");
            }
            this.hashtable_1[name] = type;
        }

        protected virtual PatternParser CreatePatternParser(string pattern)
        {
            PatternParser parser = new PatternParser(pattern);
            foreach (DictionaryEntry entry in hashtable_0)
            {
                parser.PatternConverters[entry.Key] = entry.Value;
            }
            foreach (DictionaryEntry entry in this.hashtable_1)
            {
                parser.PatternConverters[entry.Key] = entry.Value;
            }
            return parser;
        }

        public override void Format(TextWriter writer, LoggingEvent loggingEvent)
        {
            if (writer == null)
            {
                throw new ArgumentNullException("writer");
            }
            if (loggingEvent == null)
            {
                throw new ArgumentNullException("loggingEvent");
            }
            for (PatternConverter converter = this.patternConverter_0; converter != null; converter = converter.Next)
            {
                converter.Format(writer, loggingEvent);
            }
        }

        public string ConversionPattern
        {
            get
            {
                return this.string_0;
            }
            set
            {
                this.string_0 = value;
            }
        }

        public sealed class ConverterInfo
        {
            [CompilerGenerated]
            private string string_0;
            [CompilerGenerated]
            private System.Type type_0;

            public string Name
            {
                [CompilerGenerated]
                get
                {
                    return this.string_0;
                }
                [CompilerGenerated]
                set
                {
                    this.string_0 = value;
                }
            }

            public System.Type Type
            {
                [CompilerGenerated]
                get
                {
                    return this.type_0;
                }
                [CompilerGenerated]
                set
                {
                    this.type_0 = value;
                }
            }
        }
    }
}

