using TianWen.Interface;

namespace TianWen.GlobalResource
{
    using System;
    using System.Collections.ObjectModel;
    using System.Data;

    [Obsolete("该类已过期，请使用ComponentFactory.Get<IDepartmentDao>()来进行数据访问")]
    public class DepartmentHelp
    {
        private static IDepartmentDao idepartmentDao_0 = ComponentFactory.Get<IDepartmentDao>("DepartmentDao");

        public static Department GetDepartment(string deptId)
        {
            return idepartmentDao_0.GetDepartment(deptId);
        }

        [Obsolete("该方法已过期", true)]
        public static Department GetDepartment(string deptId, bool recursive)
        {
            throw new NotSupportedException();
        }

        public DataSet GetDepartmentDataSet(string deptId)
        {
            return idepartmentDao_0.GetDepartmentDataSet(deptId);
        }

        public DataSet GetDepartmentList(string orgId)
        {
            return idepartmentDao_0.GetDepartmentList(orgId);
        }

        public static Collection<Department> GetDepartments()
        {
            return new Collection<Department>(idepartmentDao_0.GetDepartments());
        }

        public static Collection<Department> GetDepartments(string deptId)
        {
            return new Collection<Department>(idepartmentDao_0.GetDepartmentsByParentDepartmentId(deptId));
        }

        public static Collection<Department> GetDepartmentsByOrgId(string orgId)
        {
            return new Collection<Department>(idepartmentDao_0.GetDepartmentsByOrgId(orgId));
        }
    }
}

