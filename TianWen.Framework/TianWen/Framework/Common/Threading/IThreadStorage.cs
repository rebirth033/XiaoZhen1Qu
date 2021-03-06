﻿namespace TianWen.Framework.Common.Threading
{
    using System;

    public interface IThreadStorage
    {
        void FreeNamedDataSlot(string name);
        object GetData(string name);
        void SetData(string name, object value);
    }
}

