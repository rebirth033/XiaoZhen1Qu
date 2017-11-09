using FluentNHibernate.Mapping;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.Maps
{
    public class SWFW_SYSXJBXX_Map : ClassMap<SWFW_SYSXJBXX>
    {
        public SWFW_SYSXJBXX_Map()
        {
            Table("SWFW_SYSXJBXX");
            #region 属性
            Id(x => x.ID, "ID").GeneratedBy.Assigned().CustomType("AnsiString");
            Map(x => x.JCXXID, "JCXXID");
            Map(x => x.LB, "LB");
            Map(x => x.NLD, "NLD");
            Map(x => x.SYLX, "SYLX");
            Map(x => x.SLLX, "SLLX");
            Map(x => x.YLGZS, "YLGZS");
            Map(x => x.XZLX, "XZLX");
            Map(x => x.PSDD, "PSDD");
            Map(x => x.PSFG, "PSFG");
            Map(x => x.FZTS, "FZTS");
            Map(x => x.FZPSSF, "FZPSSF");
            Map(x => x.TXDPS, "TXDPS");
            Map(x => x.TXJXJRCS, "TXJXJRCS");
            Map(x => x.JXKPZS, "JXKPZS");
            Map(x => x.DPZS, "DPZS");
            Map(x => x.JPSF, "JPSF");
            Map(x => x.JDSF, "JDSF");
            Map(x => x.TXXCSL, "TXXCSL");
            Map(x => x.TXBJSL, "TXBJSL");
            Map(x => x.JG, "JG");
            Map(x => x.FWQY, "FWQY");
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
