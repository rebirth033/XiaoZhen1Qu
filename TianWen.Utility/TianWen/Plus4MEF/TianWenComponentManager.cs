namespace TianWen.Plus4MEF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.ComponentModel.Composition.Hosting;
    using System.ComponentModel.Composition.Primitives;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using TianWen.Exceptions;

    public class TianWenComponentManager : Interface0
    {
        private static readonly AggregateCatalog aggregateCatalog_0 = new AggregateCatalog();
        private readonly CompositionContainer compositionContainer_0;
        [ImportMany(typeof(ITianWenComponent), AllowRecomposition=true, RequiredCreationPolicy=CreationPolicy.NonShared)]
        private IEnumerable<Lazy<ITianWenComponent, ITianWenComponentMetadata>> ienumerable_0;

        internal TianWenComponentManager(string virtualPath = "")
        {
            if (!string.IsNullOrEmpty(virtualPath))
            {
                this.LoadPlusin(virtualPath, "*.*");
            }
            aggregateCatalog_0.Changed += new EventHandler<ComposablePartCatalogChangeEventArgs>(this.method_0);
            this.compositionContainer_0 = new CompositionContainer(aggregateCatalog_0, new ExportProvider[0]);
        }

        public void LoadPlusin(Assembly assembly_0)
        {
            throw new NotSupportedException();
        }

        public void LoadPlusin(string virtualPath, string searchPattern = "*.*")
        {
            try
            {
                DirectoryCatalog item = new DirectoryCatalog(virtualPath, searchPattern);
                aggregateCatalog_0.Catalogs.Add(item);
            }
            catch (ReflectionTypeLoadException exception)
            {
                throw ExceptionManager.Instance.CreateException("TianWen0100000004", exception, new object[] { exception.LoaderExceptions[0] });
            }
        }

        private void method_0(object sender, ComposablePartCatalogChangeEventArgs e)
        {
            CompositionBatch batch = new CompositionBatch();
            foreach (ComposablePartDefinition definition in e.AddedDefinitions)
            {
                batch.AddPart(definition.CreatePart());
            }
            try
            {
                this.compositionContainer_0.ComposeParts(new object[] { batch, this });
            }
            catch (ReflectionTypeLoadException exception)
            {
                throw ExceptionManager.Instance.CreateException("TianWen0100000004", exception, new object[] { exception.LoaderExceptions[0] });
            }
        }

        public void RemoveComponent<T>(string componentName = "")
        {
            IEnumerable<Lazy<T>> exports;
            if (string.IsNullOrEmpty(componentName))
            {
                exports = this.compositionContainer_0.GetExports<T>();
            }
            else
            {
                exports = this.compositionContainer_0.GetExports<T>(componentName);
            }
            this.compositionContainer_0.ReleaseExports<T>(exports);
            this.compositionContainer_0.ComposeParts(new object[] { this.ienumerable_0 });
        }

        [CompilerGenerated]
        private sealed class Class4<T>
        {
            public string string_0;

            public bool method_0(Lazy<ITianWenComponent, ITianWenComponentMetadata> lazy_0)
            {
                return (lazy_0.Metadata.ComponentName == this.string_0);
            }
        }

        public T GetComponent<T>(string componentName)
        {
            throw new NotImplementedException();
        }
    }
}

