using TianWen.Interface;

namespace TianWen.Utility
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using TianWen.Exceptions;

    public class CodeCache
    {
        private static ICodeLoad icodeLoad_0 = ComponentFactory.Get<ICodeLoad>();
        private readonly IDictionary<string, Dictionary<string, string>> idictionary_0 = new Dictionary<string, Dictionary<string, string>>(10);
        private static readonly IDictionary<string, CodeCache> idictionary_1;
        private static readonly object object_0 = new object();
        private static readonly string string_0 = AppSettingCache.Get<string>("DefaultDataSourceName", "Default");
        private string string_1 = null;

        static CodeCache()
        {
            Dictionary<string, CodeCache> dictionary = new Dictionary<string, CodeCache>(10);
            dictionary.Add(string_0, new CodeCache(""));
            idictionary_1 = dictionary;
        }

        private CodeCache(string dbName = "")
        {
            if (string.IsNullOrEmpty(dbName))
            {
                dbName = string_0;
            }
            this.string_1 = dbName;
        }

        public static CodeCache GetInstance(string dbName)
        {
            if (!idictionary_1.ContainsKey(dbName))
            {
                lock (object_0)
                {
                    if (!idictionary_1.ContainsKey(dbName))
                    {
                        idictionary_1.Add(dbName, new CodeCache(dbName));
                    }
                }
            }
            return idictionary_1[dbName];
        }

        private void method_0(string type)
        {
            if (!this.idictionary_0.ContainsKey(type))
            {
                IDictionary<string, string> codesByType = icodeLoad_0.GetCodesByType(type, this.string_1);
                lock (object_0)
                {
                    if (!this.idictionary_0.ContainsKey(type))
                    {
                        this.idictionary_0.Add(type, codesByType as Dictionary<string, string>);
                    }
                }
            }
        }

        public static CodeCache Instance
        {
            get
            {
                return idictionary_1[string_0];
            }
        }

        public IDictionary<string, string> this[string type]
        {
            get
            {
                if (!this.idictionary_0.ContainsKey(type))
                {
                    this.method_0(type);
                }
                return this.idictionary_0[type];
            }
        }

        public string this[string type, string name]
        {
            get
            {
                if (!this.idictionary_0.ContainsKey(type))
                {
                    this.method_0(type);
                }
                if (!this.idictionary_0[type].ContainsKey(name))
                {
                    ExceptionManager.Instance.CreateException(new ArgumentOutOfRangeException(name, "字典缓存中查找不到该键"), "字典缓存中查找不到该键");
                    return null;
                }
                return this.idictionary_0[type][name];
            }
        }
    }
}

