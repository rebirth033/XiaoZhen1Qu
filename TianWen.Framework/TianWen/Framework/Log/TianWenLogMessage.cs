namespace TianWen.Framework.Log
{
    using System;
    using System.Runtime.CompilerServices;
    using TianWen.Framework.Common;

    public class TianWenLogMessage
    {
        public TianWenLogMessage()
        {
        }

        public TianWenLogMessage(string bizType, string description)
        {
            this.BizType = bizType;
            this.Description = description;
        }

        public TianWenLogMessage(string bizType, string description, string className)
        {
            this.BizType = bizType;
            this.Description = description;
            this.ClassName = className;
        }

        public string BizType { get; set; }

        public string ClassName { get; set; }

        public string Description { get; set; }

        public string EventNo { get; set; }

        public TianWen.Framework.Common.TianWenContext TianWenContext { get; set; }
    }
}

