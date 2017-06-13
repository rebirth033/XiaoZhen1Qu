namespace TianWen.Utility
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using TianWen.Plus4MEF;

    public interface ICodeLoad : ITianWenComponent
    {
        IDictionary<string, string> GetCodesByType(string codeType, string dbName = "");
    }
}

