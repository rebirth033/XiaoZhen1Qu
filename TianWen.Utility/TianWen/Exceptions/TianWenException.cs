namespace TianWen.Exceptions
{
    using System;
    using System.Runtime.CompilerServices;

    public class TianWenException : Exception
    {
        [CompilerGenerated]
        private string string_0;
        [CompilerGenerated]
        private string string_1;
        [CompilerGenerated]
        private string string_2;

        public TianWenException()
        {
        }

        public TianWenException(string string_3, Exception innerException) : base(string_3, innerException)
        {
        }

        public TianWenException(string Code, string Message) : base(Code + " ：" + Message)
        {
            this.Code = Code;
        }

        public TianWenException(string Code, string Message, Exception innerException) : base(Code + " ：" + Message, innerException)
        {
            this.Code = Code;
        }

        public TianWenException(string Code, string Messgae, Exception innerException, string _Solution) : base(Code + " ：" + Messgae, innerException)
        {
            this.Code = Code;
            this.Solution = _Solution;
            this.TianWenStackTrace = (innerException != null) ? innerException.StackTrace : "";
        }

        public string Code
        {
            [CompilerGenerated]
            get
            {
                return this.string_0;
            }
            [CompilerGenerated]
            set
            {
                this.string_0 = value;
            }
        }

        public string Solution
        {
            [CompilerGenerated]
            get
            {
                return this.string_1;
            }
            [CompilerGenerated]
            set
            {
                this.string_1 = value;
            }
        }

        public string TianWenStackTrace
        {
            [CompilerGenerated]
            get
            {
                return this.string_2;
            }
            [CompilerGenerated]
            set
            {
                this.string_2 = value;
            }
        }
    }
}

