namespace TianWen.Interface
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Xml.Serialization;

    public class PluginAssemblies
    {
        [CompilerGenerated]
        private string string_0;
        [CompilerGenerated]
        private string string_1;
        [CompilerGenerated]
        private string string_2;

        [XmlAttribute]
        public string ConfigFile
        {
            [CompilerGenerated]
            get
            {
                return this.string_2;
            }
            [CompilerGenerated]
            set
            {
                this.string_2 = value;
            }
        }

        [XmlAttribute]
        public string Path
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
        public string SearchPattern
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

