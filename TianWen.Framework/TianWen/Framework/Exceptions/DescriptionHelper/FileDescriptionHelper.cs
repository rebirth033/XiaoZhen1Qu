namespace TianWen.Framework.Exceptions.DescriptionHelper
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Xml.Serialization;
    using TianWen.Framework.Exceptions;

    internal class FileDescriptionHelper : IDescriptionHelper
    {
        private static Dictionary<string, string> _fileList = new Dictionary<string, string>();

        public FileDescriptionHelper()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"\ExceptionDescription";
            if (Directory.Exists(path))
            {
                string[] files = Directory.GetFiles(path);
                for (int i = 0; i < files.Length; i++)
                {
                    string key = files[i].Substring(files[i].LastIndexOf(".") - 5, 5);
                    if (!_fileList.ContainsKey(key))
                    {
                        _fileList.Add(files[i].Substring(files[i].LastIndexOf(".") - 5, 5), files[i]);
                    }
                }
            }
        }

        public ExceptionDescription FindDescription(string Code)
        {
            List<ExceptionDescription> list = new List<ExceptionDescription>();
            XmlSerializer serializer = new XmlSerializer(list.GetType());
            string path = "";
            try
            {
                path = _fileList[Code.Substring(3, 5)];
            }
            catch (Exception)
            {
                return null;
            }
            using (FileStream stream = new FileStream(path, FileMode.Open))
            {
                list = (List<ExceptionDescription>) serializer.Deserialize(stream);
            }
            foreach (ExceptionDescription description in list)
            {
                if (description.Code == Code)
                {
                    return description;
                }
            }
            return null;
        }
    }
}

