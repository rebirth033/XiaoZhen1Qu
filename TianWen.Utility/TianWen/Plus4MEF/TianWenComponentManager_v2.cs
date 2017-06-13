namespace TianWen.Plus4MEF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.ComponentModel.Composition.Hosting;
    using System.ComponentModel.Composition.Primitives;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using TianWen.Exceptions;
    using TianWen.Interface;
    using TianWen.Logger;

    public class TianWenComponentManager_v2 : Interface0
    {
        private static AggregateCatalog aggregateCatalog_0 = new AggregateCatalog();
        private CompositionContainer compositionContainer_0;
        private readonly IList<string> ilist_0 = new List<string>(10);

        public T GetComponent<T>(string componentName)
        {
            System.Func<Lazy<ITianWenComponent, ITianWenComponentMetadata>, bool> func = null;
            Class7<T> class2 = new Class7<T> {
                string_0 = componentName
            };
            try
            {
                if (func == null)
                {
                    func = new System.Func<Lazy<ITianWenComponent, ITianWenComponentMetadata>, bool>(class2.method_0);
                }
                IEnumerable<Lazy<ITianWenComponent, ITianWenComponentMetadata>> source = Enumerable.Where<Lazy<ITianWenComponent, ITianWenComponentMetadata>>(this.compositionContainer_0.GetExports<ITianWenComponent, ITianWenComponentMetadata>(), func);
                if (!source.Any<Lazy<ITianWenComponent, ITianWenComponentMetadata>>())
                {
                    throw ExceptionManager.Instance.CreateException("TianWen0100000005", new object[] { class2.string_0 });
                }
                Lazy<ITianWenComponent, ITianWenComponentMetadata> lazy = source.Last<Lazy<ITianWenComponent, ITianWenComponentMetadata>>();
                if (lazy != null)
                {
                    ITianWenComponent component = lazy.Value;
                    if (component is ITianWenComponentEvent)
                    {
                        (component as ITianWenComponentEvent).Load();
                    }
                    return (T) component;
                }
            }
            catch (ReflectionTypeLoadException exception)
            {
                throw new TianWenException("加载类型错误，明细如下：\r\n", exception.LoaderExceptions[0]);
            }
            throw ExceptionManager.Instance.CreateException("TianWen0100000005", new object[] { class2.string_0 });
        }

        public void LoadPlusin(Assembly assembly_0)
        {
            Class6 class2 = new Class6 {
                assembly_0 = assembly_0,
                TianWenComponentManager_v2_0 = this
            };
            if (!this.ilist_0.Contains(class2.assembly_0.ToString()))
            {
                this.method_0(new System.Action(class2.method_0));
            }
        }

        public void LoadPlusin(string path = ".", string searchPattern = "*.dll")
        {
            Class5 class2 = new Class5 {
                string_1 = path,
                string_2 = searchPattern,
                TianWenComponentManager_v2_0 = this
            };
            if (class2.string_1 == ".")
            {
                class2.string_1 = EnvironmentVar.ApplicationBin;
            }
            class2.string_0 = Path.Combine(class2.string_1, class2.string_2);
            if (!this.ilist_0.Contains(class2.string_0))
            {
                LoggerManager.Debug(string.Format("准备组合目录【{0}】,搜索条件为【{1}】", class2.string_1, class2.string_2));
                this.method_0(new System.Action(class2.method_0));
            }
        }

        private void method_0(System.Action action_0)
        {
            action_0();
            this.compositionContainer_0 = new CompositionContainer(aggregateCatalog_0, true, new ExportProvider[0]);
            this.compositionContainer_0.ComposeParts(new object[] { this });
        }

        public void RemoveComponent<T>(string componentName)
        {
            Lazy<T> export = this.compositionContainer_0.GetExport<T>(componentName);
            this.compositionContainer_0.ReleaseExport<T>(export);
        }

        [CompilerGenerated]
        private sealed class Class5
        {
            public string string_0;
            public string string_1;
            public string string_2;
            public TianWenComponentManager_v2 TianWenComponentManager_v2_0;

            public void method_0()
            {
                try
                {
                    DirectoryCatalog item = new DirectoryCatalog(this.string_1, this.string_2);
                    if (!item.Parts.Any<ComposablePartDefinition>())
                    {
                        string[] files = Directory.GetFiles(this.string_1, this.string_2);
                        LoggerManager.Info(string.Format("【{0}】该目录下未发现搜索条件为【{1}】的任何组件，文件目录下发现满足条件的文件【{2}】个，退出组合。", this.string_1, this.string_2, files.Length));
                        return;
                    }
                    foreach (ComposablePartDefinition definition in item.Parts)
                    {
                        LoggerManager.Debug("发现扩展插件：" + definition);
                    }
                    TianWenComponentManager_v2.aggregateCatalog_0.Catalogs.Add(item);
                }
                catch (ReflectionTypeLoadException exception)
                {
                    throw new TianWenException("加载" + exception.Types[0].FullName + "类型错误，明细如下：\r\n", exception.LoaderExceptions[0]);
                }
                this.TianWenComponentManager_v2_0.ilist_0.Add(this.string_0);
            }
        }

        [CompilerGenerated]
        private sealed class Class6
        {
            public Assembly assembly_0;
            public TianWenComponentManager_v2 TianWenComponentManager_v2_0;

            public void method_0()
            {
                TianWenComponentManager_v2.aggregateCatalog_0.Catalogs.Add(new AssemblyCatalog(this.assembly_0));
                this.TianWenComponentManager_v2_0.ilist_0.Add(this.assembly_0.ToString());
            }
        }

        [CompilerGenerated]
        private sealed class Class7<T>
        {
            public string string_0;

            public bool method_0(Lazy<ITianWenComponent, ITianWenComponentMetadata> lazy_0)
            {
                return (lazy_0.Metadata.ComponentName == this.string_0);
            }
        }
    }
}

