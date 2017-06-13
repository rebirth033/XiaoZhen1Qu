namespace TianWen.GlobalResource
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Data;
    using System.Runtime.InteropServices;
    using TianWen.WebForm.Controls;

    public interface IDepartmentDao : IDivTreeDataReader
    {
        void AddDepartment(NameValueCollection rowData);
        bool CheckDeptAbbrBySuperDept(string deptID, string value, string superDeptID);
        bool CheckDeptNameBySuperDept(string deptID, string value, string superDeptID);
        void DeleteDepartmentByID(string ID);
        void DisableDeptTree(string deptId);
        bool ExistsDeptAbbr(string deptID, string value, string ORGANISEID);
        bool ExistsDeptName(string deptID, string value, string ORGANISEID);
        Department GetDepartment(string deptId);
        DataSet GetDepartmentDataSet(string deptId);
        DataTable GetDepartmentDataTable(string orgID, string searchExpression = "");
        DataSet GetDepartmentList(string orgId);
        IList<Department> GetDepartments();
        IList<Department> GetDepartmentsByOrgId(string orgId);
        IList<Department> GetDepartmentsByParentDepartmentId(string parentDeptId);
        IList<Department> GetDepartmentsIsEnabledByOrgId(string orgId, string status);
        IList<Department> GetDepartmentsIsEnabledByParentDepartmentId(string parentDeptId, string status);
        Department GetDeptmentList(string orgId);
        DataView GetDeptTree(string orgId);
        void ModifyDepartment(NameValueCollection rowData);
    }
}

