using FluentNHibernate.Mapping;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.Maps
{
    public class CW_CWGJBXX_Map : ClassMap<CW_CWGJBXX>
    {
        public CW_CWGJBXX_Map()
        {
            Table("CW_CWGJBXX");
            #region 属性
            Id(x => x.ID, "ID").GeneratedBy.Assigned().CustomType("AnsiString");
            Map(x => x.JCXXID, "JCXXID");
            Map(x => x.SF, "SF");
            Map(x => x.PZ, "PZ");
            Map(x => x.JG, "JG");
            Map(x => x.NL, "NL");
            Map(x => x.NLDW, "NLDW");
            Map(x => x.XB, "XB");
            Map(x => x.MS, "MS");
            Map(x => x.QCQK, "QCQK");
            Map(x => x.YMQK, "YMQK");
            Map(x => x.YMZL, "YMZL");
            Map(x => x.ZSZS, "ZSZS");
            Map(x => x.BCMS, "BCMS");
            #endregion

            #region OneToMany

            #endregion

            #region ManyToOne

            #endregion

        }
    }
}
