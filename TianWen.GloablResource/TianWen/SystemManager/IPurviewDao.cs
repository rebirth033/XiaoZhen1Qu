namespace TianWen.SystemManager
{
    using System;
    using System.Collections.Specialized;
    using System.Data;
    using System.Runtime.InteropServices;
    using TianWen.Plus4MEF;

    public interface IPurviewDao : ITianWenComponent
    {
        void AddPurview(NameValueCollection rowData, string dbName = "Default");
        bool CheckRightIdIsExist(string rightid, string dbName = "Default");
        bool CheckRightNameIsExist(string rightName, string appcode, string rightId, string dbName = "Default");
        void DelPurview(string rightId, string appCode, string dbName = "Default");
        void EditPurview(NameValueCollection rowData, string dbName = "Default");
        DataTable GetPurviewList(string appcode, string dbName = "Default");
        string GetRightType(string appCode, string dbName = "Default");
        DataView GetSystemRight(string righttype, string dbName = "Default");
    }
}

