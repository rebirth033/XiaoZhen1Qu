namespace TianWen.Utility
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Runtime.InteropServices;

    public static class AppSettingCache
    {
        private static IDictionary<string, string> idictionary_0 = new Dictionary<string, string>();
        private static readonly object object_0 = new object();

        public static T Get<T>(string string_0, T defaultValue)
        {
            if (!idictionary_0.ContainsKey(string_0))
            {
                lock (idictionary_0)
                {
                    if (!idictionary_0.ContainsKey(string_0))
                    {
                        string str = ConfigurationManager.AppSettings[string_0];
                        idictionary_0.Add(string_0, str);
                    }
                }
            }
            return Cast.To<T>(idictionary_0[string_0], defaultValue);
        }
    }
}

