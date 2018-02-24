namespace TianWen.Framework.Common.Threading
{
    using System;
    using System.Runtime.Remoting.Messaging;

    public class CallContextStorage : IThreadStorage
    {
        public void FreeNamedDataSlot(string name)
        {
            CallContext.FreeNamedDataSlot(name);
        }

        public object GetData(string name)
        {
            return CallContext.GetData(name);
        }

        public void SetData(string name, object value)
        {
            CallContext.SetData(name, value);
        }
    }
}

