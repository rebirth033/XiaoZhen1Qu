using FluentNHibernate.Mapping;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.Maps
{
    public class HQSY_HSSYJBXX_Map : ClassMap<HQSY_HSSYJBXX>
    {
        public HQSY_HSSYJBXX_Map()
        {
            Table("HQSY_HSSYJBXX");
            #region 属性
            Id(x => x.ID, "ID").GeneratedBy.Assigned().CustomType("AnsiString");
            Map(x => x.JCXXID, "JCXXID");
            Map(x => x.YLGZS, "YLGZS");
            Map(x => x.PSDD, "PSDD");
            Map(x => x.PSFG, "PSFG");
            Map(x => x.FWBZ, "FWBZ");
            Map(x => x.FZTS, "FZTS");
            Map(x => x.FZSFFQ, "FZSFFQ");
            Map(x => x.FZPSSF, "FZPSSF");
            Map(x => x.TXNHZZX, "TXNHZZX");
            Map(x => x.TXDPS, "TXDPS");
            Map(x => x.TXJXJRCS, "TXJXJRCS");
            Map(x => x.JXKPZS, "JXKPZS");
            Map(x => x.DPZS, "DPZS");
            Map(x => x.JPSF, "JPSF");
            Map(x => x.JDSF, "JDSF");
            Map(x => x.TXXCSL, "TXXCSL");
            Map(x => x.TXBJSL, "TXBJSL");
            Map(x => x.PSSJ, "PSSJ");
            Map(x => x.BHCY, "BHCY");
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
