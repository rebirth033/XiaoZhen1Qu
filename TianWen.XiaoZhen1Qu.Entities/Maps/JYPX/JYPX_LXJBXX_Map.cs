using FluentNHibernate.Mapping;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.Maps
{
    public class JYPX_LXJBXX_Map : ClassMap<JYPX_LXJBXX>
    {
        public JYPX_LXJBXX_Map()
        {
            Table("JYPX_LXJBXX");
            #region 属性
            Id(x => x.JYPX_LXJBXXID, "JYPX_LXJBXXID").GeneratedBy.Assigned().CustomType("AnsiString");
            Map(x => x.JCXXID, "JCXXID");
            Map(x => x.GJ, "GJ");
            Map(x => x.SQXL, "SQXL");
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
