using FluentNHibernate.Mapping;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.Maps
{
    public class ZSJM_FZXBJBXX_Map : ClassMap<ZSJM_FZXBJBXX>
    {
        public ZSJM_FZXBJBXX_Map()
        {
            Table("ZSJM_FZXBJBXX");
            #region 属性
            Id(x => x.ZSJM_FZXBJBXXID, "ZSJM_FZXBJBXXID").GeneratedBy.Assigned().CustomType("AnsiString");
            Map(x => x.JCXXID, "JCXXID");
            Map(x => x.LB, "LB");
            Map(x => x.BCMS, "BCMS");
            Map(x => x.PPMC, "PPMC");
            Map(x => x.PPLS, "PPLS");
            Map(x => x.TZJE, "TZJE");
            Map(x => x.QGFDS, "QGFDS");
            Map(x => x.DDMJ, "DDMJ");
            Map(x => x.SHRQ, "SHRQ");
            Map(x => x.PPMS, "PPMS");
            Map(x => x.ZSDQ, "ZSDQ");
            #endregion

            #region OneToMany

            #endregion

            #region ManyToOne

            #endregion

        }
    }
}
