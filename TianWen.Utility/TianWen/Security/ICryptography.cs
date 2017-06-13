namespace TianWen.Security
{
    using System;
    using TianWen.Plus4MEF;

    public interface ICryptography : ITianWenComponent
    {
        string Decrypt(string encryptedData);
        string Decrypt(string string_0, string encryptedData);
        string Encrypt(string plainData);
        string Encrypt(string string_0, string plainData);
    }
}

