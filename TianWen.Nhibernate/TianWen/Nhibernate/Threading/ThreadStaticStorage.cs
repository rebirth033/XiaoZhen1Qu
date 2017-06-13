namespace TianWen.Nhibernate.TianWen.Nhibernate.Threading
{
    using System;
    using System.Collections;

    public class ThreadStaticStorage : IThreadStorage
    {
        [ThreadStatic]
        private static Hashtable _data;

        public void FreeNamedDataSlot(string name)
        {
            Data.Remove(name);
        }

        public object GetData(string name)
        {
            return Data[name];
        }

        public void SetData(string name, object value)
        {
            Data[name] = value;
        }

        private static Hashtable Data
        {
            get
            {
                if (_data == null)
                {
                    _data = new Hashtable();
                }
                return _data;
            }
        }
    }
}

