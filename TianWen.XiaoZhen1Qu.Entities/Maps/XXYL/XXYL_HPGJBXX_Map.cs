using FluentNHibernate.Mapping;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.Maps
{
    public class XXYL_HPGJBXX_Map : ClassMap<XXYL_HPGJBXX>
    {
        public XXYL_HPGJBXX_Map()
        {
            Table("XXYL_HPGJBXX");
            #region 属性
            Id(x => x.XXYL_HPGJBXXID, "XXYL_HPGJBXXID").GeneratedBy.Assigned().CustomType("AnsiString");
            Map(x => x.JCXXID, "JCXXID");
            Map(x => x.SNSB, "SNSB");
            Map(x => x.BCMS, "BCMS");
            Map(x => x.QY, "QY");
            Map(x => x.DD, "DD");
            Map(x => x.JTDZ, "JTDZ");
            Map(x => x.KRNRS, "KRNRS");
            Map(x => x.CDMJ, "CDMJ");
            Map(x => x.JG, "JG");
            #endregion

            #region OneToMany

            #endregion

            #region ManyToOne

            #endregion

        }
    }
}
