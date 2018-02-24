namespace TianWen.Framework.Common.Impl
{
    using System;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Security.Cryptography;
    using System.Text;
    using System.Xml;
    using TianWen.Framework.Common;

    public class RSASecret : ISecret
    {
        public RSASecret(string publicKeyPath, string privateKeyPath)
        {
            this.PublicKeyPath = this.GetPhysicalPath(publicKeyPath);
            this.PrivateKeyPath = this.GetPhysicalPath(privateKeyPath);
        }

        private RSACryptoServiceProvider CreateRSAEncryptProvider(string publicKeyFile)
        {
            RSAParameters parameters = new RSAParameters();
            StreamReader reader = new StreamReader(publicKeyFile);
            XmlDocument document = new XmlDocument();
            document.LoadXml(reader.ReadToEnd());
            XmlElement parent = (XmlElement) document.SelectSingleNode("root");
            parameters.Modulus = this.ReadChild(parent, "Modulus");
            parameters.Exponent = this.ReadChild(parent, "Exponent");
            CspParameters parameters2 = new CspParameters {
                Flags = CspProviderFlags.UseMachineKeyStore
            };
            RSACryptoServiceProvider provider = new RSACryptoServiceProvider(parameters2);
            provider.ImportParameters(parameters);
            return provider;
        }

        private RSACryptoServiceProvider CreateRSAProvider(string privateKeyFile)
        {
            RSAParameters parameters = new RSAParameters();
            StreamReader reader = new StreamReader(privateKeyFile);
            XmlDocument document = new XmlDocument();
            document.LoadXml(reader.ReadToEnd());
            XmlElement parent = (XmlElement) document.SelectSingleNode("root");
            parameters.Modulus = this.ReadChild(parent, "Modulus");
            parameters.Exponent = this.ReadChild(parent, "Exponent");
            parameters.D = this.ReadChild(parent, "D");
            parameters.DP = this.ReadChild(parent, "DP");
            parameters.DQ = this.ReadChild(parent, "DQ");
            parameters.P = this.ReadChild(parent, "P");
            parameters.Q = this.ReadChild(parent, "Q");
            parameters.InverseQ = this.ReadChild(parent, "InverseQ");
            CspParameters parameters2 = new CspParameters {
                Flags = CspProviderFlags.UseMachineKeyStore
            };
            RSACryptoServiceProvider provider = new RSACryptoServiceProvider(parameters2);
            provider.ImportParameters(parameters);
            return provider;
        }

        public string Decrypt(string Str)
        {
            byte[] rgb = Convert.FromBase64String(Str);
            byte[] bytes = this.CreateRSAProvider(this.PrivateKeyPath).Decrypt(rgb, true);
            return new UnicodeEncoding().GetString(bytes);
        }

        public string Encrypt(string Str)
        {
            byte[] bytes = new UnicodeEncoding().GetBytes(Str);
            return Convert.ToBase64String(this.CreateRSAEncryptProvider(this.PublicKeyPath).Encrypt(bytes, true));
        }

        private string GetPhysicalPath(string path)
        {
            if (path.IndexOf(":") > -1)
            {
                return path;
            }
            return (AppDomain.CurrentDomain.BaseDirectory + @"\" + path);
        }

        private byte[] ReadChild(XmlElement parent, string name)
        {
            XmlElement element = (XmlElement) parent.SelectSingleNode(name);
            return Convert.FromBase64String(element.InnerText);
        }

        public string PrivateKeyPath { get; set; }

        public string PublicKeyPath { get; set; }
    }
}

