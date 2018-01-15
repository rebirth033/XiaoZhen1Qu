using FluentNHibernate.Mapping;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.Maps
{
    public class QZZP_QZZPJBXX_Map : ClassMap<QZZP_QZZPJBXX>
    {
        public QZZP_QZZPJBXX_Map()
        {
            Table("QZZP_QZZPJBXX");
            #region 属性
            Id(x => x.ID, "ID").GeneratedBy.Assigned().CustomType("AnsiString");
            Map(x => x.JCXXID, "JCXXID");
            Map(x => x.ZWLB, "ZWLB");
            Map(x => x.ZWMC, "ZWMC");
            Map(x => x.ZPRS, "ZPRS");
            Map(x => x.MYXZ, "MYXZ");
            Map(x => x.ZWFL, "ZWFL");
            Map(x => x.XLYQ, "XLYQ");
            Map(x => x.GZNX, "GZNX");
            Map(x => x.BCMS, "BCMS");
            Map(x => x.GSMC, "GSMC");
            Map(x => x.QY, "QY");
            Map(x => x.DD, "DD");
            Map(x => x.JTDZ, "JTDZ");
            #endregion

            #region OneToMany

            #endregion

            #region ManyToOne

            #endregion

        }
    }
}
