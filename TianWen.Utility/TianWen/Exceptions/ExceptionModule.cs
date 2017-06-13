namespace TianWen.Exceptions
{
    using System;
    using System.Web;

    public class ExceptionModule : IHttpModule
    {
        public void Dispose()
        {
        }

        public void Init(HttpApplication context)
        {
            context.Error += new EventHandler(this.method_0);
        }

        private void method_0(object sender, EventArgs e)
        {
            HttpApplication application = (HttpApplication) sender;
            Exception lastError = application.Server.GetLastError();
            new Class14(application.Context, lastError).ShowMessage();
        }
    }
}

