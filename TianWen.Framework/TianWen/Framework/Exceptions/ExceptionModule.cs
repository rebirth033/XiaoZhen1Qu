namespace TianWen.Framework.Exceptions
{
    using System;
    using System.Web;
    using TianWen.Framework.Log;

    public class ExceptionModule : IHttpModule
    {
        private void context_Error(object sender, EventArgs e)
        {
            LoggerManager.Info("Exception", "捕获到异常。");
            HttpApplication application = (HttpApplication) sender;
            Exception lastError = application.Server.GetLastError();
            new ViewerManager().Show(application.Context, lastError);
        }

        public void Dispose()
        {
        }

        public void Init(HttpApplication context)
        {
            context.Error += new EventHandler(this.context_Error);
            LoggerManager.Info("Init", "注册全局异常捕获。");
        }
    }
}

