using FluentNHibernate.Mapping;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.Maps
{
    public class FC_ESFJBXX_Map : ClassMap<FC_ESFJBXX>
    {
        public FC_ESFJBXX_Map()
        {
            Table("FC_ESFJBXX");
            #region 属性
            Id(x => x.ID, "ID").GeneratedBy.Assigned().CustomType("AnsiString");
            Map(x => x.JCXXID, "JCXXID");
            Map(x => x.XQMC, "XQMC");
            Map(x => x.S, "S");
            Map(x => x.T, "T");
            Map(x => x.W, "W");
            Map(x => x.PFM, "PFM");
            Map(x => x.CX, "CX");
            Map(x => x.ZXQK, "ZXQK");
            Map(x => x.ZZLX, "ZZLX");
            Map(x => x.C, "C");
            Map(x => x.GJC, "GJC");
            Map(x => x.SJ, "SJ");
            Map(x => x.FWLD, "FWLD");
            Map(x => x.BCMS, "BCMS");
            Map(x => x.KRZSJ, "KRZSJ");
            #endregion

            #region OneToMany

            #endregion

            #region ManyToOne

            #endregion

        }
    }
}
