namespace TianWen.Utility.SystemManager
{
    using System;
    using System.Collections.Specialized;
    using System.Data;
    using System.Runtime.InteropServices;
    using TianWen.Plus4MEF;

    public interface ICodeDao : ITianWenComponent
    {
        void AddCode(NameValueCollection data, string dbName = "");
        void DeleteCode(string ID, string dbName = "");
        bool ExistsCodeName(string ID, string typeName, string codeName, string dbName = "");
        bool ExistsTypeName(string ID, string name, string dbName = "");
        DataTable GetCodeByCodeId(string codeId, string dbName);
        DataTable GetCodes(string dbName, string type = "");
        DataTable GetCodesByTypeID(string dbName, string typeID, string searchExpression = "");
        DataTable GetCodeTypeKinds(string dbName);
        DataTable GetCodeTypes(string dbName, string kind = "");
        void ModifyCode(NameValueCollection data, string dbName = "");
    }
}

