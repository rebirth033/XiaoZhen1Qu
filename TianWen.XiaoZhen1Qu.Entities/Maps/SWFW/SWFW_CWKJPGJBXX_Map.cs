using FluentNHibernate.Mapping;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.Maps
{
    public class SWFW_CWKJPGJBXX_Map : ClassMap<SWFW_CWKJPGJBXX>
    {
        public SWFW_CWKJPGJBXX_Map()
        {
            Table("SWFW_CWKJPGJBXX");
            #region 属性
            Id(x => x.SWFW_CWKJPGJBXXID, "SWFW_CWKJPGJBXXID").GeneratedBy.Assigned().CustomType("AnsiString");
            Map(x => x.JCXXID, "JCXXID");
            Map(x => x.LB, "LB");
            Map(x => x.SFSM, "SFSM");
            Map(x => x.FWQY, "FWQY");
            Map(x => x.QY, "QY");
            Map(x => x.DD, "DD");
            Map(x => x.JTDZ, "JTDZ");
            Map(x => x.BCMS, "BCMS");
            #endregion

            #region OneToMany

            #endregion

            #region ManyToOne

            #endregion

        }
    }
}
