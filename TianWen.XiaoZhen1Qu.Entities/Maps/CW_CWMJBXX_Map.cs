using FluentNHibernate.Mapping;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.Maps
{
    public class CW_CWMJBXX_Map : ClassMap<CW_CWMJBXX>
    {
        public CW_CWMJBXX_Map()
        {
            Table("CW_CWMJBXX");
            #region 属性
            Id(x => x.CW_CWMJBXXID, "CW_CWMJBXXID").GeneratedBy.Assigned().CustomType("AnsiString");
            Map(x => x.JCXXID, "JCXXID");
            Map(x => x.GQ, "GQ");
            Map(x => x.PZ, "PZ");
            Map(x => x.JG, "JG");
            Map(x => x.BCMS, "BCMS");
            #endregion

            #region OneToMany

            #endregion

            #region ManyToOne

            #endregion

        }
    }
}
