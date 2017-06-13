namespace TianWen.Exceptions
{
    using System;
    using System.Web;

    public class ExceptionManager
    {
        private static readonly ExceptionManager exceptionManager_0 = new ExceptionManager();
        private static readonly IConfigHelp iconfigHelp_0 = smethod_0();
        private static ModuleManager moduleManager_0;
        private static readonly object object_0 = new object();

        public TianWenException CreateException(string code)
        {
            return this.CreateException(code, null, null);
        }

        public TianWenException CreateException(Exception innerException, string string_0)
        {
            if (string_0.StartsWith("TianWen"))
            {
                return this.CreateException(string_0, innerException);
            }
            TianWenException exception2 = new TianWenException(string_0, innerException);
            try
            {
                moduleManager_0 = new ModuleManager(exception2);
                moduleManager_0.DoEvent();
            }
            catch (TianWenException exception3)
            {
                return exception3;
            }
            return exception2;
        }

        public TianWenException CreateException(string code, params object[] Parms)
        {
            return this.CreateException(code, null, Parms);
        }

        public TianWenException CreateException(string code, Exception innerExceptin)
        {
            return this.CreateException(code, innerExceptin, null);
        }

        public TianWenException CreateException(string code, Exception innerExceptin, params object[] Parms)
        {
            TianWenException exception = null;
            string str = (code.StartsWith("TianWen") ? "" : "TianWen") + code;
            ExceptionConfig config = this.GetConfigHelp().Find(str);
            if ((config == null) && (innerExceptin != null))
            {
                exception = new TianWenException(innerExceptin.Message, innerExceptin);
            }
            if ((Parms != null) && (config != null))
            {
                try
                {
                    config.Message = string.Format(config.Message, Parms);
                    if (innerExceptin != null)
                    {
                        config.Message = config.Message + "," + innerExceptin.Message;
                    }
                }
                catch
                {
                    exception = new TianWenException("TianWen0102300002", string.Format("异常信息格式化错误:\n{0}", config.Message), innerExceptin);
                }
            }
            if (exception == null)
            {
                exception = (config != null) ? new TianWenException(str, config.Message, innerExceptin, config.Solution) : new TianWenException(code, "");
            }
            try
            {
                moduleManager_0 = new ModuleManager(exception);
                moduleManager_0.DoEvent();
            }
            catch (TianWenException exception3)
            {
                return exception3;
            }
            return exception;
        }

        public IConfigHelp GetConfigHelp()
        {
            return iconfigHelp_0;
        }

        public void ShowMessage(HttpContext Context, Exception exception_0)
        {
            IViewer viewer = new Class14(Context, exception_0);
            Context.ClearError();
            viewer.ShowMessage();
        }

        public string ShowTreeException(Exception exception_0)
        {
            string str = exception_0.Message + "\r\n";
            if (exception_0.InnerException != null)
            {
                str = str + this.ShowTreeException(exception_0.InnerException);
            }
            return str;
        }

        private static IConfigHelp smethod_0()
        {
            return new ConfigHelp(Settings.ConfigHelpType);
        }

        public static ExceptionManager Instance
        {
            get
            {
                lock (object_0)
                {
                    return exceptionManager_0;
                }
            }
        }
    }
}

