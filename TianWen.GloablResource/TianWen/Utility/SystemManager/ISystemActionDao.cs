namespace TianWen.Utility.SystemManager
{
    using System;
    using System.Data;
    using System.Runtime.InteropServices;
    using TianWen.Plus4MEF;

    public interface ISystemActionDao : ITianWenComponent
    {
        DataTable BindSystemAction(string userId, string deptName, string startDate, string endDate, string dbName = "Default");
    }
}

