namespace TianWen.SystemManager
{
    using System;
    using System.Collections.Specialized;
    using System.Data;
    using System.Runtime.InteropServices;
    using TianWen.Plus4MEF;

    public interface ICodeTypeDao : ITianWenComponent
    {
        void AddCodeType(NameValueCollection postData, string dbName = "Default");
        bool CheckCodeTypeNameIsExists(string typename, int codetypeId, string dbName = "Default");
        void DelCodeType(string codeTypeId, string dbName = "Default");
        void EditCodeType(NameValueCollection postData, string dbName = "Default");
        DataTable FindCodeTypeList(string appCode, string dbName = "Default");
        DataTable GetCodesForLocution(string dbName = "Default");
        DataTable GetKind(string codeTypeName = "", string dbName = "Default");
    }
}

