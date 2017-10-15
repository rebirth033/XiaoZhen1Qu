using FluentNHibernate.Mapping;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.Maps
{
    public class NLMFY_NCPJGJBXX_Map : ClassMap<NLMFY_NCPJGJBXX>
    {
        public NLMFY_NCPJGJBXX_Map()
        {
            Table("NLMFY_NCPJGJBXX");
            #region 属性
            Id(x => x.NLMFY_NCPJGJBXXID, "NLMFY_NCPJGJBXXID").GeneratedBy.Assigned().CustomType("AnsiString");
            Map(x => x.JCXXID, "JCXXID");
            Map(x => x.LB, "LB");
            Map(x => x.XL, "XL");
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
