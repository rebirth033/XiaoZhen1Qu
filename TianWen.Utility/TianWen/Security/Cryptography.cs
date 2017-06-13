namespace TianWen.Security
{
    using System;
    using TianWen.Interface;

    public class Cryptography
    {
        private static ICryptography icryptography_0 = ComponentFactory.Get<ICryptography>();
        private static ISecurityService isecurityService_0 = ComponentFactory.Get<ISecurityService>();
        private readonly string string_0;

        public Cryptography()
        {
            this.string_0 = string.Empty;
            icryptography_0 = ComponentFactory.Get<ICryptography>();
            isecurityService_0 = ComponentFactory.Get<ISecurityService>();
        }

        public Cryptography(bool useOldCryptography) : this(useOldCryptography, "")
        {
        }

        public Cryptography(string string_1) : this()
        {
            this.string_0 = string.IsNullOrEmpty(string_1) ? string.Empty : string_1;
        }

        public Cryptography(bool useOldCryptography, string string_1)
        {
            this.string_0 = string.Empty;
            this.string_0 = string.IsNullOrEmpty(string_1) ? string.Empty : string_1;
            icryptography_0 = ComponentFactory.Get<ICryptography>(useOldCryptography ? "WindesCrypt" : "TeaCrypt");
            isecurityService_0 = ComponentFactory.Get<ISecurityService>();
        }

        public static void CheckPassword(string password, string encryptedPassword)
        {
            isecurityService_0.CheckPassword(password, encryptedPassword);
        }

        public static bool CheckSN(string string_1)
        {
            return isecurityService_0.CheckSN(string_1, "");
        }

        [Obsolete("此方法已过期,请改用CheckSN(string sn)签名的方法", false)]
        public static bool CheckSN(string string_1, string string_2)
        {
            return isecurityService_0.CheckSN(string_1, string_2);
        }

        public string Decrypt(string encryptedData)
        {
            return icryptography_0.Decrypt(this.string_0, encryptedData);
        }

        public static string DecryptData(string encryptedData)
        {
            return icryptography_0.Decrypt(encryptedData);
        }

        public static string DecryptData(string string_1, string encryptedData)
        {
            return icryptography_0.Decrypt(string_1, encryptedData);
        }

        public string Encrypt(string plainData)
        {
            return icryptography_0.Encrypt(this.string_0, plainData);
        }

        public static string EncryptData(string plainData)
        {
            return icryptography_0.Encrypt(plainData);
        }

        public static string EncryptData(string string_1, string plainData)
        {
            return icryptography_0.Encrypt(string_1, plainData);
        }

        public static string OldEncryptedData2New(string encryptedData)
        {
            return isecurityService_0.OldEncryptedData2New(encryptedData);
        }
    }
}

