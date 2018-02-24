namespace TianWen.Framework.Exceptions
{
    using System;
    using System.Web;

    public class ExceptionManager
    {
        private static ExceptionFactory _ExceptionFactory = new ExceptionFactory();
        private static ViewerManager _ViewerManager = new ViewerManager();

        private ExceptionManager()
        {
        }

        public static TianWenException CreateException(string code)
        {
            return CreateException(code, null, null);
        }

        public static TianWenException CreateException(string code, params object[] parms)
        {
            return CreateException(code, null, parms);
        }

        public static TianWenException CreateException(string code, Exception innerException)
        {
            return CreateException(code, innerException, null);
        }

        public static TianWenException CreateException(string code, Exception innerException, params object[] parms)
        {
            return _ExceptionFactory.CreateException(code, innerException, parms);
        }

        public static void Show(HttpContext context, Exception exception)
        {
            _ViewerManager.Show(context, exception);
        }
    }
}

