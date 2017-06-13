namespace TianWen.GlobalResource
{
    using System;
    using System.Collections.ObjectModel;
    using System.Runtime.CompilerServices;

    [Serializable]
    public class Organization
    {
        public Collection<Organization> Childs = new Collection<Organization>();
        public Collection<Department> Departments = new Collection<Department>();
        public Organization Parent;

        public override bool Equals(object object_0)
        {
            Organization organization = (Organization) object_0;
            return this.Id.Equals(organization.Id);
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        public string Address { get; set; }

        public string Code { get; set; }

        public string Fax { get; set; }

        public string Grade { get; set; }

        public string Id { get; set; }

        public string Name { get; set; }

        public string OrderNo { get; set; }

        public string ParentId { get; set; }

        public string PostCode { get; set; }

        public string Prop { get; set; }

        public string RegionAbbr { get; set; }

        public string RegionCode { get; set; }

        public string RegionName { get; set; }

        public string Remark { get; set; }

        public string ShortName { get; set; }

        public string Status { get; set; }

        public string Tel { get; set; }
    }
}

