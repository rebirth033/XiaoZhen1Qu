using FluentNHibernate.Mapping;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.Maps
{
    public class CODES_XQJBXX_Map : ClassMap<CODES_XQJBXX>
    {
        public CODES_XQJBXX_Map()
        {
            Table("CODES_XQJBXX");
            #region 属性
            Id(x => x.XQJBXXID, "XQJBXXID").GeneratedBy.Assigned().CustomType("AnsiString");
            Map(x => x.XQMC, "XQMC");
            Map(x => x.XQDZ, "XQDZ");
            Map(x => x.XQMCPY, "XQMCPY");
            Map(x => x.XQMCPYQKG, "XQMCPYQKG");
            Map(x => x.XQMCPYSZM, "XQMCPYSZM");
            Map(x => x.SZS, "SZS");
            Map(x => x.SZX, "SZX");
            Map(x => x.KFS, "KFS");
            Map(x => x.WYGS, "WYGS");
            Map(x => x.WYLX, "WYLX");
            Map(x => x.WYF, "WYF");
            Map(x => x.ZJMJ, "ZJMJ");
            Map(x => x.ZHS, "ZHS");
            Map(x => x.JZND, "JZND");
            Map(x => x.RJL, "RJL");
            Map(x => x.TCW, "TCW");
            Map(x => x.LHL, "LHL");
            #endregion

            #region OneToMany

            #endregion

            #region ManyToOne

            #endregion

        }
    }
}
