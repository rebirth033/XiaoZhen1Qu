namespace TianWen.Exceptions
{
    using System;
    using System.Runtime.CompilerServices;

    [Serializable]
    public class ExceptionConfig
    {
        public ExceptionConfig()
        {
        }

        public ExceptionConfig(string _Code, string _Message, string _Solution)
        {
            this.Code = _Code;
            this.Message = _Message;
            this.Solution = _Solution;
        }

        public string Code { get; set; }

        public string Message { get; set; }

        public string Solution { get; set; }
    }
}

