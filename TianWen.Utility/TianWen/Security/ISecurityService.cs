namespace TianWen.Security
{
    using System;
    using System.Runtime.InteropServices;
    using TianWen.Plus4MEF;

    public interface ISecurityService : ITianWenComponent
    {
        bool CheckPassword(string password, string encryptedPassword);
        bool CheckSN(string string_0, string string_1 = "");
        string GetSn(string xxxxx, int yyyyy, bool zzzzz);
        string OldEncryptedData2New(string encryptedData);
    }
}

