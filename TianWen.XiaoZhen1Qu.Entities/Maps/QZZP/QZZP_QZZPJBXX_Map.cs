using FluentNHibernate.Mapping;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.Maps
{
    public class QZZP_QZZPJBXX_Map : ClassMap<QZZP_QZZPJBXX>
    {
        public QZZP_QZZPJBXX_Map()
        {
            Table("QZZP_QZZPJBXX");
            #region 属性
            Id(x => x.QZZP_QZZPJBXXID, "QZZP_QZZPJBXXID").GeneratedBy.Assigned().CustomType("AnsiString");
            Map(x => x.JCXXID, "JCXXID");
            Map(x => x.BCMS, "BCMS");
            Map(x => x.LB, "LB");
            Map(x => x.XL, "XL");
            Map(x => x.FS, "FS");
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
