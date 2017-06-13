namespace TianWen.Framework.Log.Layout
{
    using log4net.Core;
    using log4net.Layout;
    using log4net.Layout.Pattern;
    using log4net.Util;
    using System;
    using System.Collections;
    using System.IO;

    public class TianWenDbLayout : LayoutSkeleton
    {
        public const string DefaultConversionPattern = "%message%newline";
        public const string DetailConversionPattern = "%timestamp [%thread] %level %logger %ndc - %message%newline";
        private PatternConverter m_head;
        private Hashtable m_instanceRulesRegistry;
        private string m_pattern;
        private static Hashtable s_globalRulesRegistry = new Hashtable(3);

        static TianWenDbLayout()
        {
            s_globalRulesRegistry.Add("BizType", typeof(BizTypePatternConverter));
            s_globalRulesRegistry.Add("EventNo", typeof(EventNoPatternConverter));
            s_globalRulesRegistry.Add("TopContext", typeof(TianWenContextPatternConverter));
            s_globalRulesRegistry.Add("Description", typeof(DescriptionPatternConverter));
            s_globalRulesRegistry.Add("ClassName", typeof(ClassNamePatternConverter));
        }

        public TianWenDbLayout() : this("%message%newline")
        {
        }

        public TianWenDbLayout(string pattern)
        {
            this.m_instanceRulesRegistry = new Hashtable();
            //this.set_IgnoresException(true);
            this.m_pattern = pattern;
            if (this.m_pattern == null)
            {
                this.m_pattern = "%message%newline";
            }
            this.ActivateOptions();
        }

        public override void ActivateOptions()
        {
            this.m_head = this.CreatePatternParser(this.m_pattern).Parse();
            //for (PatternConverter converter = this.m_head; converter != null; converter = converter.get_Next())
            //{
            //    PatternLayoutConverter converter2 = converter as PatternLayoutConverter;
            //    //if ((converter2 != null) && !converter2.get_IgnoresException())
            //    //{
            //    //    this.set_IgnoresException(false);
            //    //    break;
            //    //}
            //}
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
            this.m_instanceRulesRegistry[name] = type;
        }

        protected virtual PatternParser CreatePatternParser(string pattern)
        {
            PatternParser parser = new PatternParser(pattern);
            //foreach (DictionaryEntry entry in s_globalRulesRegistry)
            //{
            //    parser.get_PatternConverters()[entry.Key] = entry.Value;
            //}
            //foreach (DictionaryEntry entry in this.m_instanceRulesRegistry)
            //{
            //    parser.get_PatternConverters()[entry.Key] = entry.Value;
            //}
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
            //for (PatternConverter converter = this.m_head; converter != null; converter = converter.get_Next())
            //{
            //    converter.Format(writer, loggingEvent);
            //}
        }

        public string ConversionPattern
        {
            get
            {
                return this.m_pattern;
            }
            set
            {
                this.m_pattern = value;
            }
        }

        public sealed class ConverterInfo
        {
            private string m_name;
            private System.Type m_type;

            public string Name
            {
                get
                {
                    return this.m_name;
                }
                set
                {
                    this.m_name = value;
                }
            }

            public System.Type Type
            {
                get
                {
                    return this.m_type;
                }
                set
                {
                    this.m_type = value;
                }
            }
        }
    }
}

