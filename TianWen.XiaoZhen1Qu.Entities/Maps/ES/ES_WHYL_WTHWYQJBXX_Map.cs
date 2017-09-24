using FluentNHibernate.Mapping;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.Maps
{
    public class ES_WHYL_WTHWYQJBXX_Map : ClassMap<ES_WHYL_WTHWYQJBXX>
    {
        public ES_WHYL_WTHWYQJBXX_Map()
        {
            Table("ES_WHYL_WTHWYQJBXX");
            #region 属性
            Id(x => x.ES_WHYL_WTHWYQJBXXID, "ES_WHYL_WTHWYQJBXXID").GeneratedBy.Assigned().CustomType("AnsiString");
            Map(x => x.JCXXID, "JCXXID");
            Map(x => x.GQ, "GQ");
            Map(x => x.LB, "LB");
            Map(x => x.XL, "XL");
            Map(x => x.XJ, "XJ");
            Map(x => x.JG, "JG");
            Map(x => x.BCMS, "BCMS");
            Map(x => x.JYQY, "JYQY");
            Map(x => x.JYDD, "JYDD");
            #endregion

            #region OneToMany

            #endregion

            #region ManyToOne

            #endregion

        }
    }
}
