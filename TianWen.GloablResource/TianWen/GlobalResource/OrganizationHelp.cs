using TianWen.Interface;

namespace TianWen.GlobalResource
{
    using System;
    using System.Collections.ObjectModel;
    using System.Data;

    [Obsolete("该类已过期，请使用ComponentFactory.Get<IOrganizationDao>()来进行数据访问")]
    public class OrganizationHelp
    {
        private static IOrganizationDao iorganizationDao_0 = ComponentFactory.Get<IOrganizationDao>("OrganizationDao");
        private string string_0 = "";

        public static Organization GetAllDepartments(string orgId)
        {
            Organization organization = GetOrganization(orgId);
            organization.Departments = DepartmentHelp.GetDepartmentsByOrgId(orgId);
            return organization;
        }

        public static Collection<Organization> GetAllOrganization()
        {
            return new Collection<Organization>(iorganizationDao_0.GetAllOrganization());
        }

        public static DataSet GetOrganiseTree(string orgId)
        {
            return iorganizationDao_0.GetOrganiseTree(orgId);
        }

        public static Organization GetOrganization(string orgId)
        {
            return iorganizationDao_0.GetOrganization(orgId);
        }

        public static Organization GetOrganization(string orgId, bool recursive)
        {
            throw new NotSupportedException();
        }

        public DataSet GetOrganizationDataSet(string orgId)
        {
            return iorganizationDao_0.GetOrganizationDataSet(orgId);
        }

        public DataSet GetOrganizationList()
        {
            return iorganizationDao_0.GetOrganizationList();
        }

        public static Collection<Organization> GetOrganizations(string orgId)
        {
            return new Collection<Organization>(iorganizationDao_0.GetOrganizationsByOrgId(orgId));
        }

        [Obsolete("已过期", true)]
        public static DataTable GetOrganizations(string orgId, bool recursive)
        {
            throw new NotSupportedException();
        }

        public DataSet GetOrgInfoByGrade()
        {
            return iorganizationDao_0.GetOrgInfoByGrade();
        }

        public DataSet GetOrgInfoByStatus()
        {
            return iorganizationDao_0.GetOrgInfoByStatus();
        }

        private string method_0(string string_1, DataTable dataTable_0)
        {
            DataRow[] rowArray = dataTable_0.Select("Parentid='" + string_1 + "'");
            if (rowArray.Length > 0)
            {
                foreach (DataRow row in rowArray)
                {
                    this.string_0 = this.string_0 + "," + row["OrganiseID"].ToString();
                    this.method_0(row["OrganiseID"].ToString(), dataTable_0);
                }
            }
            return (string_1 + this.string_0.Trim());
        }
    }
}

