using Spring.Context;
using Spring.Context.Support;

namespace TianWen.Framework.Common
{
    using System;
    using System.Collections;
    using System.IO;
    using TianWen.Framework.Log;

    public class SpringHelper
    {
        public static bool ContainsObject<T>(string objectId)
        {
            return ContextRegistry.GetContext().ContainsObject(objectId);
        }

        public static T GetSpringObject<T>(string objectId)
        {
            return (T) ContextRegistry.GetContext().GetObject(objectId);
        }

        public static T GetSpringObject<T>(string objectId, object[] arguments)
        {
            return (T) ContextRegistry.GetContext().GetObject(objectId, arguments);
        }

        public static IApplicationContext InitSpringContext()
        {
            IApplicationContext context = null;
            string str2;
            IApplicationContext context3;
            if (ContextManager.TianWenContext == null)
            {
                TianWenContext context2 = new TianWenContext
                {
                    EventNo = "Init" + DateTime.Now.Ticks
                };
                ContextManager.TianWenContext = context2;
            }
            ArrayList list = new ArrayList();
            string path = AppDomain.CurrentDomain.BaseDirectory + @"\Config\TopSpring.xml";
            if (!File.Exists(path))
            {
                str2 = "系统缺少配置文件：" + path + "，若存在需要优先加载的Spring配置信息，请在该文件中进行配置。";
                //LoggerManager.Warn("SystemConfig", str2);
            }
            else
            {
                list.Add(path);
            }
            string str3 = AppDomain.CurrentDomain.BaseDirectory + @"\Config\SpringConfig\";
            if (!Directory.Exists(str3))
            {
                str2 = "系统缺少Spring配置文件夹：" + str3 + "，若系统中存在该文件夹，系统将加载该文件夹下所有以 .xml 为扩展名的文件，但不支持加载其子目录。";
                //LoggerManager.Warn("SystemConfig", str2);
            }
            else
            {
                foreach (string str4 in Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory + @"\Config\SpringConfig\", "*.xml", SearchOption.AllDirectories))
                {
                    list.Add(str4);
                }
            }
            string[] configurationLocations = (string[])list.ToArray(typeof(string));
            try
            {
                context = new XmlApplicationContext(configurationLocations);
                if (!ContextRegistry.IsContextRegistered(context.Name))
                {
                    ContextRegistry.RegisterContext(context);
                }
                //LoggerManager.Info("SystemConfig", "SpringContext初始化结束，共加载了如下组件：" + StringHelper.ArrayToString(context.GetObjectDefinitionNames()));
                context3 = context;
            }
            catch (Exception exception)
            {
                string message = "启动过程加载Spring配置文件出现异常。请检查配置文件的正确性。";
                throw new Exception(message, exception);
            }
            return context3;
        }
    }
}

