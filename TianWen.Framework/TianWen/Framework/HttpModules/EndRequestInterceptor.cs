namespace TianWen.Framework.HttpModules
{
    using System;
    using System.Web;
    using TianWen.Framework.Log;

    public class EndRequestInterceptor : IHttpModule
    {
        public void Dispose()
        {
        }

        private void Handle(object sender, EventArgs e)
        {
            LoggerManager.Info("EndRequest", "");
        }

        public void Init(HttpApplication context)
        {
            context.EndRequest += new EventHandler(this.Handle);
        }
    }
}

