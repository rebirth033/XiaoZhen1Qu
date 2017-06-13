namespace TianWen.Plus4MEF
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Xml.Serialization;

    public class TianWenComponentMap
    {
        [CompilerGenerated]
        private static System.Func<TianWenComponentVersion, bool> func_0;
        private List<TianWenComponentVersion> list_0 = new List<TianWenComponentVersion>(3);
        [CompilerGenerated]
        private string string_0;

        [CompilerGenerated]
        private static bool smethod_0(TianWenComponentVersion TianWenComponentVersion_0)
        {
            return TianWenComponentVersion_0.Default;
        }

        public TianWenComponentVersion Default
        {
            get
            {
                if (this.list_0.Count == 0)
                {
                    return null;
                }
                if (this.list_0.Count == 1)
                {
                    return this.list_0.First<TianWenComponentVersion>();
                }
                if (func_0 == null)
                {
                    func_0 = new System.Func<TianWenComponentVersion, bool>(TianWenComponentMap.smethod_0);
                }
                return Enumerable.FirstOrDefault<TianWenComponentVersion>(this.Versions, func_0);
            }
        }

        [XmlAttribute]
        public string Name
        {
            [CompilerGenerated]
            get
            {
                return this.string_0;
            }
            [CompilerGenerated]
            set
            {
                this.string_0 = value;
            }
        }

        [XmlArrayItem("Component")]
        public List<TianWenComponentVersion> Versions
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
    }
}

