using FluentNHibernate.Mapping;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.Maps
{
    public class FC_HZFJBXX_Map : ClassMap<FC_HZFJBXX>
    {
        public FC_HZFJBXX_Map()
        {
            Table("FC_HZFJBXX");
            #region 属性
            Id(x => x.ID, "ID").GeneratedBy.Assigned().CustomType("AnsiString");
            Map(x => x.JCXXID, "JCXXID");
            Map(x => x.XQMC, "XQMC");
            Map(x => x.XQDZ, "XQDZ");
            Map(x => x.S, "S");
            Map(x => x.T, "T");
            Map(x => x.W, "W");
            Map(x => x.PFM, "PFM");
            Map(x => x.CX, "CX");
            Map(x => x.ZXQK, "ZXQK");
            Map(x => x.ZZLX, "ZZLX");
            Map(x => x.C, "C");
            Map(x => x.GJC, "GJC");
            Map(x => x.ZJ, "ZJ");
            Map(x => x.YFFS, "YFFS");
            Map(x => x.ZJYBHFY, "ZJYBHFY");
            Map(x => x.FWPZ, "FWPZ");
            Map(x => x.FWLD, "FWLD");
            Map(x => x.CZYQ, "CZYQ");
            Map(x => x.BCMS, "BCMS");
            Map(x => x.KRZSJ, "KRZSJ");
            Map(x => x.CZJMJ, "CZJMJ");
            Map(x => x.CZJLX, "CZJLX");
            Map(x => x.CZJXB, "CZJXB");
            #endregion

            #region OneToMany

            #endregion

            #region ManyToOne

            #endregion

        }
    }
}
