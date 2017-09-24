using FluentNHibernate.Mapping;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.Maps
{
    public class CW_CWFWJBXX_Map : ClassMap<CW_CWFWJBXX>
    {
        public CW_CWFWJBXX_Map()
        {
            Table("CW_CWFWJBXX");
            #region 属性
            Id(x => x.CW_CWFWJBXXID, "CW_CWFWJBXXID").GeneratedBy.Assigned().CustomType("AnsiString");
            Map(x => x.JCXXID, "JCXXID");
            Map(x => x.LB, "LB");
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
