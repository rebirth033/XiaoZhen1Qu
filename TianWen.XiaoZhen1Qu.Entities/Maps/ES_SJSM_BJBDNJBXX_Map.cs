using FluentNHibernate.Mapping;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.Maps
{
    public class ES_SJSM_BJBDNJBXX_Map : ClassMap<ES_SJSM_BJBDNJBXX>
    {
        public ES_SJSM_BJBDNJBXX_Map()
        {
            Table("ES_SJSM_BJBDNJBXX");
            #region 属性
            Id(x => x.ES_SJSM_BJBDNJBXXID, "ES_SJSM_BJBDNJBXXID").GeneratedBy.Assigned().CustomType("AnsiString");
            Map(x => x.JCXXID, "JCXXID");
            Map(x => x.GQ, "GQ");
            Map(x => x.LB, "LB");
            Map(x => x.BJBPP, "BJBPP");
            Map(x => x.BJBXH, "BJBXH");
            Map(x => x.CPUPP, "CPUPP");
            Map(x => x.CPUHS, "CPUHS");
            Map(x => x.NC, "NC");
            Map(x => x.YP, "YP");
            Map(x => x.PMCC, "PMCC");
            Map(x => x.XK, "XK");
            Map(x => x.XJ, "XJ");
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
