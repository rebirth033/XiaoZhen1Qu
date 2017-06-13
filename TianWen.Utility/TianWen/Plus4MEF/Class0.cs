namespace TianWen.Plus4MEF
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using TianWen.Exceptions;
    using TianWen.Interface;
    using TianWen.Logger;
    using TianWen.Utility;

    internal class Class0
    {
        private static bool bool_0;
        private static IDictionary<Type, string> idictionary_0;
        private static readonly IList<string> ilist_0 = new List<string>(5);
        private static readonly IList<string> ilist_1 = new List<string>(5);
        private static readonly object object_0 = new object();
        private const string string_0 = "TianWenComponent.Config";
        internal const string string_1 = "res:TianWen.Utility.TianWenComponent.config, TianWen.Utility";
        private static TianWenComponentConfig TianWenComponentConfig_0;
        private static readonly TianWenComponentManager_v2 TianWenComponentManager_v2_0 = new TianWenComponentManager_v2();

        public Class0()
        {
        }

        public Class0(string string_2, string string_3 = "*.*", bool bool_1 = true) : this(string_2, "res:TianWen.Utility.TianWenComponent.config, TianWen.Utility", string_3, bool_1)
        {
        }

        private Class0(string string_2, string string_3, string string_4 = "*.*", bool bool_1 = true)
        {
            if (bool_1)
            {
                LoggerManager.Debug(string.Format("开始组合目录【{0}】,搜索条件为【{1}】", EnvironmentVar.ApplicationBin, "TianWen.*.dll"));
                this.method_0(EnvironmentVar.ApplicationBin, "TianWen.*.dll", "res:TianWen.Utility.TianWenComponent.config, TianWen.Utility");
            }
            if (!string.IsNullOrEmpty(string_2))
            {
                LoggerManager.Debug(string.Format("开始组合插件目录【{0}】,搜索条件为【{1}】", string_2, string_4));
                this.method_0(string_2, string_4, string_3);
            }
        }

        public void method_0(string string_2, string string_3 = "*.*", string string_4 = "TianWenComponent.Config")
        {
            if (string.IsNullOrEmpty(string_2))
            {
                string_2 = EnvironmentVar.ApplicationBin;
            }
            if (string_2 == ".")
            {
                string_2 = EnvironmentVar.ApplicationBin;
            }
            if (!string_2.StartsWith("@"))
            {
                string_2 = Path.Combine(EnvironmentVar.ApplicationPath, string_2);
            }
            string path = Path.Combine(string_2, string_3);
            if (!smethod_0(path))
            {
                lock (object_0)
                {
                    if (!smethod_0(path))
                    {
                        if (!ilist_0.Contains(string_4))
                        {
                            bool_0 = false;
                        }
                        if (!(bool_0 || (!string_4.StartsWith("res:") && !File.Exists(string_4))))
                        {
                            TianWenComponentConfig config = Serializer.Deserialize4Xml<TianWenComponentConfig>(string_4);
                            TianWenComponentConfig_0 = (TianWenComponentConfig_0 == null) ? config : TianWenComponentConfig_0.Union(config);
                            ilist_0.Add(string_4);
                            smethod_1();
                        }
                        TianWenComponentManager_v2_0.LoadPlusin(string_2, string_3);
                        ilist_1.Add(path);
                        bool_0 = true;
                    }
                }
            }
        }

        public T method_1<T>() where T: ITianWenComponent
        {
            TianWenComponentMap map = smethod_2<T>();
            if (map == null)
            {
                Type type = typeof(T);
                string componentName = type.Name.Substring(1);
                return this.method_2<T>(componentName);
            }
            return TianWenComponentManager_v2_0.GetComponent<T>(map.Default.ComponentName);
        }

        public T method_2<T>(string componentName) where T: ITianWenComponent
        {
            TianWenComponentMap map = smethod_2<T>();
            if (map == null)
            {
                return TianWenComponentManager_v2_0.GetComponent<T>(componentName);
            }
            TianWenComponentVersion version = smethod_3(map, componentName);
            return TianWenComponentManager_v2_0.GetComponent<T>(version.ComponentName);
        }

        private static bool smethod_0(string path)
        {
            return ilist_1.Contains(path);
        }

        private static void smethod_1()
        {
            if ((TianWenComponentConfig_0 != null) && (TianWenComponentConfig_0.Alias != null))
            {
                if ((idictionary_0 != null) && (idictionary_0.Count > 0))
                {
                    idictionary_0.Clear();
                }
                idictionary_0 = new Dictionary<Type, string>(TianWenComponentConfig_0.Alias.Count);
                foreach (TianWenComponentAlias alias in TianWenComponentConfig_0.Alias)
                {
                    if (alias.TypeHandler != null)
                    {
                        idictionary_0.Add(alias.TypeHandler, alias.Name);
                    }
                }
            }
        }

        private static TianWenComponentMap smethod_2<T>() where T: ITianWenComponent
        {
            Type key = typeof(T);
            if (idictionary_0.ContainsKey(key))
            {
                string alias = idictionary_0[key];
                return smethod_4(alias);
            }
            return null;
        }

        private static TianWenComponentVersion smethod_3(TianWenComponentMap TianWenComponentMap_0, string string_2)
        {
            Class1 class2 = new Class1 {
                string_0 = string_2
            };
            if (string.IsNullOrEmpty(class2.string_0))
            {
                throw ExceptionManager.Instance.CreateException("TianWen0100000001");
            }
            return Enumerable.FirstOrDefault<TianWenComponentVersion>(TianWenComponentMap_0.Versions, new System.Func<TianWenComponentVersion, bool>(class2.method_0));
        }

        private static TianWenComponentMap smethod_4(string alias)
        {
            TianWenComponentMap map2;
            System.Func<TianWenComponentMap, bool> func = null;
            Class2 class2 = new Class2 {
                string_0 = alias
            };
            try
            {
                if (func == null)
                {
                    func = new System.Func<TianWenComponentMap, bool>(class2.method_0);
                }
                TianWenComponentMap map = Enumerable.SingleOrDefault<TianWenComponentMap>(TianWenComponentConfig_0.Maps, func);
                if (map == null)
                {
                    throw ExceptionManager.Instance.CreateException("TianWen0100000002", new object[] { class2.string_0 });
                }
                map2 = map;
            }
            catch (InvalidOperationException exception)
            {
                throw ExceptionManager.Instance.CreateException("TianWen0100000003", exception, new object[] { class2.string_0 });
            }
            return map2;
        }

        [CompilerGenerated]
        private sealed class Class1
        {
            public string string_0;

            public bool method_0(TianWenComponentVersion TianWenComponentVersion_0)
            {
                return (string.IsNullOrEmpty(this.string_0) || (TianWenComponentVersion_0.ComponentName == this.string_0));
            }
        }

        [CompilerGenerated]
        private sealed class Class2
        {
            public string string_0;

            public bool method_0(TianWenComponentMap TianWenComponentMap_0)
            {
                return (TianWenComponentMap_0.Name == this.string_0);
            }
        }
    }
}

