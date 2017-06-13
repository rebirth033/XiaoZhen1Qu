using System;
using System.ComponentModel.Composition;
using System.Runtime.CompilerServices;

namespace TianWen.Plus4MEF
{


    [MetadataAttribute, AttributeUsage(AttributeTargets.Class, AllowMultiple=false)]
    public class TianWenComponentAttribute : ExportAttribute
    {
        [CompilerGenerated]
        private string string_0;

        public TianWenComponentAttribute() : base(typeof(ITianWenComponent))
        {
        }

        public TianWenComponentAttribute(string componentName) : base(typeof(ITianWenComponent))
        {
            this.ComponentName = componentName;
        }

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
    }
}

