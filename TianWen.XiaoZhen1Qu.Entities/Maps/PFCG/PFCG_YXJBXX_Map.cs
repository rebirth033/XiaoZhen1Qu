using FluentNHibernate.Mapping;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.Maps
{
    public class PFCG_YXJBXX_Map : ClassMap<PFCG_YXJBXX>
    {
        public PFCG_YXJBXX_Map()
        {
            Table("PFCG_YXJBXX");
            #region 属性
            Id(x => x.PFCG_YXJBXXID, "PFCG_YXJBXXID").GeneratedBy.Assigned().CustomType("AnsiString");
            Map(x => x.JCXXID, "JCXXID");
            Map(x => x.BCMS, "BCMS");
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
