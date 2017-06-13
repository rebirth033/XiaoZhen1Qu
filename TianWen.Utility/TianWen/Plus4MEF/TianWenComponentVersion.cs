namespace TianWen.Plus4MEF
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Xml.Serialization;

    public class TianWenComponentVersion
    {
        [CompilerGenerated]
        private bool bool_0;
        [CompilerGenerated]
        private string string_0;

        public override string ToString()
        {
            return string.Format("ComponentName:{0}, Default:{1}", this.ComponentName, this.Default);
        }

        [XmlAttribute(AttributeName="Name")]
        public string ComponentName
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

        [XmlAttribute]
        public bool Default
        {
            [CompilerGenerated]
            get
            {
                return this.bool_0;
            }
            [CompilerGenerated]
            set
            {
                this.bool_0 = value;
            }
        }
    }
}

