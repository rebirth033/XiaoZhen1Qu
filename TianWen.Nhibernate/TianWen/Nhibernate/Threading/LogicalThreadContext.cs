namespace TianWen.Nhibernate.TianWen.Nhibernate.Threading
{
    using System;

    public sealed class LogicalThreadContext
    {
        private static IThreadStorage _threadStorage = new HttpContextStorage();

        private LogicalThreadContext()
        {
            throw new NotSupportedException("must not be instantiated");
        }

        public static void FreeNamedDataSlot(string name)
        {
            _threadStorage.FreeNamedDataSlot(name);
        }

        public static object GetData(string name)
        {
            return _threadStorage.GetData(name);
        }

        public static void SetData(string name, object value)
        {
            _threadStorage.SetData(name, value);
        }

        public static void SetStorage(IThreadStorage storage)
        {
            _threadStorage = storage;
        }
    }
}

