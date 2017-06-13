namespace TianWen.Nhibernate.DataSource
{
    using System;
    using System.Runtime.CompilerServices;

    [Serializable]
    public class DataSource
    {
        public string AssemblyName { get; set; }

        public string ExportPath { get; set; }

        public string IsExportTo { get; set; }

        public string SourceFile { get; set; }

        public string SourceName { get; set; }
    }
}

