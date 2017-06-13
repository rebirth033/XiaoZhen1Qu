namespace TianWen.SystemManager
{
    using System;
    using System.Collections.Specialized;
    using System.Data;
    using TianWen.WebForm.Controls;

    public interface IDistrictDao : IDivTreeDataReader
    {
        void AddDistrict(NameValueCollection rowData);
        bool CheckDistrictNameIsExists(string districtName, int int_0);
        bool CheckDistrictNameIsExists(string districtName, string string_0);
        void DelDistrict(string districtId);
        void EditDistrict(NameValueCollection rowData);
        string GetDistrictName(string string_0);
        DataTable GetDistrictsById(string districtId);
        DataTable GetDistrictsByParent(string parentId, int level);
    }
}

