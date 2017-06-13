namespace TianWen.GlobalResource
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Data;
    using System.Runtime.InteropServices;
    using TianWen.WebForm.Controls;

    public interface IOrganizationDao : IDivTreeDataReader
    {
        void AddOrganise(NameValueCollection rowData);
        void ChangeOrgStatusByOrgId(string orgId, bool status);
        void DisableOrgTree(string orgId);
        bool ExistsColumnValue(string orgID, string column, string value);
        bool ExistsOrganiseAbbr(string orgID, string value);
        bool ExistsOrganiseCode(string orgID, string value);
        bool ExistsOrganiseName(string orgID, string value);
        DataTable FillOrgList(string dbName = "Default");
        IList<Organization> GetAllOrganization();
        IList<Organization> GetOrganises(string parentID = "0");
        Organization GetOrganisesByID(string orgID = "0");
        IList<Organization> GetOrganisesIsEnabled(string parentID, string status);
        DataSet GetOrganiseTree(string orgId);
        DataTable GetOrganiseTreeByParentID(string parentID);
        Organization GetOrganization(string orgId);
        DataSet GetOrganizationDataSet(string orgId);
        DataSet GetOrganizationList();
        IList<Organization> GetOrganizationsByOrgId(string orgId);
        DataSet GetOrgInfoByGrade();
        DataSet GetOrgInfoByStatus();
        void ModifyOrganise(NameValueCollection rowData);
        DataTable QuickSearch(string searchKey);
    }
}

