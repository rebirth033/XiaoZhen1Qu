namespace TianWen.SystemManager
{
    using System;
    using System.Collections.Specialized;
    using System.Data;
    using System.Runtime.InteropServices;
    using TianWen.Plus4MEF;

    public interface IApplication : ITianWenComponent
    {
        void AddApplication(NameValueCollection rowData, string dbName = "");
        DataView BindApplication();
        void ChangeStatusByConfigId(string configId, bool status);
        bool CheckAppCodeIsExist(string appcode, string configId, string dbName = "Default");
        bool CheckMenuId(string appcode, string menuId, string appsysconfigid, string dbName = "Default");
        void DeleteApplicationByAppCode(string configId, string dbName = "");
        DataTable GetApplication(string appCode, string dbName = "");
        DataTable GetApplications(bool includeInvalid);
        DataTable GetApplications(string dbName = "");
        DataTable GetDbNameAndAppCode(string dbName = "Default", bool includeInvalid = true);
        string GetDbNameByAppCode(string appCode);
        void InitalParms(string appcode, string dbName = "Default");
        void ModifyApplication(NameValueCollection rowData, string dbName = "");
    }
}

