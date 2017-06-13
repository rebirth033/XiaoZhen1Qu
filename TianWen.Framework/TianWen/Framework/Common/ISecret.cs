namespace TianWen.Framework.Common
{
    using System;

    public interface ISecret
    {
        string Decrypt(string Str);
        string Encrypt(string Str);
    }
}

