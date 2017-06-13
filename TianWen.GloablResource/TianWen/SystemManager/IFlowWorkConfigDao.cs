namespace TianWen.SystemManager
{
    using System;
    using System.Collections.Specialized;
    using System.Data;
    using System.Runtime.InteropServices;
    using TianWen.Plus4MEF;

    public interface IFlowWorkConfigDao : ITianWenComponent
    {
        void AddFlowWorkConfig(NameValueCollection rowData, string dbName = "Default");
        bool CheckApplyKindAndTypeIsExists(string appcode, string type, string applyKind, int flowworkId, string dbName = "Default");
        void DelFlowWorkConfig(string flowworkId, string dbName = "Default");
        void EditFlowWorkConfig(NameValueCollection rowData, string dbName = "Default");
        DataTable GetAppCode(string dbName = "Default", bool includeInvalid = true);
        DataTable GetAppLyKind(string dbName = "Default");
        DataTable GetFlowWorkConfigList(string dbName = "Default", bool includeInvalid = true);
        DataTable GetTypeDataTableByAppCode();
    }
}

