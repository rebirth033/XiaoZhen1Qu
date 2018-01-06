using FluentNHibernate.Mapping;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.Maps
{
    public class SWFW_PHZPJBXX_Map : ClassMap<SWFW_PHZPJBXX>
    {
        public SWFW_PHZPJBXX_Map()
        {
            Table("SWFW_PHZPJBXX");
            #region 属性
            Id(x => x.ID, "ID").GeneratedBy.Assigned().CustomType("AnsiString");
            Map(x => x.JCXXID, "JCXXID");
            Map(x => x.LB, "LB");
            Map(x => x.CZ, "CZ");
            Map(x => x.YT, "YT");
            Map(x => x.GN, "GN");
            Map(x => x.XL, "XL");
            Map(x => x.GY, "GY");
            Map(x => x.SFFG, "SFFG");
            Map(x => x.FWFW, "FWFW");
            Map(x => x.QY, "QY");
            Map(x => x.DD, "DD");
            Map(x => x.JTDZ, "JTDZ");
            Map(x => x.BCMS, "BCMS");
            #endregion

            #region OneToMany

            #endregion

            #region ManyToOne

            #endregion

        }
    }
}
