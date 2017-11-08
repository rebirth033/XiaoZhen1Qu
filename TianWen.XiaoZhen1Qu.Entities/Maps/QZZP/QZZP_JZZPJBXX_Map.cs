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
            Id(x => x.ID, "ID").GeneratedBy.Assigned().CustomType("AnsiString");
            Map(x => x.JCXXID, "JCXXID");
            Map(x => x.JZLB, "JZLB");
            Map(x => x.ZPRS, "ZPRS");
            Map(x => x.JZSJ, "JZSJ");
            Map(x => x.JZYXQ, "JZYXQ");
            Map(x => x.DQJZKSSJ, "DQJZKSSJ");
            Map(x => x.DQJZJSSJ, "DQJZJSSJ");
            Map(x => x.BCMS, "BCMS");
            Map(x => x.XZ, "XZ");
            Map(x => x.XZDW, "XZDW");
            Map(x => x.XZJS, "XZJS");
            Map(x => x.JLJSYX, "JLJSYX");
            Map(x => x.GZCS, "GZCS");
            Map(x => x.QY, "QY");
            Map(x => x.DD, "DD");
            Map(x => x.XXDZ, "XXDZ");
            #endregion

            #region OneToMany

            #endregion

            #region ManyToOne

            #endregion

        }
    }
}
