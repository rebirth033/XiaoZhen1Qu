namespace TianWen.SystemManager
{
    using System;
    using System.Collections.Specialized;
    using System.Data;
    using System.Runtime.InteropServices;
    using TianWen.Plus4MEF;

    public interface IWebConfigDao : ITianWenComponent
    {
        void AddServiceConfig(NameValueCollection postData, string dbName = "Default");
        bool CheckServiceNameExists(string serviceName, int serviceId, string dbName = "Default");
        void DelServiceConfig(string serviceId, string dbName = "Default");
        void EditServiceConfig(NameValueCollection postData, string dbName = "Default");
        DataTable FindServiceName(string searchExpression, string dbName = "Default");
        DataTable GetDdlServiceName(string dbName = "Default");
    }
}

