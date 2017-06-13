namespace TianWen.Framework.HttpModules
{
    using System;
    using System.Web;
    using TianWen.Framework.Common;
    using TianWen.Framework.Log;

    public class BeginRequestInterceptor : IHttpModule
    {
        private static object _LockObj = new object();
        private static long _MaxEventNo;

        public void Dispose()
        {
        }

        private void Handle(object sender, EventArgs e)
        {
            string path = "";
            HttpApplication application = (HttpApplication) sender;
            path = application.Request.Path;
            TianWenContext context = new TianWenContext {
                URL = path,
                EventNo = NewEventNo()
            };
            ContextManager.TianWenContext = context;
            LoggerManager.Info("BeginRequest", "");
        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += new EventHandler(this.Handle);
        }

        private static string NewEventNo()
        {
            lock (_LockObj)
            {
                _MaxEventNo += 1L;
                return _MaxEventNo.ToString();
            }
        }
    }
}

