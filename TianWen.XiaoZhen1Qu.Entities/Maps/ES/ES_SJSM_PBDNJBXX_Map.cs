using FluentNHibernate.Mapping;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.Maps
{
    public class ES_SJSM_PBDNJBXX_Map : ClassMap<ES_SJSM_PBDNJBXX>
    {
        public ES_SJSM_PBDNJBXX_Map()
        {
            Table("ES_SJSM_PBDNJBXX");
            #region 属性
            Id(x => x.ES_SJSM_PBDNJBXXID, "ES_SJSM_PBDNJBXXID").GeneratedBy.Assigned().CustomType("AnsiString");
            Map(x => x.JCXXID, "JCXXID");
            Map(x => x.GQ, "GQ");
            Map(x => x.LB, "LB");
            Map(x => x.XL, "XL");
            Map(x => x.PBPP, "PBPP");
            Map(x => x.PBXH, "PBXH");
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
