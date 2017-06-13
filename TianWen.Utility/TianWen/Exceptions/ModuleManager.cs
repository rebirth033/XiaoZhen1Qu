namespace TianWen.Exceptions
{
    using System;
    using System.Collections.Generic;

    public class ModuleManager
    {
        private readonly IList<IModule> ilist_0;
        private readonly TianWenException TianWenException_0;

        public ModuleManager() : this(null)
        {
        }

        public ModuleManager(TianWenException _TianWenException)
        {
            this.ilist_0 = new List<IModule>();
            this.TianWenException_0 = _TianWenException;
            this.ilist_0.Add(new Class11());
            this.ilist_0.Add(new DbModule());
        }

        public void DoEvent()
        {
            foreach (IModule module in this.ilist_0)
            {
                try
                {
                    module.Run(this.TianWenException_0);
                }
                catch (Exception exception)
                {
                    throw new TianWenException("TianWen0102300003", "异常组件" + module.GetType() + "错误", exception, "");
                }
            }
        }
    }
}

