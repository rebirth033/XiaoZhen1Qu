namespace TianWen.Logger
{
    using System;

    public interface ISecurity
    {
        string Decrypt(string Str);
        string Decrypt(string Str, string Key);
        string Encrypt(string Str);
        string Encrypt(string Str, string Key);
    }
}

