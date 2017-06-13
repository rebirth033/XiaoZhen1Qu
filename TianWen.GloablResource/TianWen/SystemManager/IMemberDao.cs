namespace TianWen.SystemManager
{
    using System;
    using System.Data;
    using System.Runtime.InteropServices;
    using TianWen.Plus4MEF;

    public interface IMemberDao : ITianWenComponent
    {
        DataTable FillDepartment(string orgId, string dbName = "Default");
        DataTable FillDeptUsers(string deptID, string rightId, string dbName = "Default");
        DataTable FillDeptUsersExcludeGroup(string deptID, string groupID);
        DataTable FillOrganise(string dbName = "Default");
    }
}

