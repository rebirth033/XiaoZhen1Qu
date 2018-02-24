namespace TianWen.Framework.Log.Layout
{
    using log4net.Layout;
    using System;

    public class TianWenFileLayout : PatternLayout
    {
        public TianWenFileLayout()
        {
            base.AddConverter("BizType", typeof(BizTypePatternConverter));
            base.AddConverter("EventNo", typeof(EventNoPatternConverter));
            base.AddConverter("TianWenContext", typeof(TianWenContextPatternConverter));
            base.AddConverter("Description", typeof(DescriptionPatternConverter));
            base.AddConverter("ClassName", typeof(ClassNamePatternConverter));
        }
    }
}

