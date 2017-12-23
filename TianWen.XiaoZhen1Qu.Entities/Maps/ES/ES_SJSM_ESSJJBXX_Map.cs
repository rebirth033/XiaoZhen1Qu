using FluentNHibernate.Mapping;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.Maps
{
    public class ES_SJSM_ESSJJBXX_Map : ClassMap<ES_SJSM_ESSJJBXX>
    {
        public ES_SJSM_ESSJJBXX_Map()
        {
            Table("ES_SJSM_ESSJJBXX");
            #region 属性
            Id(x => x.ID, "ID").GeneratedBy.Assigned().CustomType("AnsiString");
            Map(x => x.JCXXID, "JCXXID");
            Map(x => x.SF, "SF");
            Map(x => x.PP, "PP");
            Map(x => x.XH, "XH");
            Map(x => x.SYQK, "SYQK");
            Map(x => x.JG, "JG");
            Map(x => x.TSBQ, "TSBQ");
            Map(x => x.BCMS, "BCMS");
            Map(x => x.QY, "QY");
            Map(x => x.DD, "DD");
            #endregion

            #region OneToMany

            #endregion

            #region ManyToOne

            #endregion

        }
    }
}
