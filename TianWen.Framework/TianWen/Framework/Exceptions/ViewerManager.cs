namespace TianWen.Framework.Exceptions
{
    using System;
    using System.Web;
    using TianWen.Framework.Exceptions.Viewer;
    using TianWen.Framework.Log;

    public class ViewerManager
    {
        public void Show(HttpContext context, Exception exception)
        {
            Exception innerException = exception;
            bool flag = false;
            while (innerException != null)
            {
                if ((innerException.GetType() == typeof(TianWenException)) && ((innerException.InnerException == null) || (innerException.InnerException.GetType() != typeof(TianWenException))))
                {
                    TianWenException TianWenException = innerException as TianWenException;
                    new TianWenExceptionViewer(context, TianWenException).Show();
                    flag = true;
                    break;
                }
                if (innerException.InnerException != null)
                {
                    innerException = innerException.InnerException;
                }
                else
                {
                    innerException = null;
                }
            }
            if (!flag)
            {
                LoggerManager.Error("UnknownError", exception.Message);
                new DefaultViewer(context, exception).Show();
            }
        }
    }
}

