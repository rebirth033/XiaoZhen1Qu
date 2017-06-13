namespace TianWen.Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Xml.Serialization;
    using TianWen.Logger;

    public class AssemblyConfigHelp : IConfigHelp
    {
        private readonly Assembly assembly_0;
        private readonly Dictionary<string, IList<ExceptionConfig>> dictionary_0 = new Dictionary<string, IList<ExceptionConfig>>();
        private readonly object object_0 = new object();

        public AssemblyConfigHelp()
        {
            this.assembly_0 = base.GetType().Assembly;
        }

        public ExceptionConfig Find(string code)
        {
            Class9 class2 = new Class9 {
                string_0 = code
            };
            if (!this.dictionary_0.ContainsKey(class2.string_0))
            {
                this.method_0(class2.string_0);
            }
            if (!this.dictionary_0.ContainsKey(class2.string_0))
            {
                LoggerManager.Error(string.Format("找不到错误代码：{0}", class2.string_0));
                return null;
            }
            IList<ExceptionConfig> list = this.dictionary_0[class2.string_0];
            return Enumerable.FirstOrDefault<ExceptionConfig>(list, new System.Func<ExceptionConfig, bool>(class2.method_0));
        }

        private void method_0(string Code)
        {
            using (Stream stream = this.assembly_0.GetManifestResourceStream("TianWen.Utility.Exceptions.ExceptionConfig." + Code.Substring(3, 5) + ".config"))
            {
                List<ExceptionConfig> list = new List<ExceptionConfig>();
                if (stream != null)
                {
                    XmlSerializer serializer = new XmlSerializer(list.GetType());
                    list = (List<ExceptionConfig>) serializer.Deserialize(stream);
                    if (!this.dictionary_0.ContainsKey(Code))
                    {
                        lock (this.object_0)
                        {
                            if (!this.dictionary_0.ContainsKey(Code))
                            {
                                this.dictionary_0.Add(Code, list);
                            }
                        }
                    }
                    stream.Close();
                }
            }
        }

        [CompilerGenerated]
        private sealed class Class9
        {
            public string string_0;

            public bool method_0(ExceptionConfig exceptionConfig_0)
            {
                return (exceptionConfig_0.Code == this.string_0);
            }
        }
    }
}

