using FluentNHibernate.Mapping;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.Maps
{
    public class PWKQ_YCMPJBXX_Map : ClassMap<PWKQ_YCMPJBXX>
    {
        public PWKQ_YCMPJBXX_Map()
        {
            Table("PWKQ_YCMPJBXX");
            #region 属性
            Id(x => x.ID, "ID").GeneratedBy.Assigned().CustomType("AnsiString");
            Map(x => x.JCXXID, "JCXXID");
            Map(x => x.GQ, "GQ");
            Map(x => x.LB, "LB");
            Map(x => x.YJ, "YJ");
            Map(x => x.SJ, "SJ");
            Map(x => x.JG, "JG");
            Map(x => x.CG, "CG");
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
