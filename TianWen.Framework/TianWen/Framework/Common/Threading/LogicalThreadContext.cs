namespace TianWen.Framework.Common.Threading
{
    using System;

    public sealed class LogicalThreadContext
    {
        private static IThreadStorage threadStorage = new CallContextStorage();

        private LogicalThreadContext()
        {
            throw new NotSupportedException("must not be instantiated");
        }

        public static void FreeNamedDataSlot(string name)
        {
            threadStorage.FreeNamedDataSlot(name);
        }

        public static object GetData(string name)
        {
            return threadStorage.GetData(name);
        }

        public static void SetData(string name, object value)
        {
            threadStorage.SetData(name, value);
        }

        public static void SetStorage(IThreadStorage storage)
        {
            threadStorage = storage;
        }
    }
}

