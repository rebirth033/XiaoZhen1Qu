namespace TianWen.Utility.SystemManager
{
    using System;
    using System.Collections.Specialized;
    using System.Data;
    using System.Runtime.InteropServices;
    using TianWen.Plus4MEF;

    public interface ISumDayConfigDao : ITianWenComponent
    {
        void AddSumDayConfig(NameValueCollection rowData, string dbName = "Default");
        void DeleteSumDayConfig(string daylighttimeId, string dbName = "Default");
        void EditSumDayConfig(NameValueCollection rowData, string dbName = "Default");
        DataTable SearchSumDay(string startDate = "", string endDate = "", string dbName = "Default");
    }
}

