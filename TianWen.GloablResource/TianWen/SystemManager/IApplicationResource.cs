namespace TianWen.SystemManager
{
    using System;
    using System.Collections.Specialized;
    using System.Data;
    using System.Runtime.InteropServices;
    using TianWen.Plus4MEF;

    public interface IApplicationResource : ITianWenComponent
    {
        void AddApplicationResource(NameValueCollection rowData, string dbName = "");
        bool CheckCatalogNameIsExists(string appcode, string RightType, int appResourceId, string dbName = "Default");
        int CheckRightTypeIsS(string appcode, string RightType, string dbName = "Default");
        int CheckRightValueNameIsExistsForSystemPurview(string appcode, string dbName = "Default");
        void DeleteApplicationResourceByID(string appResourceId, string dbName = "");
        DataTable GetApplicationResource(string appCode, string dbName = "");
        DataTable GetApplicationResources(string dbName = "", bool includeInvalid = true);
        DataTable GetAppName(string dbName = "", bool includeInvalid = true);
        DataTable GetAppResourceByAppCode(string appCode);
        DataTable GetAppRightByRightType(string rightType, string checkList, string sourceSql, string dbName = "Default", string SeekName = null);
        string GetRigthNameValue(string RightType, string dbName = "Default");
        void ModifyApplicationResource(NameValueCollection rowData, string dbName = "");
    }
}

