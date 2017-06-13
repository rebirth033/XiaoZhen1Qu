using FluentNHibernate.Conventions.Inspections;

namespace TianWen.Nhibernate.TianWen.Nhibernate.Convention
{
    using FluentNHibernate.Conventions;
    using FluentNHibernate.Conventions.Instances;
    using System;

    public class IdConvention : IIdConvention, IConvention<IIdentityInspector, IIdentityInstance>, IConvention
    {
        public void Apply(IIdentityInstance instance)
        {
        }
    }
}

