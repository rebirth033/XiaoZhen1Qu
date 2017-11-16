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
            Id(x => x.ID, "ID").GeneratedBy.Assigned().CustomType("AnsiString");
            Map(x => x.JCXXID, "JCXXID");
            Map(x => x.GQ, "GQ");
            Map(x => x.LB, "LB");
            Map(x => x.XL, "XL");
            Map(x => x.XJ, "XJ");
            Map(x => x.JG, "JG");
            Map(x => x.PP, "PP");
            Map(x => x.DSPMCC, "DSPMCC");
            Map(x => x.KTBPDS, "KTBPDS");
            Map(x => x.KTGL, "KTGL");
            Map(x => x.QY, "QY");
            Map(x => x.DD, "DD");
            Map(x => x.BCMS, "BCMS");
            #endregion

            #region OneToMany

            #endregion

            #region ManyToOne

            #endregion

        }
    }
}
