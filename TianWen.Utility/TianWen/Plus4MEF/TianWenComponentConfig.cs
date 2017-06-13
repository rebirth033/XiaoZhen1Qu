namespace TianWen.Plus4MEF
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Xml.Serialization;
    using TianWen.Exceptions;

    public class TianWenComponentConfig
    {
        private List<TianWenComponentAlias> list_0 = new List<TianWenComponentAlias>(10);
        private List<TianWenComponentMap> list_1 = new List<TianWenComponentMap>(10);

        public TianWenComponentConfig Union(TianWenComponentConfig config)
        {
            this.Alias = this.Alias.Union<TianWenComponentAlias>(config.Alias).ToList<TianWenComponentAlias>();
            this.Maps = this.Maps.Union<TianWenComponentMap>(config.Maps).ToList<TianWenComponentMap>();
            return this;
        }

        [XmlArray("InterfaceAlias"), XmlArrayItem("Alias")]
        public List<TianWenComponentAlias> Alias
        {
            get
            {
                return this.list_0;
            }
            set
            {
                this.list_0 = value;
            }
        }

        public TianWenComponentMap this[string aliasName]
        {
            get
            {
                TianWenComponentMap map;
                System.Func<TianWenComponentMap, bool> func = null;
                Class3 class2 = new Class3 {
                    string_0 = aliasName
                };
                try
                {
                    if (func == null)
                    {
                        func = new System.Func<TianWenComponentMap, bool>(class2.method_0);
                    }
                    map = Enumerable.Single<TianWenComponentMap>(this.Maps, func);
                }
                catch (InvalidOperationException exception)
                {
                    throw ExceptionManager.Instance.CreateException("TianWen0100000002", exception, new object[] { class2.string_0 });
                }
                return map;
            }
        }

        [XmlArrayItem("Map")]
        public List<TianWenComponentMap> Maps
        {
            get
            {
                return this.list_1;
            }
            set
            {
                this.list_1 = value;
            }
        }

        [CompilerGenerated]
        private sealed class Class3
        {
            public string string_0;

            public bool method_0(TianWenComponentMap TianWenComponentMap_0)
            {
                return (TianWenComponentMap_0.Name == this.string_0);
            }
        }
    }
}

