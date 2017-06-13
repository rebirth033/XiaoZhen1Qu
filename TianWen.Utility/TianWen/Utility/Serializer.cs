namespace TianWen.Utility
{
    using System;
    using System.IO;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Text;
    using System.Xml.Serialization;
    using TianWen.Interface;

    public class Serializer
    {
        public static object BinaryDeserialize(Stream serializationStream)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            return formatter.Deserialize(serializationStream);
        }

        public static void BinarySerialize(Stream serializationStream, object object_0)
        {
            new BinaryFormatter().Serialize(serializationStream, object_0);
        }

        public static bool CheckResource(string path, Assembly assemblyName)
        {
            return (assemblyName.GetManifestResourceInfo(path) != null);
        }

        public static T Deserialize<T>(string string_0) where T: class, new()
        {
            if (string.IsNullOrEmpty(string_0))
            {
                return default(T);
            }
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            T local3 = default(T);
            using (StringReader reader = new StringReader(string_0))
            {
                return (serializer.Deserialize(reader) as T);
            }
        }

        public static T Deserialize4Resource<T>(string path) where T: class, new()
        {
            if (path.StartsWith("res:"))
            {
                path = path.Substring(4);
            }
            if (path.IndexOf(",") > 0)
            {
                string[] strArray = path.Split(new char[] { ',' });
                return Deserialize4Resource<T>(strArray[0], strArray[1]);
            }
            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                if (CheckResource(path, assembly))
                {
                    return Deserialize4Resource<T>(path, assembly);
                }
            }
            return default(T);
        }

        public static T Deserialize4Resource<T>(string path, Assembly assembly) where T: class, new()
        {
            if (CheckResource(path, assembly))
            {
                using (Stream stream = assembly.GetManifestResourceStream(path))
                {
                    if (stream != null)
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(T));
                        T local3 = default(T);
                        local3 = serializer.Deserialize(stream) as T;
                        stream.Close();
                        return local3;
                    }
                }
            }
            return default(T);
        }

        public static T Deserialize4Resource<T>(string path, string assemblyName) where T: class, new()
        {
            Assembly assembly = Assembly.Load(assemblyName.Trim());
            return Deserialize4Resource<T>(path, assembly);
        }

        public static T Deserialize4Xml<T>(string filePath) where T: class, new()
        {
            if (filePath.StartsWith("res:"))
            {
                return Deserialize4Resource<T>(filePath);
            }
            filePath = smethod_0(filePath);
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            T local2 = default(T);
            using (StreamReader reader = new StreamReader(filePath))
            {
                local2 = serializer.Deserialize(reader) as T;
                reader.Close();
            }
            return local2;
        }

        public static T LoadObjectFromFile<T>(string fileName) where T: class, new()
        {
            return Deserialize4Xml<T>(fileName);
        }

        public static void SaveObjectToFile(object object_0, string fileName)
        {
            SaveObjectToFile(object_0, fileName, false);
        }

        public static void SaveObjectToFile(object object_0, string fileName, bool append)
        {
            Serizlizer2Xml(fileName, object_0, append);
        }

        public static string Serizlizer2Xml(object value)
        {
            XmlSerializer serializer = new XmlSerializer(value.GetType());
            using (MemoryStream stream = new MemoryStream(0x5000))
            {
                serializer.Serialize((Stream) stream, value);
                byte[] bytes = stream.ToArray();
                stream.Close();
                return Encoding.UTF8.GetString(bytes);
            }
        }

        public static void Serizlizer2Xml(string filePath, object value, bool append = false)
        {
            XmlSerializer serializer = new XmlSerializer(value.GetType());
            string directoryName = Path.GetDirectoryName(filePath);
            if (string.IsNullOrEmpty(directoryName))
            {
                throw new Exception("无效的路径" + directoryName);
            }
            if (!Directory.Exists(directoryName))
            {
                Directory.CreateDirectory(directoryName);
            }
            using (StreamWriter writer = new StreamWriter(filePath, append))
            {
                serializer.Serialize((TextWriter) writer, value);
                writer.Flush();
                writer.Close();
            }
        }

        private static string smethod_0(string path)
        {
            string str = path;
            if (File.Exists(str))
            {
                return str;
            }
            if (File.Exists(Path.Combine(EnvironmentVar.ApplicationPath, str)))
            {
                return Path.Combine(EnvironmentVar.ApplicationPath, str);
            }
            if (!File.Exists(Path.Combine(EnvironmentVar.ApplicationBin, str)))
            {
                throw new FileNotFoundException(string.Format("找不到指定文件[{0}]", str));
            }
            return Path.Combine(EnvironmentVar.ApplicationBin, str);
        }

        public static object StringDeserialize(string text, Type type)
        {
            return StringDeserialize(text, type, string.Empty);
        }

        public static object StringDeserialize(string text, Type type, Type[] extraTypes)
        {
            object obj2;
            StringReader textReader = new StringReader(text);
            try
            {
                obj2 = new XmlSerializer(type, extraTypes).Deserialize(textReader);
            }
            finally
            {
                textReader.Close();
            }
            return obj2;
        }

        public static object StringDeserialize(string text, Type type, string rootElementName)
        {
            object obj2;
            if ((text == string.Empty) || (text == null))
            {
                return null;
            }
            StringReader textReader = new StringReader(text);
            try
            {
                obj2 = XmlDeserialize(textReader, type, rootElementName);
            }
            finally
            {
                textReader.Close();
            }
            return obj2;
        }

        public static string StringSerialize(object object_0, Type type)
        {
            string str;
            StringWriter textWriter = new StringWriter();
            try
            {
                XmlSerialize(textWriter, object_0, type);
                str = textWriter.ToString();
            }
            finally
            {
                textWriter.Close();
            }
            return str;
        }

        public static object XmlDeserialize(TextReader textReader, Type type)
        {
            return XmlDeserialize(textReader, type, null);
        }

        public static object XmlDeserialize(TextReader textReader, Type type, string rootElementName)
        {
            XmlSerializer serializer;
            if ((rootElementName == null) || (rootElementName == string.Empty))
            {
                serializer = new XmlSerializer(type);
            }
            else
            {
                XmlRootAttribute root = new XmlRootAttribute(rootElementName);
                serializer = new XmlSerializer(type, root);
            }
            return serializer.Deserialize(textReader);
        }

        public static void XmlSerialize(TextWriter textWriter, object object_0, Type type)
        {
            new XmlSerializer(type).Serialize(textWriter, object_0);
        }
    }
}

