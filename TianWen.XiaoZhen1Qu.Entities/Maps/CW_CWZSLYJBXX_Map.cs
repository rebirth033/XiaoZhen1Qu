using FluentNHibernate.Mapping;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.Maps
{
    public class CW_CWZSLYJBXX_Map : ClassMap<CW_CWZSLYJBXX>
    {
        public CW_CWZSLYJBXX_Map()
        {
            Table("CW_CWZSLYJBXX");
            #region 属性
            Id(x => x.CW_CWZSLYJBXXID, "CW_CWZSLYJBXXID").GeneratedBy.Assigned().CustomType("AnsiString");
            Map(x => x.JCXXID, "JCXXID");
            Map(x => x.GQ, "GQ");
            Map(x => x.BCMS, "BCMS");
            #endregion

            #region OneToMany

            #endregion

            #region ManyToOne

            #endregion

        }
    }
}
