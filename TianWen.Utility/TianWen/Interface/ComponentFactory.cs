namespace TianWen.Interface
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using TianWen.Logger;
    using TianWen.Plus4MEF;
    using TianWen.Utility;

    public static class ComponentFactory
    {
        private static readonly Class0 class0_0;

        internal static  event Delegate0 ComponentFactoryInitEvent;

        static ComponentFactory()
        {
            ComponentFactoryInitEvent += new Delegate0(LogFactory.smethod_0);
            Class8 class2 = new Class8 {
                bool_0 = true
            };
            LoggerManager.Debug("插件配置参数:" + PlusinDir);
            string plusinDir = PlusinDir;
            if (Path.HasExtension(plusinDir))
            {
                LoggerManager.Debug("按配置文件加载插件:" + PlusinDir);
                List<PluginAssemblies> list = Serializer.Deserialize4Xml<List<PluginAssemblies>>(plusinDir);
                class0_0 = new Class0();
                foreach (PluginAssemblies assemblies in list)
                {
                    class0_0.method_0(assemblies.Path, assemblies.SearchPattern ?? "*.*", assemblies.ConfigFile ?? "res:TianWen.Utility.TianWenComponent.config, TianWen.Utility");
                }
            }
            else
            {
                LoggerManager.Debug("加载插件目录:" + PlusinDir);
                class0_0 = new Class0(PlusinDir, "*.*", true);
            }
            Class8 class3 = new Class8 {
                bool_0 = class0_0 == null
            };
        }

        public static T Get<T>() where T: ITianWenComponent
        {
            return class0_0.method_1<T>();
        }

        public static T Get<T>(string componentName) where T: ITianWenComponent
        {
            return class0_0.method_2<T>(componentName);
        }

        private static string PlusinDir
        {
            get
            {
                return AppSettingCache.Get<string>("PlusinDir", "");
            }
        }
    }
}

