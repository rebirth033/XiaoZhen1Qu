using FluentNHibernate.Mapping;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.Maps
{
    public class PFCG_JXJGJBXX_Map : ClassMap<PFCG_JXJGJBXX>
    {
        public PFCG_JXJGJBXX_Map()
        {
            Table("PFCG_JXJGJBXX");
            #region 属性
            Id(x => x.PFCG_JXJGJBXXID, "PFCG_JXJGJBXXID").GeneratedBy.Assigned().CustomType("AnsiString");
            Map(x => x.JCXXID, "JCXXID");
            Map(x => x.BCMS, "BCMS");
            Map(x => x.LB, "LB");
            Map(x => x.QY, "QY");
            Map(x => x.DD, "DD");
            Map(x => x.JTDZ, "JTDZ");
            #endregion

            #region OneToMany

            #endregion

            #region ManyToOne

            #endregion

        }
    }
}
