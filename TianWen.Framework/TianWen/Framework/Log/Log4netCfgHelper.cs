namespace TianWen.Framework.Log
{
    using System;
    using System.IO;
    using System.Xml;
    using TianWen.Framework.Exceptions;

    public class Log4netCfgHelper
    {
        public const string LOG4NET_PATH = @"Config\log4net.config";
        public const string XML_NAME_SPACE = "urn:log4net";
        public const string XML_NAME_SPACE_PREFIX = "r";

        public static XmlNamespaceManager GetNameSpaceManager(XmlDocument xmlDoc)
        {
            XmlNamespaceManager manager = new XmlNamespaceManager(xmlDoc.NameTable);
            manager.AddNamespace("r", "urn:log4net");
            return manager;
        }

        public static string GetValue(XmlNode node)
        {
            if (node != null)
            {
                return ((node.Attributes["value"] != null) ? node.Attributes["value"].Value : node.InnerText);
            }
            return string.Empty;
        }

        public static XmlDocument LoadLog4netDocument(string appBasePath)
        {
            appBasePath = appBasePath.GetEndWithABackSlash();
            LoggerManager.Debug("Unknown", string.Format("开始读取日志配置文件:{0}.", appBasePath + @"Config\log4net.config"));
            XmlDocument document = new XmlDocument();
            try
            {
                document.Load(appBasePath + @"Config\log4net.config");
                LoggerManager.Debug("Unknown", string.Format("读取日志配置文件:{0} 完毕.", appBasePath + @"Config\log4net.config"));
            }
            catch (Exception exception)
            {
                if ((exception is FileNotFoundException) || (exception is DirectoryNotFoundException))
                {
                    LoggerManager.Error("Unknown", string.Format("读取日志配置文件失败:日志文件{0}不存在!", appBasePath + @"Config\log4net.config"));
                    throw new TianWenException("Unknown", string.Format("读取日志配置文件失败:日志文件{0}不存在!", appBasePath + @"Config\log4net.config"));
                }
                LoggerManager.Error("Unknown", string.Format("读取日志配置文件失败:{0}.", exception.Message));
                throw exception;
            }
            return document;
        }

        public static void SetValue(XmlNode node, string value)
        {
            if (node != null)
            {
                if (node.Attributes["value"] != null)
                {
                    node.Attributes["value"].Value = value;
                }
                else
                {
                    node.InnerText = value;
                }
            }
        }

        public static void ValidNode(string appBasePath, XmlNode node, string nodeName)
        {
            if (node == null)
            {
                string message = string.Format("日志文件:{0},不存在:{1} 配置节点.", appBasePath + @"Config\log4net.config", nodeName);
                throw new TianWenException("", message);
            }
        }
    }
}

