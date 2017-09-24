using FluentNHibernate.Mapping;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.Maps
{
    public class PWKQ_DYPJBXX_Map : ClassMap<PWKQ_DYPJBXX>
    {
        public PWKQ_DYPJBXX_Map()
        {
            Table("PWKQ_DYPJBXX");
            #region 属性
            Id(x => x.PWKQ_DYPJBXXID, "PWKQ_DYPJBXXID").GeneratedBy.Assigned().CustomType("AnsiString");
            Map(x => x.JCXXID, "JCXXID");
            Map(x => x.GQ, "GQ");
            Map(x => x.LB, "LB");
            Map(x => x.XL, "XL");
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
