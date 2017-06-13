namespace TianWen.Exceptions
{
    using System;
    using System.Web;

    internal class Class14 : IViewer
    {
        private readonly Exception exception_0;
        private readonly HttpContext httpContext_0;

        public Class14(HttpContext httpContext_1, Exception exception_1)
        {
            this.httpContext_0 = httpContext_1;
            this.exception_0 = exception_1;
        }

        public void ShowMessage()
        {
            Exception innerException = this.exception_0;
            bool flag = false;
            while (innerException != null)
            {
                if ((innerException.GetType() == typeof(TianWenException)) && ((innerException.InnerException == null) || (innerException.InnerException.GetType() != typeof(TianWenException))))
                {
                    TianWenException exception2 = innerException as TianWenException;
                    new Class13(this.httpContext_0, exception2).ShowMessage();
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
                new Class12(this.httpContext_0, this.exception_0).ShowMessage();
            }
        }
    }
}

