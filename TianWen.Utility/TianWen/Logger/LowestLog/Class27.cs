namespace TianWen.Logger.LowestLog
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using TianWen.Interface;
    using TianWen.Logger;

    internal class Class27 : ILogInitHelper
    {
        IDictionary<string, ILog> ILogInitHelper.InitLog()
        {
            Dictionary<string, ILog> dictionary = new Dictionary<string, ILog>();
            dictionary.Add("Lowest", new Class25(Path.Combine(EnvironmentVar.ApplicationPath, "TianWenLowest.log"), 0x1388));
            return dictionary;
        }
    }
}

