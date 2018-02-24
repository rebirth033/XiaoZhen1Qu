namespace TianWen.Framework.Exceptions
{
    using System;
    using System.Runtime.CompilerServices;

    public class TianWenException : Exception
    {
        public TianWenException()
        {
        }

        public TianWenException(string code, string Message) : base(code + "：" + Message)
        {
            this.Code = code;
        }

        public TianWenException(string code, string message, Exception innerException) : base(code + "：" + message, innerException)
        {
            this.Code = code;
        }

        public TianWenException(string code, string messgae, Exception innerException, string solution) : base(code + "：" + messgae, innerException)
        {
            this.Code = code;
            this.Solution = solution;
            this.TopStackTrace = (innerException != null) ? innerException.StackTrace : "";
        }

        public string Code { get; set; }

        public string Solution { get; set; }

        public string TopStackTrace { get; set; }
    }
}

