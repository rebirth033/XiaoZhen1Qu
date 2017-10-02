using FluentNHibernate.Mapping;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.Maps
{
    public class QZZP_JZZPJBXX_Map : ClassMap<QZZP_JZZPJBXX>
    {
        public QZZP_JZZPJBXX_Map()
        {
            Table("QZZP_JZZPJBXX");
            #region 属性
            Id(x => x.QZZP_JZZPJBXXID, "QZZP_JZZPJBXXID").GeneratedBy.Assigned().CustomType("AnsiString");
            Map(x => x.JCXXID, "JCXXID");
            Map(x => x.ZWLB, "ZWLB");
            Map(x => x.ZPRS, "ZPRS");
            Map(x => x.MYXZ, "MYXZ");
            Map(x => x.ZWFL, "ZWFL");
            Map(x => x.XLYQ, "XLYQ");
            Map(x => x.GZNX, "GZNX");
            Map(x => x.BCMS, "BCMS");
            #endregion

            #region OneToMany

            #endregion

            #region ManyToOne

            #endregion

        }
    }
}
