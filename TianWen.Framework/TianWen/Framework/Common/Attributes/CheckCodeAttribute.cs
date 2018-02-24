namespace TianWen.Framework.Common.Attributes
{
    using System;
    using System.Runtime.CompilerServices;

    public class CheckCodeAttribute : Attribute
    {
        public CheckType CheckCol { get; set; }

        public string CodeType { get; set; }

        public bool IsCheck { get; set; }

        public enum CheckType
        {
            CodeName,
            CodeValue
        }
    }
}

