namespace TianWen.GlobalResource
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using TianWen.Plus4MEF;

    public interface ISystemRightDao : ITianWenComponent
    {
        int AddSystemRight(SystemRight right);
        int DeleteSystemRight(SystemRight right);
        SystemRight GetSystemRight(string rightType, string rightId);
        IList<SystemRight> GetSystemRights(string rightType);
        bool HasRight(string rightType, string rightId = "");
        int UpdateSystemRight(SystemRight right);
    }
}

