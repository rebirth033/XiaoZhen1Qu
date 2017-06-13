namespace TianWen.Exceptions
{
    using System;
    using System.Runtime.CompilerServices;

    internal class EventArgs0 : EventArgs
    {
        [CompilerGenerated]
        private TianWenException TianWenException_0;

        public EventArgs0(TianWenException TianWenException_1)
        {
            this.method_1(TianWenException_1);
        }

        [CompilerGenerated]
        public TianWenException method_0()
        {
            return this.TianWenException_0;
        }

        [CompilerGenerated]
        public void method_1(TianWenException TianWenException_1)
        {
            this.TianWenException_0 = TianWenException_1;
        }
    }
}

