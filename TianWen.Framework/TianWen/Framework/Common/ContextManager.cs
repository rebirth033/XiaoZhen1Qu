namespace TianWen.Framework.Common
{
    using System;
    using System.Web;
    using TianWen.Framework.Common.Threading;

    public sealed class ContextManager
    {
        private const string CONTEXT_KEY = "TianWen_Context";
        private static IThreadStorage httpThreadStorage = new HttpContextStorage();
        private static IThreadStorage threadStorage = new CallContextStorage();

        private ContextManager()
        {
        }

        public static void FreeNamedDataSlot(string name)
        {
            ThreadStorage.FreeNamedDataSlot(name);
        }

        public static object GetData(string name)
        {
            return ThreadStorage.GetData(name);
        }

        public static void SetData(string name, object value)
        {
            ThreadStorage.SetData(name, value);
        }

        public static TianWen.Framework.Common.TianWenContext TianWenContext
        {
            get
            {
                return (TianWen.Framework.Common.TianWenContext) GetData("TianWen_Context");
            }
            set
            {
                SetData("TianWen_Context", value);
            }
        }

        public static IThreadStorage ThreadStorage
        {
            get
            {
                if (HttpContext.Current != null)
                {
                    return httpThreadStorage;
                }
                return threadStorage;
            }
        }
    }
}

