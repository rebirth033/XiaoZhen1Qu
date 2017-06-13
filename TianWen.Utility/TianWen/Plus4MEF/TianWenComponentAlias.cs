namespace TianWen.Plus4MEF
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Xml.Serialization;

    public class TianWenComponentAlias
    {
        [CompilerGenerated]
        private string string_0;
        [CompilerGenerated]
        private string string_1;

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

        public Type TypeHandler
        {
            get
            {
                return Type.GetType(this.TypeName, false);
            }
        }

        [XmlAttribute("Type")]
        public string TypeName
        {
            [CompilerGenerated]
            get
            {
                return this.string_1;
            }
            [CompilerGenerated]
            set
            {
                this.string_1 = value;
            }
        }
    }
}

