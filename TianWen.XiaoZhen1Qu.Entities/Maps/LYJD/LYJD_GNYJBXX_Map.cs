using FluentNHibernate.Mapping;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.Maps
{
    public class LYJD_GNYJBXX_Map : ClassMap<LYJD_GNYJBXX>
    {
        public LYJD_GNYJBXX_Map()
        {
            Table("LYJD_GNYJBXX");
            #region 属性
            Id(x => x.LYJD_GNYJBXXID, "LYJD_GNYJBXXID").GeneratedBy.Assigned().CustomType("AnsiString");
            Map(x => x.JCXXID, "JCXXID");
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
