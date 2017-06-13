namespace TianWen.SystemManager
{
    using System;
    using System.Collections.Specialized;
    using System.Data;
    using System.Runtime.InteropServices;
    using TianWen.Plus4MEF;

    public interface ISystemManageConfigDao : ITianWenComponent
    {
        void AddAppSystemManageConfig(NameValueCollection rowData, string dbName = "Default");
        void DleAppSystemManageConfig(string appsysconfigId, string dbName = "Default");
        void EditAppSystemManageConfig(NameValueCollection rowData, string dbName = "Default");
        DataTable GetAppSystemManageConfig(string dbName = "Default");
        DataTable GetAppSystemManageConfigByAppcode(string appcode, string dbName = "Default");
    }
}

