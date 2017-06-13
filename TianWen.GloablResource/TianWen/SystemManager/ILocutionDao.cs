namespace TianWen.SystemManager
{
    using System;
    using System.Collections.Specialized;
    using System.Data;
    using System.Runtime.InteropServices;
    using TianWen.Plus4MEF;

    public interface ILocutionDao : ITianWenComponent
    {
        void AddLocution(NameValueCollection rowData, string dbName = "Default");
        void DelLocution(string locutionsid, string dbName = "Default");
        void EditLocution(NameValueCollection rowData, string dbName = "Default");
        DataTable GetLocutionList(string PhraseKind, string dbName = "Default");
    }
}

