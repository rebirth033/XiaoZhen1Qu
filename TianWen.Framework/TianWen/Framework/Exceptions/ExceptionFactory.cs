namespace TianWen.Framework.Exceptions
{
    using System;
    using TianWen.Framework.Log;

    internal class ExceptionFactory
    {
        private DescriptionHelperManager _DescriptionHelperManager = new DescriptionHelperManager();

        public TianWenException CreateException(string Code)
        {
            return this.CreateException(Code, null, null);
        }

        public TianWenException CreateException(string Code, params object[] Parms)
        {
            return this.CreateException(Code, null, Parms);
        }

        public TianWenException CreateException(string Code, Exception InnerExceptin)
        {
            return this.CreateException(Code, InnerExceptin, null);
        }

        public TianWenException CreateException(string code, Exception innerException, params object[] parms)
        {
            if ((innerException != null) && (innerException.GetType() == typeof(TianWenException)))
            {
                return (TianWenException) innerException;
            }
            TianWenException exception = null;
            string str = code.StartsWith("TOP") ? code : ("TOP" + code);
            if (code.Length != 13)
            {
                LoggerManager.Error("Unknown", code + "异常编号错误!");
                return new TianWenException(code, "异常编号错误!", innerException);
            }
            ExceptionDescription description = this._DescriptionHelperManager.FindDescription(str);
            if (description == null)
            {
                string str2 = (innerException != null) ? (innerException.Message ?? "") : "找不到该错误编号，并且无异常信息！";
                LoggerManager.Error("Unknown", str2);
                return new TianWenException("", (innerException != null) ? innerException.Message : "未知异常编号以及未知异常!", innerException);
            }
            if (parms != null)
            {
                try
                {
                    description.Message = string.Format(description.Message, parms);
                }
                catch
                {
                    exception = new TianWenException("TOP0100300001", string.Format("异常信息格式化错误:\n{0}", description.Message), innerException);
                }
            }
            if (exception == null)
            {
                exception = new TianWenException(str, description.Message, innerException, description.Solution);
            }
            LoggerManager.Error("Unknown", description.Message);
            return exception;
        }
    }
}

