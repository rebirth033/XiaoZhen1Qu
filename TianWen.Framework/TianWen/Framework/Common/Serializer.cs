namespace TianWen.Framework.Common
{
    using System;
    using System.IO;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static object LoadObjectFromFile(Type type, string fileName)
        {
            object obj2;
            TextReader textReader = null;
            try
            {
                textReader = new StreamReader(fileName);
                obj2 = new XmlSerializer(type).Deserialize(textReader);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            finally
            {
                if (textReader != null)
                {
                    textReader.Close();
                }
            }
            return obj2;
        }

        public static void SaveObjectToFile(object obj, string fileName)
        {
            SaveObjectToFile(obj, fileName, false);
        }

        public static void SaveObjectToFile(object obj, string fileName, bool append)
        {
            if (obj != null)
            {
                TextWriter textWriter = null;
                try
                {
                    textWriter = new StreamWriter(fileName, append);
                    new XmlSerializer(obj.GetType()).Serialize(textWriter, obj);
                }
                catch (Exception exception)
                {
                    throw new Exception(exception.Message);
                }
                finally
                {
                    if (textWriter != null)
                    {
                        textWriter.Close();
                    }
                }
            }
        }

        public static object StringDeserialize(string text, Type type)
        {
            return StringDeserialize(text, type, string.Empty);
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

        public static string StringSerialize(object obj, Type type)
        {
            string str;
            StringWriter textWriter = new StringWriter();
            try
            {
                XmlSerialize(textWriter, obj, type);
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

        public static void XmlSerialize(TextWriter textWriter, object obj, Type type)
        {
            new XmlSerializer(type).Serialize(textWriter, obj);
        }
    }
}

