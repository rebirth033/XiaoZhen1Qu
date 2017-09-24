using FluentNHibernate.Mapping;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.Maps
{
    public class ES_JDJJBG_ESJDJBXX_Map : ClassMap<ES_JDJJBG_ESJDJBXX>
    {
        public ES_JDJJBG_ESJDJBXX_Map()
        {
            Table("ES_JDJJBG_ESJDJBXX");
            #region 属性
            Id(x => x.ES_JDJJBG_ESJDJBXXID, "ES_JDJJBG_ESJDJBXXID").GeneratedBy.Assigned().CustomType("AnsiString");
            Map(x => x.JCXXID, "JCXXID");
            Map(x => x.GQ, "GQ");
            Map(x => x.LB, "LB");
            Map(x => x.XL, "XL");
            Map(x => x.XJ, "XJ");
            Map(x => x.JG, "JG");
            Map(x => x.BCMS, "BCMS");
            Map(x => x.JYQY, "JYQY");
            Map(x => x.JYDD, "JYDD");
            Map(x => x.DSPMCC, "DSPMCC");
            Map(x => x.DSPP, "DSPP");
            Map(x => x.XYJPP, "XYJPP");
            Map(x => x.KTPP, "KTPP");
            Map(x => x.KTBPDS, "KTBPDS");
            Map(x => x.KTGL, "KTGL");
            Map(x => x.BXPP, "BXPP");
            Map(x => x.BGPP, "BGPP");
            #endregion

            #region OneToMany

            #endregion

            #region ManyToOne

            #endregion

        }
    }
}
