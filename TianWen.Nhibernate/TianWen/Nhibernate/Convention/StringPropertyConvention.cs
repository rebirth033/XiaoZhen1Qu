namespace TianWen.Nhibernate.Convention
{
    using FluentNHibernate.Conventions;
    using FluentNHibernate.Conventions.AcceptanceCriteria;
    using FluentNHibernate.Conventions.Inspections;
    using FluentNHibernate.Conventions.Instances;
    using System;

    public class StringPropertyConvention : IPropertyConvention, IConvention<IPropertyInspector, IPropertyInstance>, IConvention, IPropertyConventionAcceptance, IConventionAcceptance<IPropertyInspector>
    {
        public void Accept(IAcceptanceCriteria<IPropertyInspector> criteria)
        {
            criteria.Expect(x => x.Property.PropertyType == typeof(string));
        }

        public void Apply(IPropertyInstance instance)
        {
            instance.CustomType("AnsiString");
        }
    }
}

