namespace TianWen.Logger
{
    using log4net.Layout;
    using System;

    public class TianWenFileLayOut : PatternLayout
    {
        public TianWenFileLayOut()
        {
            base.AddConverter("Operation", typeof(Class21));
            base.AddConverter("Topic", typeof(Class22));
            base.AddConverter("UserName", typeof(Class23));
            base.AddConverter("Description", typeof(Class20));
        }
    }
}

