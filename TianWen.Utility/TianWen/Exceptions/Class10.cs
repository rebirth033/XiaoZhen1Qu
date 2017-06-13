namespace TianWen.Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Xml.Serialization;

    internal class Class10 : IConfigHelp
    {
        private readonly Dictionary<string, string> dictionary_0 = new Dictionary<string, string>();

        public Class10()
        {
            if (Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + @"\" + Settings.ExceptionConfigFilePath))
            {
                string[] files = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory + @"\" + Settings.ExceptionConfigFilePath);
                for (int i = 0; i < files.Length; i++)
                {
                    this.dictionary_0.Add(files[i].Substring(files[i].LastIndexOf(@"\", StringComparison.Ordinal) + 1), files[i]);
                }
            }
        }

        public ExceptionConfig Find(string code)
        {
            List<ExceptionConfig> list = new List<ExceptionConfig>();
            XmlSerializer serializer = new XmlSerializer(list.GetType());
            string path = "";
            try
            {
                path = this.dictionary_0[code.Substring(3, 5)];
            }
            catch (Exception)
            {
                return null;
            }
            using (FileStream stream = new FileStream(path, FileMode.Open))
            {
                list = (List<ExceptionConfig>) serializer.Deserialize(stream);
            }
            foreach (ExceptionConfig config in list)
            {
                if (config.Code == code)
                {
                    return config;
                }
            }
            return null;
        }
    }
}

