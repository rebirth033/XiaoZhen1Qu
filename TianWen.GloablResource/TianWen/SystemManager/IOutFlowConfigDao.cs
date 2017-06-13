namespace TianWen.SystemManager
{
    using System;
    using System.Collections.Specialized;
    using System.Data;
    using System.Runtime.InteropServices;
    using TianWen.Plus4MEF;

    public interface IOutFlowConfigDao : ITianWenComponent
    {
        void AddOuterFlowConfig(NameValueCollection postData, string dbName = "Default");
        bool CheckFlowNameIsExits(string flowname, string outflowsId, string dbName = "Default");
        void DelOuterFlowConfig(string outflowsId, string dbName = "Default");
        void EditOuterFlowConfig(NameValueCollection postData, string dbName = "Default");
        DataTable FindOuterFlowConfigList(string searchExpression, string dbName = "Default");
        DataTable GetFlowname(string dbName = "Default");
        DataTable GetLocationServiceName(string outerFlowConfigName = "", string dbName = "Default");
        DataTable GetWebServiceName(string outerFlowConfigName = "", string dbName = "Default");
    }
}

