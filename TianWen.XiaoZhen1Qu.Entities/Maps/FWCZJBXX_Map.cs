using FluentNHibernate.Mapping;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.Maps
{
    public class FWCZJBXX_Map : ClassMap<FWCZJBXX>
    {
        public FWCZJBXX_Map()
        {
            Table("FWCZJBXX");
            #region 属性
            Id(x => x.FWCZID, "FWCZID").GeneratedBy.Assigned().CustomType("System.Int32");
            Map(x => x.JCXXID, "JCXXID");
            Map(x => x.CZFS, "CZFS");
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
            Map(x => x.ZJ, "ZJ");
            Map(x => x.YFFS, "YFFS");
            Map(x => x.ZJYBHFY, "ZJYBHFY");
            Map(x => x.FWPZ, "FWPZ");
            Map(x => x.FWLD, "FWLD");
            Map(x => x.CZYQ, "CZYQ");
            Map(x => x.FYMS, "FYMS");
            Map(x => x.KRZSJ, "KRZSJ");
            #endregion

            #region OneToMany

            #endregion

            #region ManyToOne

            #endregion

        }
    }
}
