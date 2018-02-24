namespace TianWen.Framework.Common.Attributes
{
    using System;
    using System.Runtime.CompilerServices;

    public class FunAttribute : Attribute
    {
        public string AssamblyName { get; set; }

        public string ClassName { get; set; }

        public string DMethodName { get; set; }

        public string SMethodName { get; set; }
    }
}

