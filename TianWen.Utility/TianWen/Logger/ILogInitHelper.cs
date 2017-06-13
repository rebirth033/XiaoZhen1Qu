namespace TianWen.Logger
{
    using System.Collections.Generic;
    using TianWen.Plus4MEF;

    public interface ILogInitHelper : ITianWenComponent
    {
        IDictionary<string, ILog> InitLog();
    }
}

